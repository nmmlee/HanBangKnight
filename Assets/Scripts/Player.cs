using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isStab;
    public bool isShield; 
    public bool isSurpriseAttack;

    public int power;
    Enemy enemy;

    Text powerText;

    void Start()
    {
        powerText = GetComponentInChildren<Text>();
        enemy = FindObjectOfType<Enemy>();

    }

    void Update()
    {
        powerText.text = "전투력 : " + power;
        AttackCheck();
    }

    void AttackCheck()
    {
        if (isStab)
        {
            if (enemy.isEnemyStab)
            {
                if (power > enemy.enemyPower)
                {
                    Debug.Log("죽였다!!");
                    AllFalse();
                }
                else
                {
                    Debug.Log("죽었다ㅠㅠ");
                    AllFalse();
                }
            }
            else if (enemy.isEnemyShield)
            {
                Debug.Log("죽었다 ㅠㅠ");
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                power -= 1;
                AllFalse();
            }
        }

        if (isShield)
        {
            if (enemy.isEnemyStab)
            {
                Debug.Log("죽였다!!");
                AllFalse();
            }

            else if (enemy.isEnemyShield)
            {
                Debug.Log("아무일도 없었다...");
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                Debug.Log("죽었따 ㅠㅠ");
                AllFalse();
            }

        }

        if(isSurpriseAttack)
        {
            if(enemy.isEnemyStab)
            {
                if (power > enemy.enemyPower)
                {
                    Debug.Log("죽였다!!");
                    AllFalse();
                }
                else
                {
                    enemy.enemyPower -= 1;
                    AllFalse();
                }
            }

            else if(enemy.isEnemyShield)
            {
                Debug.Log("죽였다!!");
                AllFalse();
            }

            else if(enemy.isEnemySurpriseAttack)
            {
                Debug.Log("아무일도 없었다...");
                AllFalse();
            }
        }
    }

    public void Stab()
    {
        isStab = true;
        isShield = false;
        isSurpriseAttack = false;
    }

    public void Shield()
    {
        isShield = true;
        isSurpriseAttack = false;
        isStab = false;
    }

    public void SurpriseAttack()
    {
        isSurpriseAttack = true;
        isShield = false;
        isStab = false;
    }

    void AllFalse()
    {
        isSurpriseAttack = false;
        isShield = false;
        isStab = false;
    }
}
