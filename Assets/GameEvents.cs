using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    void Start()
    {
        instance = this;    
    }

    public event Action OnGameEventsReady;
    public void GameEventsReady()
    {
        if (OnGameEventsReady != null)
        {
            OnGameEventsReady();
        }
    }

    public event Action OnTaxDay;
    public void TaxDay()
    {
        if (OnTaxDay != null)
        {
            OnTaxDay();

        }
    }

    public event Action OnTaxMenuOpened;
    public void TaxMenuOpened()
    {
        if (OnTaxMenuOpened != null)
        {
            OnTaxMenuOpened();
        }
    }

    public event Action OnFraudDetected;
    public void FraudDetected()
    {
        if (OnFraudDetected != null)
        {
            OnFraudDetected();
        }
    }
}
