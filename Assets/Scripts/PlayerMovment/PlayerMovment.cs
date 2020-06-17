﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 5;
    public OrbitCam theCam;
    CharacterController body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       float h = Input.GetAxis("Horizontal");
        float v =Input.GetAxis("Vertical");
        if(v != 0 && theCam != null)
        {
            Quaternion targetRot  = Quaternion.Euler(0, theCam.yaw, 0);
            transform.rotation = AnimiMath.Dampen(transform.rotation, targetRot, .01f);
        }
        Vector3 moveDis = transform.forward * v * moveSpeed;
        moveDis += transform.right * h * moveSpeed;
        body.SimpleMove(moveDis);
    }
}