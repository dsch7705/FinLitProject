using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager manager;
    public float money = 0;

    private void Start()
    {
        manager = this;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

}
