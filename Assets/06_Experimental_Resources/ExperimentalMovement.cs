using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ExperimentalMovement : MonoBehaviour
{
    float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 m = Input.mousePosition;
        float xSync = Screen.width / 3f;
        float ySync = Screen.height / 3f;
        float hor;
        float ver;
        if (Mathf.Round(m.x) < xSync)
        {
            hor = -0.75f;
        }
        else if (Mathf.Round(m.x) >  xSync * 2)
        {
            hor = 0.75f;
        }
        else
        {
            hor = (Input.mousePosition.x / Screen.width) * 1.5f - 0.75f;
        }
        if (Mathf.Round(m.y) < ySync)
        {
            ver = -1;
        }
        else if (Mathf.Round(m.y) >  ySync * 2)
        {
            ver = 1f;
        }
        else
        {
            ver = (Input.mousePosition.x / Screen.width) * 2f - 1f;
        }
        rb.velocity = Vector3.right * hor + Vector3.forward * ver + new Vector3(0f, rb.velocity.y, 0f);
    }
}
