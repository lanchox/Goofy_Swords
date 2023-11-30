using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class probeController : NetworkBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            float hor = Input.GetAxisRaw("Horizontal") * speed;
            float ver = Input.GetAxisRaw("Vertical") * speed;
            rb.AddForce(new Vector3(hor, 0f, ver));
        }
    }
}
public class ProbeClient : NetworkTransform 
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
