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
    public bool isAnim;
    public bool isInteract;

    public Image enemyHpbar;

    Text enemyPowerText;
    Text enemyStateText;

    GameManager gameManager;
    

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        maxTime = Random.Range(1f, 3f);
        enemyPowerText = GetComponentsInChildren<Text>()[0];
        enemyStateText = GetComponentsInChildren<Text>()[1];
        
    }

    void Update()
    {

        if (transform.position.x >= 2)
        {
            isAnim = true;
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        else
        {
            isAnim = false;
            UpdateUI();
        }
    }

    void UpdateUI()
    {

        if (isReady)
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
                maxTime = Random.Range(1f, 3f);
            }
        }

        if (enemyHpbar.fillAmount == 1)
        {
            isReady = false;
            AttackReady();
        }

        else if (enemyHpbar.fillAmount == 0)
        {
            isReady = true;

            if((isEnemyStab || isEnemySurpriseAttack) && !isInteract)
            {
                gameManager.PlayerDeath();
            }
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

                enemyStateText.text = "Stab";
                break;

            case 1:
                isEnemyStab = false;
                isEnemyShield = true;
                isEnemySurpriseAttack = false;

                enemyStateText.text = "Shield";
                break;

            case 2:
                isEnemyStab = false;
                isEnemyShield = false;
                isEnemySurpriseAttack = true;

                enemyStateText.text = "SurpriseAttack";
                break;

        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }

    public void StateChange()
    {
        enemyHpbar.fillAmount = 0;
        isInteract = true;
    }
}
