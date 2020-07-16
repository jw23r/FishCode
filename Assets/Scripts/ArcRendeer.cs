﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcRendeer : MonoBehaviour
{
    LineRenderer arc;
 

 
    public float velocity;
    public float angle;
    public int resolution = 10;
    private float _gravity;
    private float _radianAngle;
  

   
  private  Vector3 _mouseOnLeftClickPostion;

    #region Properties
    /// <summary>
    /// Static private reference to our singleton instance.
    /// </summary>
    static private ArcRendeer _instance = null;
    #endregion Properties (end)

    #region Initialization	
    private void Awake()
    {
        // Make sure we will only ever have one of these objects:
        if (_instance == null) _instance = this;
        else Destroy(this);
    }
    #endregion Initialization (end)

    static public void LogSomeStuff()
    {
        if (_instance) _instance.LogStuffToConsole();
        else Debug.LogWarning("Warning! MonobehaviourSingletonTucked.LogSomeStuff was called, but the instance is null!");
    }
    private void LogStuffToConsole()
    {
        Debug.Log("MonohehaviourSingletonAutoGenerating is logging some stuff!");
    }

    #region On Destroy
    private void OnDestroy()
    {
        // If we were the singleton, then clear the reference as we are being destroyed:
        if (_instance == this) _instance = null;
    }
    #endregion On Destroy (end)
    void OnValidate()
    {
        if(arc != null && Application.isPlaying)
        {
            RenderArc();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
   

    
        arc =  GetComponent<LineRenderer>();
        if (arc.enabled == true) arc.enabled = false;
        _gravity = Mathf.Abs (Physics.gravity.y);

       
    }
    private void Update()
    {
        velocity = Mathf.Clamp(velocity, .1f,10000);
        
        if (arc.enabled == true)
        {
            velocity = 1 + .05f * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (arc.enabled == false) arc.enabled = true;
            _mouseOnLeftClickPostion = Input.mousePosition;
            
        }
        RenderArc();
            if (Input.GetMouseButtonUp(0))
        {
            if (arc.enabled == true)
            {
                arc.enabled = false;
            }
        }

    }
    // Update is called once per frame
    void RenderArc()
    {
        arc.positionCount = (resolution + 1);
        arc.SetPositions(CalculateArcArray());
    }
    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        _radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * _radianAngle)) / _gravity;
        for(int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CaluclateArcPoint(t,maxDistance);
        }
        return arcArray;
    }
    Vector3 CaluclateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(_radianAngle) - ((_gravity * x * x) / (2 * velocity * velocity * Mathf.Cos(_radianAngle) * Mathf.Cos(_radianAngle)));
        return new Vector3(x, y);
    }

}
