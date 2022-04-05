using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxScreen : MonoBehaviour
{
    public GameObject taxScreen;
    public GameObject gameScreen;

    void Start()
    {
        StartCoroutine("AddToGameEvents");
    }

    public void OpenMenu()
    {
        taxScreen.SetActive(true);
        gameScreen.SetActive(false);
    }

    IEnumerator AddToGameEvents()
    {
        yield return new WaitForSeconds(0.5f);
        GameEvents.instance.OnTaxDay += OpenMenu;
    }
}
