using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int mPlayerScore;

    Text ScoreUI;
    PlayerHUD playerHud;
    // Start is called before the first frame update
    void Start()
    {
        playerHud = FindObjectOfType<PlayerHUD>();
        ScoreUI = playerHud.mScore.GetComponent<Text>();
        ScoreUI.text = "0";
        mPlayerScore = 0;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playerHud.mFinishLevel.active == false)
            {
                if (playerHud.mPauseMenu.active == false)
                {
                    Cursor.visible = true;
                    playerHud.mPauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }

    public void AddScore()
    {
        ++mPlayerScore;
        ScoreUI.text = mPlayerScore.ToString();
    }
}
