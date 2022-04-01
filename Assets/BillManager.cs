using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillManager : MonoBehaviour
{
    Dictionary<int, int> bills = new Dictionary<int, int>();
    Dictionary<int, int> upgradeCost = new Dictionary<int, int>();
    public int currentBill = 1;
    public int cost = 100;

    // Start is called before the first frame update
    void Start()
    {
        PopulateBills();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeBill()
    {
        if (MoneyManager.manager.money >= upgradeCost[currentBill + 1])
        {
            currentBill++;
            Debug.Log("Bill upgraded to $" + bills[currentBill]);
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    public void AddMoney()
    {
        MoneyManager.manager.AddMoney(bills[currentBill]);
    }

    void PopulateBills()
    {
        bills.Add(1, 1);
        bills.Add(2, 5);
        bills.Add(3, 10);
        bills.Add(4, 20);
        bills.Add(5, 50);
        bills.Add(6, 100);

        upgradeCost.Add(1, 0);
        upgradeCost.Add(2, 100);
        upgradeCost.Add(3, 500);
        upgradeCost.Add(4, 1000);
        upgradeCost.Add(5, 2000);
        upgradeCost.Add(6, 50000);
    }
}
