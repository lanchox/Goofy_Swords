using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;



public class PlayerMovement : NetworkBehaviour
{
    private Rigidbody rb;
    [SerializeField]private Transform player, sword;
    private MotionCamera cam;
    [SerializeField]private float speed;
    private void Start()
    {
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<MotionCamera>();
    }

    private void Update()
    {
        PlayerMotion();
        PlayerRotation();
        SwordMovement();
    }

    void PlayerMotion()
    {
        float hor = Input.GetAxisRaw("Horizontal") * speed;
        float ver = Input.GetAxisRaw("Vertical") * speed;
        rb.AddForce(hor * player.right + ver * player.forward, ForceMode.Force);
    }

    void PlayerRotation()
    {
        if (cam.target != null)
        {
            Vector3 aPos = player.position;
            Quaternion aRot = player.rotation;
            Vector3 bPos = cam.target.position;
            Quaternion bRot = Quaternion.LookRotation(new Vector3(bPos.x, aPos.y, bPos.z) - aPos);
            player.rotation = Quaternion.Slerp(aRot, bRot, cam.focusSlerp);
        }
    }
    void SwordMovement()
    {
        Vector3 m = Input.mousePosition;
        float xSync = Screen.width/3f;
        float ySync = Screen.height/3f;
        float hor = Mathf.Clamp((m.x / xSync) * 1.5f - 0.75f, -2f,2f);
        float ver = Mathf.Clamp((m.y / ySync) * 2f - 1f, -1f, 2f);
        sword.position = player.position + player.right * hor + player.up * ver + player.forward * 1.5f;
    }

}

public class clienta : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
