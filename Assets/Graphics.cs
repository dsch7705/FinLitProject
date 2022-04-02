using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphics : MonoBehaviour
{
    public static Graphics graphics;

    public Image img;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        graphics = this;
        img = GetComponent<Image>();
    }

    public void UpdateBillGraphic(int i)
    {
        img.sprite = sprites[i];
    }
}
