﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamtwo : MonoBehaviour
{
    public float distance = 5;
    Camera cam;
    public float scrollsensitivity = 1;
  

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var scroll = Input.mouseScrollDelta;
        distance += scroll.y * scrollsensitivity;
      
        Vector3 targetPos = new Vector3(0, -distance, 0);
        cam.transform.localPosition = AnimiMath.Dampen(cam.transform.localPosition, targetPos, .01f);
    }
}
