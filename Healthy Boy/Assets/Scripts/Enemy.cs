using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent mAgent;
    Animator mEnemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mEnemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;



        if (Vector3.Distance(transform.position, PlayerPosition)  < mAgent.stoppingDistance)
        {
            mEnemyAnimator.SetBool("IsRunning", false);
        }
        else
        {
            mEnemyAnimator.SetBool("IsRunning", true);
        }




        mAgent.SetDestination(PlayerPosition);
    }
}
