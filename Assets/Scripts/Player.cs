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
        powerText.text = "������ : " + power;
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
                    Debug.Log("�׿���!!");
                    AllFalse();
                }
                else
                {
                    Debug.Log("�׾��٤Ф�");
                    AllFalse();
                }
            }
            else if (enemy.isEnemyShield)
            {
                Debug.Log("�׾��� �Ф�");
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
                Debug.Log("�׿���!!");
                AllFalse();
            }

            else if (enemy.isEnemyShield)
            {
                Debug.Log("�ƹ��ϵ� ������...");
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                Debug.Log("�׾��� �Ф�");
                AllFalse();
            }

        }

        if(isSurpriseAttack)
        {
            if(enemy.isEnemyStab)
            {
                if (power > enemy.enemyPower)
                {
                    Debug.Log("�׿���!!");
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
                Debug.Log("�׿���!!");
                AllFalse();
            }

            else if(enemy.isEnemySurpriseAttack)
            {
                Debug.Log("�ƹ��ϵ� ������...");
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
