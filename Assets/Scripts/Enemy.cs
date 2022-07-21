using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool isEnemyStab;
    public bool isEnemyShield;
    public bool isEnemySurpriseAttack;

    public int enemyPower;

    public float curTime;
    public float maxTime;

    public bool isReady;

    Text enemyPowerText;
    Image enemyHpbar;

    void Start()
    {
        maxTime = Random.Range(7f, 10f);
        enemyPowerText = GetComponentInChildren<Text>();
        enemyHpbar = GetComponentsInChildren<Image>()[1];
    }

    void Update()
    {
        if(isReady)
        {
            enemyHpbar.color = new Color(0, 0, 255);
            enemyHpbar.fillAmount += Time.deltaTime;
        }

        else
        {
            enemyHpbar.color = new Color(255, 0, 0);
            curTime += Time.deltaTime;

            if (curTime >= maxTime)
            {
                curTime = 0;
                maxTime = Random.Range(7f, 10f);
            }
        }

        if(enemyHpbar.fillAmount == 1)
        {
            isReady = false;
            AttackReady();
        }

        else if(enemyHpbar.fillAmount == 0)
        {
            isReady = true;
        }

        enemyPowerText.text = "ÀüÅõ·Â : " + enemyPower;
        enemyHpbar.fillAmount -= (Time.deltaTime / maxTime);
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
