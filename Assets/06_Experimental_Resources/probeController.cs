using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class probeController : NetworkBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    [SerializeField] Camera cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (NetworkManager.IsHost)
        {
            transform.position = new Vector3(0f,12.99f,24.9f);
        }
        if(NetworkManager.IsClient)
        {
            transform.position = new Vector3(0f,12.99f,-7.4f);
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
        else if(cam.enabled)
        {
            cam.enabled = false;
        }
    }
}
