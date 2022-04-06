using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MundyLerp : MonoBehaviour
{
    public W2Handler w2;

    public float smooth;

    Vector3 startPos;
    Vector3 midPos;

    public bool mundyMove = false;

    void Start()
    {
        w2 = GetComponentInParent<W2Handler>();

        midPos = new Vector3(transform.position.x, Screen.height / 3 - Screen.height / 6, 0.0f);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (w2.fraudDetected)
        {
            transform.position = Vector3.Lerp(transform.position, midPos, Time.deltaTime * smooth);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * smooth);
        }
    }
}
