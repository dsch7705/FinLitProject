using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager manager;
    public float darkMoney = 0;
    public bool blackMarketPurchased = false;

    public float money = 0;
    public float grossMoney = 0;

    private void Start()
    {
        manager = this;
        grossMoney = money;
    }

    public void AddMoney(float amount)
    {
        grossMoney += amount;
        money += amount;
    }

    public void AddDarkMoney(float amount)
    {
        money += amount;
        darkMoney += amount;
    }

}
