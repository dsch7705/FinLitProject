using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W2Handler : MonoBehaviour
{

    public Text wages;
    public Text fedTax;
    public Text socWages;
    public Text socTax;
    public Text medWages;
    public Text medTax;


    void Start()
    {
        GameEvents.instance.OnTaxMenuOpened += UpdateW2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UpdateW2();
    }

    public void UpdateW2()
    {
        wages.text = MoneyManager.manager.grossMoney.ToString();
        fedTax.text = (MoneyManager.manager.grossMoney * 0.37f).ToString();

        socWages.text = MoneyManager.manager.grossMoney.ToString();
        socTax.text = (MoneyManager.manager.grossMoney * 0.062f).ToString();

        medWages.text = MoneyManager.manager.grossMoney.ToString();
        medTax.text = (MoneyManager.manager.grossMoney * 0.0145f).ToString();
    }
}
