using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int power;
    Enemy enemy;
    Text powerText;

    void Start()
    {
        powerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        powerText.text = "ÀüÅõ·Â : " + power;
    }
}
