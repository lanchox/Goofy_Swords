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
        if (NetworkManager.IsHost)
        {
            transform.position = new Vector3(-28.9f,12.99f,24.9f);
        }
        else
        {
            transform.position = new Vector3(-1.42f,16.6f,-21.9f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            float hor = Input.GetAxisRaw("Horizontal") * speed;
            float ver = Input.GetAxisRaw("Vertical") * speed;
            rb.velocity = new Vector3(hor, rb.velocity.y, ver);
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
