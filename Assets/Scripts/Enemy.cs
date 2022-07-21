using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isEnemyStab;
    public bool isEnemyShield;
    public bool isEnemySurpriseAttack;

    public int enemyPower;

    public float curTime;
    public float maxTime;

    void Start()
    {
        maxTime = Random.Range(1.5f, 2f);
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= maxTime)
        {
            AttackReady();
            curTime = 0;

            maxTime = Random.Range(1.5f, 2f);
        }

    }

    void AttackReady()
    {
        int ranNum = Random.Range(0, 3);

        switch(ranNum)
        {
            case 0:
                isEnemyStab = true;
                isEnemyShield = false;
                isEnemySurpriseAttack = false;
                break;

            case 1:
                isEnemyStab = false;
                isEnemyShield = true;
                isEnemySurpriseAttack = false;
                break;

            case 2:
                isEnemyStab = false;
                isEnemyShield = false;
                isEnemySurpriseAttack = true;
                break;

        }
    }
}
