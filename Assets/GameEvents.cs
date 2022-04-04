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

    public event Action OnTaxDay;
    public void TaxDay()
    {
        if (OnTaxDay != null)
        {
            OnTaxDay();

        }
    }
}
