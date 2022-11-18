using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 JumpSpeed;

    public float mMoveSpeed;
    public float mRotationSpeed;

    CharacterController mPlayerController;
    Animator mPlayerAnimator;

    public float mSpeedRotation = 2;
    GameObject mPlayerCamera;
    float mLastRotation;

    void Start()
    {
        /*
        GameObject PlayerInScene = GameObject.FindGameObjectWithTag("Player");
        if (PlayerInScene)
        {
            if (PlayerInScene != gameObject)
            {
                Destroy(gameObject);
            }
            
        }
        DontDestroyOnLoad(gameObject);
        */
        JumpSpeed = Vector3.zero;
        mPlayerController = GetComponent<CharacterController>();
        mPlayerAnimator = GetComponent<Animator>(); 
        mPlayerCamera = FindObjectOfType<Camera>().gameObject;

    }


    void LerpPlayerRotationTo(float Rotetion)
    {
        mLastRotation = Rotetion;
        float TargetAngle = mPlayerCamera.transform.eulerAngles.y + Rotetion;

        Quaternion TargetRotation = Quaternion.Euler(transform.rotation.x, TargetAngle, transform.rotation.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * mSpeedRotation);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Floor")
        {
            mPlayerAnimator.SetBool("IsJumping", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpSpeed.y += 50.0f;
            }

        }
    }
    
    void FixedUpdate()
    {
        mPlayerAnimator.SetBool("IsJumping", true);

        mPlayerController.Move(new Vector3(0, -9.8f, 0) * Time.deltaTime);

        // 
        if (JumpSpeed.magnitude > 0.2)
        {
            mPlayerController.Move(JumpSpeed * Time.deltaTime);
        }

        JumpSpeed = Vector3.Lerp(JumpSpeed, Vector3.zero, 5 * Time.deltaTime);

        bool Top = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool Down = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool Left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool Right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        if (Top || Down || Left || Right)
        {
            mPlayerAnimator.SetBool("IsRunning", true);

            if (!Right && Top && !Down && !Left)
            {
                LerpPlayerRotationTo(0);
            }

            //Down
            else if (!Right && !Top && Down && !Left)
            {
                LerpPlayerRotationTo(180);
            }

            //left
            else if (!Right && !Top && !Down && Left)
            {
                LerpPlayerRotationTo(-90);
            }
            //Right
            else if (Right && !Top && !Down && !Left)
            {
                LerpPlayerRotationTo(90);
            }


            //TopLeft
            else if (!Right && Top && !Down && Left)
            {
                LerpPlayerRotationTo(-45);
            }
            //TopRight
            else if (Right && Top && !Down && !Left)
            {
                LerpPlayerRotationTo(45);
            }

            //DownLeft
            else if (!Right && !Top && Down && Left)
            {
                LerpPlayerRotationTo(-135);
            }
            //DownLeft
            else if (Right && !Top && Down && !Left)
            {
                LerpPlayerRotationTo(135);
            }

            else
            {
                LerpPlayerRotationTo(mLastRotation);
            }

            mPlayerController.Move(transform.forward * mMoveSpeed * Time.deltaTime);


        }
        else
        {
            mPlayerAnimator.SetBool("IsRunning", false);
        }



        



        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void Update()
    {
        
    }
}
