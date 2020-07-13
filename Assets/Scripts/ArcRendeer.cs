using System.Collections;
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
        
        if (arc.enabled == true)
        {
            velocity = .05f * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
            print(velocity);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (arc.enabled == false) arc.enabled = true;
            _mouseOnLeftClickPostion = Input.mousePosition;
            
        }
        if (Input.GetMouseButton(0))
        {
            RenderArc();
        }
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
