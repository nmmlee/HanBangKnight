using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isStab;
    public bool isShield;
    public bool isSurpriseAttack;

    public bool stabButtonActive;
    public bool shieldButtonActive;
    public bool sAButtonActive;

    public Player player;
    public GameObject enemyObj;
    public Transform spawnTransfrom;

    public GameObject meteorObj;
    public Transform spawnMeteorTransform;
    
    public Button[] buttons;
    public Text contributionText;
    public Text seasonText;

    public int contribution;

    string[] seasons = { "º½", "¿©¸§", "°¡À»", "°Ü¿ï" };
    int seasonTime = 0;
    int seasonCount = 0;

    bool isSpawn = false;
    int meteorSpawnCnt = 1;

    [SerializeField]
    Enemy enemy;

    void Update()
    {
        enemy = FindObjectOfType<Enemy>();

        AttackCheck();
        SpawnEnemy();
        SpawnMeteor();
        UpdateUI();
        ChangeSeason();
    }

    void ChangeSeason()
    {
        if (seasonTime == 3)
        {
            seasonCount = (seasonCount >= 3) ? seasonCount = 0 : seasonCount += 1;
            seasonTime = 0;
        }
    }

    void UpdateUI()
    {
        contributionText.text = "°øÇåµµ : " + contribution;
        seasonText.text = seasons[seasonCount];

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

    void SpawnMeteor()
    {
        if(meteorSpawnCnt % 3 == 0)
        {
            Instantiate(meteorObj, spawnMeteorTransform.position, spawnMeteorTransform.rotation);
            meteorSpawnCnt = 1;
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
                    contribution++;
                    meteorSpawnCnt++;
                    seasonTime++;


                    isSpawn = false;
                    AllFalse();
                }
                else
                {
                    PlayerDeath();
                    isSpawn = false;
                    AllFalse();
                }
            }
            else if (enemy.isEnemyShield)
            {
                PlayerDeath();
                isSpawn = false;
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                enemy.Death();
                contribution++;
                meteorSpawnCnt++;
                seasonTime++;

                isSpawn = false;
                AllFalse();
            }
        }

        if (isShield)
        {
            if (enemy.isEnemyStab)
            {
                enemy.Death();
                contribution++;
                meteorSpawnCnt++;
                seasonTime++;

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
                PlayerDeath();
                isSpawn = false;
                AllFalse();
            }

        }

        if (isSurpriseAttack)
        {
            if (enemy.isEnemyStab)
            {
                if (player.power > enemy.enemyPower)
                {
                    PlayerDeath();
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
                contribution++;
                meteorSpawnCnt++;
                seasonTime++;

                isSpawn = false;
                AllFalse();
            }

            else if (enemy.isEnemySurpriseAttack)
            {
                enemy.enemyPower -= 1;
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

        stabButtonActive = false;
        shieldButtonActive = true;
        sAButtonActive = true;

        Disabled();

    }

    public void Shield()
    {
        isShield = true;
        isSurpriseAttack = false;
        isStab = false;

        stabButtonActive = true;
        shieldButtonActive = false;
        sAButtonActive = true;

        Disabled();
    }

    public void SurpriseAttack()
    {
        isSurpriseAttack = true;
        isShield = false;
        isStab = false;

        stabButtonActive = true;
        shieldButtonActive = true;
        sAButtonActive = false;

        Disabled();
    }

    void AllFalse()
    {
        isSurpriseAttack = false;
        isShield = false;
        isStab = false;

        Disabled();
    }

    void Disabled()
    {
        buttons[0].interactable = stabButtonActive;
        buttons[1].interactable = shieldButtonActive;
        buttons[2].interactable = sAButtonActive;
    }

    public void PlayerDeath()
    {
        Debug.Log("Á×¾ú´Ù ¤Ð¤Ð");
    }
}
