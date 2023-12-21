using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;
public class PlayerInputs : NetworkBehaviour
{
    private Rigidbody rb;
    private Transform player;
    private MotionCamera cam;
    private Camera thisCam;
    [SerializeField]private float speed, hor, ver;
    [SerializeField]private GameObject fakeSword;
    [SerializeField] private bool isGrounded;
    private void Start()
    {
        if (IsOwner)
        {
            thisCam = GetComponentInChildren<Camera>();
            rb = GetComponent<Rigidbody>();
            player = GetComponent<Transform>();
            cam = GetComponentInChildren<MotionCamera>();
        }
    }

    private void Update()
    {
        if (IsOwner)
        {
            PlayerMovement();
            PlayerRotation();
            SwordMovement();
        }
        else
        {
            thisCam.enabled = false;
        }
    }
    private void PlayerMovement()
    {
        hor = Input.GetAxis("Horizontal") * speed;
        ver = Input.GetAxis("Vertical") * speed;
        rb.AddForce(player.forward * ver + player.right * hor, ForceMode.Force);
    }
    private void PlayerRotation()
    {
        if (cam.target != null)
        {
            Vector3 aPos = player.position;
            Vector3 bPos = cam.target.position;
            Vector3 final = bPos - aPos;
            final.y = 0f;
            Quaternion yRot = Quaternion.LookRotation(final);
            player.rotation = Quaternion.Slerp(player.rotation,yRot, cam.focusSlerp);
        }
    }
    void SwordMovement()
    {
        Vector3 m = Input.mousePosition;
        float xSync = Screen.width/3f;
        float ySync = Screen.height/3f;
        float xPos = Mathf.Clamp((m.x / xSync) * 1.5f - 0.75f, -2f,2f);
        float yPos = Mathf.Clamp((m.y / ySync) * 2f - 1f, -1f, 2.5f);
        fakeSword.transform.position = player.position + player.right * xPos + player.up * yPos + player.forward * 1.5f;
    }
}
