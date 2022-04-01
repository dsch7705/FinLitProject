using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager manager;
    public int money = 0;

    private void Start()
    {
        manager = this;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
