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
        StartCoroutine("Menu");
    }

    IEnumerator AddToGameEvents()
    {
        yield return new WaitForSeconds(0.5f);
        GameEvents.instance.OnTaxDay += OpenMenu;
    }

    IEnumerator Menu()
    {
        Debug.Log("YOOOO");
        TaxDayLerp.instance.lerpIn = true;
        yield return new WaitForSeconds(2.0f);
        TaxDayLerp.instance.lerpIn = false;
        yield return new WaitForSeconds(1.0f);
        taxScreen.SetActive(true);
        gameScreen.SetActive(false);
    }
}
