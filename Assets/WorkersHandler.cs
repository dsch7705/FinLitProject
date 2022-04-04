using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkersHandler : MonoBehaviour
{
    public static WorkersHandler handler;

    public float workerCost = 2000;
    public int workers = 0;

    public Text upgradeText;

    // Start is called before the first frame update
    void Start()
    {
        handler = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HireWorker()
    {
        if (MoneyManager.manager.money >= workerCost)
        {
            workers++;
            StartWork();

            MoneyManager.manager.money -= workerCost;
            workerCost = Mathf.Floor(Mathf.Pow(workerCost, 1.02f));
            Debug.Log(workerCost);
            upgradeText.text = "Hire Henchman - $" + workerCost.ToString("n0");

            Debug.Log("Hired new worker!");
        }
        else
        {
            Debug.Log("Not enough money to hire a worker!");
        }
    }

    void StartWork()
    {
        CancelInvoke();
        InvokeRepeating("Work", 0.0f, 1.0f / workers);
    }

    void Work()
    {
        MoneyManager.manager.AddMoney(BillManager.manager.bills[BillManager.manager.currentBill]);
    }
}
