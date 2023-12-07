using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MotionCamera : MonoBehaviour
{
    public Transform camPivot;
    public float focusSlerp;
    public Transform target;
    void Start()
    {
        camPivot = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 aPos = camPivot.position;
            Quaternion aRot = camPivot.rotation;
            Vector3 bPos = target.position;
            Quaternion bRot = Quaternion.LookRotation(bPos-aPos);
            camPivot.rotation = Quaternion.Slerp(aRot, bRot, focusSlerp);
        }
    }
}
