using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;
public class PlayerInputs : NetworkBehaviour
{
    private Rigidbody rbPelvis;
    private Transform pelvis;
    private MotionCamera cam;
    [SerializeField]private float speed, jumpForce;
    [SerializeField]private LayerMask layer;
    [SerializeField]private Transform fakeSword;
    [SerializeField] private bool isGrounded;
    private void Start()
    {
        rbPelvis = GetComponent<Rigidbody>();
        pelvis = GetComponent<Transform>();
        cam = GetComponentInChildren<MotionCamera>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerRotation();
        SwordMovement();
    }
    private void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal") * speed;
        float ver = Input.GetAxis("Vertical") * speed;
        rbPelvis.AddForce(pelvis.forward * ver + pelvis.right * hor, ForceMode.Force);
        isGrounded = Physics.Raycast(pelvis.position, pelvis.up * -1f, 1.01f,layer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rbPelvis.AddForce(pelvis.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void PlayerRotation()
    {
        if (cam.target != null)
        {
            Vector3 aPos = pelvis.position;
            Quaternion aRot = pelvis.rotation;
            Vector3 bPos = cam.target.position;
            Quaternion bRot = Quaternion.LookRotation(new Vector3(bPos.x, aPos.y, bPos.z) - aPos);
            pelvis.rotation = Quaternion.Slerp(aRot, bRot, cam.focusSlerp);
        }
    }
    void SwordMovement()
    {
        Vector3 m = Input.mousePosition;
        float xSync = Screen.width/3f;
        float ySync = Screen.height/3f;
        float hor = Mathf.Clamp((m.x / xSync) * 1.5f - 0.75f, -2f,2f);
        float ver = Mathf.Clamp((m.y / ySync) * 2f - 1f, -1f, 2f);
        fakeSword.position = pelvis.position + pelvis.right * hor + pelvis.up * ver + pelvis.forward * 1.5f;
    }
}

public class ClientAuthoritative : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
