using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillManager : MonoBehaviour
{
    public static BillManager manager;

    public Dictionary<int, int> bills = new Dictionary<int, int>();
    public Dictionary<int, int> upgradeCost = new Dictionary<int, int>();
    public int currentBill = 1;
    public int cost = 25;
    public Text upgradeText;

    // Start is called before the first frame update
    void Start()
    {
        manager = this;
        GameEvents.instance.OnTaxDay += TaxDay;

        PopulateBills();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeBill()
    {
        if (bills.Count - 1 > currentBill)
        {
            if (MoneyManager.manager.money >= upgradeCost[currentBill + 1])
            {
                currentBill++;
                MoneyManager.manager.money -= cost;
                Graphics.graphics.UpdateBillGraphic(currentBill - 1);

                cost = upgradeCost[currentBill + 1];
                upgradeText.text = string.Format("Increase Bill Denomination - ${0}", cost.ToString("n0"));
                Debug.Log("Bill upgraded to $" + bills[currentBill]);
            }
            else
            {
                Debug.Log("Not enough money!");
            }
        }
        else
        {
            Debug.Log("Max bill demonination reached!");
        }
    }

    public void BuyBlackMarket()
    {
        if (!MoneyManager.manager.blackMarketPurchased)
        {
            if (MoneyManager.manager.money >= 100000)
            {
                AddDarkMoney((MoneyManager.manager.money - 100000) * 2);

                MoneyManager.manager.blackMarketPurchased = true;
                MoneyManager.manager.money -= 100000;

                Debug.Log("Black Market Investments purchased.");
            }
            else
            {
                Debug.Log("Not enough money!");
            }
        }
        else
        {
            Debug.Log("Already purchased Black Market Investments!");
        }
    }

    public void AddMoney()
    {
        MoneyManager.manager.AddMoney(bills[currentBill]);
    }

    public void AddDarkMoney(float amount)
    {
        MoneyManager.manager.AddDarkMoney(amount);
    }

    public void TaxDay()
    {
        currentBill = 12;
    }

    void PopulateBills()
    {
        bills.Add(1, 1);
        bills.Add(2, 2);
        bills.Add(3, 5);
        bills.Add(4, 10);
        bills.Add(5, 20);
        bills.Add(6, 50);
        bills.Add(7, 100);
        bills.Add(8, 500);
        bills.Add(9, 1000);
        bills.Add(10, 5000);
        bills.Add(11, 10000);

        // Only for tax day
        bills.Add(12, 0);

        upgradeCost.Add(1, 0);
        upgradeCost.Add(2, 25);
        upgradeCost.Add(3, 100);
        upgradeCost.Add(4, 500);
        upgradeCost.Add(5, 1000);
        upgradeCost.Add(6, 2000);
        upgradeCost.Add(7, 20000);
        upgradeCost.Add(8, 100000);
        upgradeCost.Add(9, 500000);
        upgradeCost.Add(10, 1000000);
        upgradeCost.Add(11, 2000000);
    }
}
