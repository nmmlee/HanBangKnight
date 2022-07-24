using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isStab;
    public bool isShield;
    public bool isSurpriseAttack;

    public Player player;
    public GameObject enemyObj;
    public Transform spawnTransfrom;

    bool isSpawn = false;

    [SerializeField]
    Enemy enemy;

    void Update()
    {
        enemy = FindObjectOfType<Enemy>();

        AttackCheck();
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (isSpawn)
            return;

        else
        {
            Instantiate(enemyObj, spawnTransfrom.position, spawnTransfrom.rotation);
            isSpawn = true;
        }

    }

    void AttackCheck()
    {
        if (isStab)
        {
            if (enemy.isEnemyStab)
            {
                if (player.power > enemy.enemyPower)
                {
                    enemy.Death();
                    isSpawn = false;
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
                player.power -= 1;
                enemy.StateChange();
                AllFalse();
            }
        }

        if (isShield)
        {
            if (enemy.isEnemyStab)
            {
                enemy.Death();
                isSpawn = false;
                AllFalse();
            }

            else if (enemy.isEnemyShield)
            {
                enemy.enemyPower += 1;
                enemy.StateChange();
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                Debug.Log("죽었따 ㅠㅠ");
                AllFalse();
            }

        }

        if (isSurpriseAttack)
        {
            if (enemy.isEnemyStab)
            {
                if (player.power > enemy.enemyPower)
                {
                    enemy.Death();
                    isSpawn = false;
                    AllFalse();
                }
                else
                {
                    enemy.enemyPower -= 1;
                    enemy.StateChange();
                    AllFalse();
                }
            }

            else if (enemy.isEnemyShield)
            {
                enemy.Death();
                isSpawn = false;
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                Debug.Log("아무일도 없었다...");
                enemy.StateChange();
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
