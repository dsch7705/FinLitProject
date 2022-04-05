using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxDayLerp : MonoBehaviour
{
    public float smooth;
    public bool lerpIn = false;

    Vector3 startPos;
    Vector3 midPos;

    public RectTransform panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<RectTransform>();
        startPos = transform.position;
        midPos = new Vector3(transform.position.x, Screen.height - Screen.height / 2, 0.0f);
    }

    private void Update()
    {
        if (lerpIn)
        {
            transform.position = Vector3.Lerp(transform.position, midPos, Time.deltaTime * smooth);
        }
    }
}
