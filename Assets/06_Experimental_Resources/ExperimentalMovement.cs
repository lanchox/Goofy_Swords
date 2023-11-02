using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ExperimentalMovement : MonoBehaviour
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
        PlayerMovement();
        PlayerRotation();
        SwordMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxisRaw("Horizontal") * speed;
        float ver = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = player.right * hor + player.forward * ver + new Vector3(0f, rb.velocity.y,0f);
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
