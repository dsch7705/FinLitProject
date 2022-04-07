using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W2Handler : MonoBehaviour
{

    public static W2Handler instance;

    public Text wages;
    public Text fedTax;
    public Text socWages;
    public Text socTax;
    public Text medWages;
    public Text medTax;

    public float taxPercentage;

    public bool fraudDetected = false;

    public GameObject goodWinScreen;

    void Start()
    {
        instance = this;
        GameEvents.instance.OnTaxMenuOpened += UpdateW2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SetTaxBracket();
        UpdateW2();
    }

    public void SetTaxBracket()
    {
        float money = MoneyManager.manager.grossMoney;
        switch (money)
        {
            case var _ when money <= 9950:
                taxPercentage = 0.10f;
                break;
            case var _ when money <= 40525:
                taxPercentage = 0.12f;
                break;
            case var _ when money <= 86375:
                taxPercentage = 0.22f;
                break;
            case var _ when money <= 164925:
                taxPercentage = 0.24f;
                break;
            case var _ when money <= 209425:
                taxPercentage = 0.32f;
                break;
            case var _ when money <= 523600:
                taxPercentage = 0.35f;
                break;
            case var _ when money > 523600:
                taxPercentage = 0.37f;
                break;
        }
    }

    public float GenerateTaxBracket(int i)
    {
        float tax = 0;
        switch(i)
        {
            case 1:
                tax = 0.10f;
                break;
            case 2:
                tax = 0.12f;
                break;
            case 3:
                tax = 0.22f;
                break;
            case 4:
                tax = 0.24f;
                break;
            case 5:
                tax = 0.32f;
                break;
            case 6:
                tax = 0.35f;
                break;
            case 7:
                tax = 0.37f;
                break;
        }
        return tax;
    }

    public void UpdateW2()
    {
        float money = MoneyManager.manager.grossMoney;
        float darkMoney = MoneyManager.manager.darkMoney;

        CalculateErrorChance();

        wages.text = (money + darkMoney).ToString("#0");
        if (fraudDetected) 
        { 
            fedTax.text = (money * taxPercentage).ToString("#0");
            Debug.Log("Fraud Detected");
        }
        else 
        { 
            fedTax.text = ((money + darkMoney) * taxPercentage).ToString("#0");
            goodWinScreen.SetActive(true);
        }

        socWages.text = (money + darkMoney).ToString("#0");
        socTax.text = ((money + darkMoney) * 0.062f).ToString("#0");

        medWages.text = (money + darkMoney).ToString("#0");
        medTax.text = ((money + darkMoney) * 0.0145f).ToString("#0");
    }

    public void CalculateErrorChance()
    {
        float rand = Random.value;

        if (rand < BillManager.manager.blackMarketTimesBought * 0.28f)
        {
            fraudDetected = true;
            GameEvents.instance.FraudDetected();
        }
        Debug.Log(BillManager.manager.blackMarketTimesBought * 0.28f);
        Debug.Log(rand);
    }
}
