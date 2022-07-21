using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isStab;
    public bool isShield; 
    public bool isSurpriseAttack;

    public int power;

    public void Stab()
    {
        isStab = true;
        isShield = false;
        isSurpriseAttack = false;
        Invoke("AllFalse", 2f);
    }

    public void Shield()
    {
        isShield = true;
        isSurpriseAttack = false;
        isStab = false;
        Invoke("AllFalse", 2f);
    }

    public void SurpriseAttack()
    {
        isSurpriseAttack = true;
        isShield = false;
        isStab = false;
        Invoke("AllFalse", 2f);
    }

    void AllFalse()
    {
        isSurpriseAttack = false;
        isShield = false;
        isStab = false;
    }
}
