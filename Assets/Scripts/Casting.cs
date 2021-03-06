﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Casting : MonoBehaviour
{
    LineRenderer arc;
   public LineRenderer line;
    //public NewBehaviourScript fish;
   
   public GameObject timer;
    float x = 1;
    //Temp not using
    /*
    public GameObject d1;
    public GameObject d2;
    public GameObject d3;
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    */
  static  public string hitZone;
    private bool _goingDown = false;
    private  float time;
   
    bool change = false;
    bool maxsize;

    public Scrollbar powerBar;
   //public float powerBarSpeed;
    bool isReset = true;
    bool goingUp = true;
    bool casting = false;
    //public Dropdown optionsDistance;
   // public Dropdown optionsAccuracy;
   /* public Slider sizeMultiplier;
    public Slider distance1Multiplier;
    public Slider distance2Multiplier;

    public Slider distanceMultiplier;
    */
    public float sizes;
    public GameObject landingZone;
    public GameObject targetLandingZone;
    public GameObject aim;
    bool entice;
    public Fishing cast;
    public Fish.tool.FishingTool tool;
    public Transform playerPostion;
    public float velocity = 1;
    public float angle;
    public int resolution = 10;
    private float _gravity;
    private float _radianAngle;
   public Rigidbody aimBody;
    Vector3 _linePoints;
    Vector3 _playerLocation;
    Vector3 _noAccurcy;

    private Vector3 _mouseOnLeftClickPostion;

    #region Properties
    /// <summary>
    /// Static private reference to our singleton instance.
    /// </summary>
    static private Casting _instance = null;
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

        landingZone.SetActive(false);
        aim.SetActive(false);
        targetLandingZone.SetActive(false);
        timer.SetActive(false);
        arc.enabled = false;
       
    }
    private void Update()
    {
        //print(PlayerMovment.fishing);
        StopFishing();
        Fishhing();
        //print(_linePoints);
        //  inputfieldTOfloat(sizeMultiplier, sizes);
        // print(sizes);
        /*   if (Input.GetMouseButtonUp(0))
       {
           if (landingZone.activeSelf == true) landingZone.SetActive(false);

           //  Instantiate(landingZone, playerPostion.position + playerPostion.forward + _linePoints, playerPostion.rotation);
           if (arc.enabled == true)
           {
               arc.enabled = false;
           }
       }*/

    }

    private void Fishhing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerMovment.fishing = true;
            landingZone.SetActive(true);
        
            targetLandingZone.SetActive(true);
            timer.SetActive(true);
            arc.enabled = true;
            casting = true;

        }
        if(tool.instanceOfEnumAccuracy.ToString() != "Accuracy2")
        {
            targetLandingZone.transform.localScale = new Vector3(landingZone.transform.localScale.x / tool.targetMultiplier, 0.0918246f, landingZone.transform.localScale.z / tool.targetMultiplier);
            targetLandingZone.transform.position = line.GetPosition(1);
        }
        else
        {
            targetLandingZone.transform.localScale = new Vector3(timer.transform.localScale.x / tool.targetMultiplier, 0.0918246f, timer.transform.localScale.z / tool.targetMultiplier);
            targetLandingZone.transform.position =new Vector3(timer.transform.position.x, timer.transform.position.y + 0.05f, timer.transform.position.z);
        }
            CastLine();
            EnableArc();
            BoberMovment();
            CastingOptions();


            velocity = Mathf.Clamp(velocity, tool.minCastRange, tool.maxCastRange);
       

        RenderArc();
        
     }

    private void BoberMovment()
    {
        if (Input.GetMouseButton(0))
        {

            timer.transform.position = line.GetPosition(0);
            entice = true;
        }
        float speed = tool.timerSpeed * Time.deltaTime;

      
        if (!Input.GetMouseButton(0) && tool.instanceOfEnumAccuracy.ToString() == "Accuracy4")
        {
           // print("moving");
            aim.transform.position = Vector3.MoveTowards(aim.transform.position, _noAccurcy, speed);
            if (aim.transform.position == _noAccurcy && entice == true)
            {
                EnticeMethdod();
   

           

                entice = false;
            }
            }
        if (!Input.GetMouseButton(0) && tool.instanceOfEnumAccuracy.ToString() != "Accuracy3")
        {
            timer.transform.position = Vector3.MoveTowards(timer.transform.position, line.GetPosition(1), speed);
            if (timer.transform.position == line.GetPosition(1) && entice == true)
            {
                EnticeMethdod();
                
         
                entice = false;
            }
        }
        
    }

    private void RellingIn()
    {

        print("reeling in something");
    }
    private void Catch()
    {
        cast.CastAndFish();

    }
    private void StopFishing()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            casting = false;
            aimBody.velocity = Vector3.zero;
            landingZone.SetActive(false);
            aim.SetActive(false);
            targetLandingZone.SetActive(false);
            timer.SetActive(false);
            arc.enabled = false;
            PlayerMovment.fishing = false;

        }
    }
    private void EnticeMethdod()
    {
        print("we hit " + hitZone);
            print("were enticeing");
        landingZone.SetActive(false);
        aim.SetActive(false);
        targetLandingZone.SetActive(false);
        timer.SetActive(false);
        arc.enabled = false;
        if (casting == true)
        {
            RellingIn();
            Catch();
            PlayerMovment.fishing = false;
            landingZone.transform.localScale = new Vector3(2.07f, 0.074386f, 2.07f);
            casting = false;
        }


    }
    private void CastLine()
    {
        line.SetPosition(0, playerPostion.position);
        line.SetPosition(1, landingZone.transform.position);
    }

    private void EnableArc()
    {
        if (Input.GetMouseButtonDown(0) && casting == false)
        {
            //Instantiate(tool.aim);
            cast.CastAndFish();
            landingZone.transform.localScale = new Vector3(2.07f, 0.074386f, 2.07f);
            Debug.Log("Were casting");
            
            if (landingZone.activeSelf == false) landingZone.SetActive(true);
         
            if (arc.enabled == false) arc.enabled = true;
            _mouseOnLeftClickPostion = Input.mousePosition;

        }
    }

  
    private void inputfieldTOfloat(InputField text, float converter)
    {
        converter = float.Parse(text.ToString());
    }
    private void CastingOptions()
    {
       
        if (tool.instanceOfEnumDistance.ToString() == "Distance1")
        {
            
            DistanceCast1();
            //if (d1.activeSelf == false) d1.SetActive(true);
        }
        else
        {
            //if (d1.activeSelf == true) d1.SetActive(false);

        }
        if (tool.instanceOfEnumDistance.ToString() == "Distance2")
        {
            print("distance2Multiplier working");
            DistanceCast2();
          //  if (d2.activeSelf == false) d2.SetActive(true);
        }
        else
        {
            //if (d2.activeSelf == true) d2.SetActive(false);

        }
        if (tool.instanceOfEnumDistance.ToString() == "Distance3")
        {
            DistanceCast3();
          //  if (d3.activeSelf == false) d3.SetActive(true);
        }
        else
        {

           // if (d3.activeSelf == true) d3.SetActive(false);

        }
        if (tool.instanceOfEnumAccuracy.ToString() ==  "Accuracy1")
        {
            Accuracy1();
           // if (A1.activeSelf == false) A1.SetActive(true);

        }
        else
        {

            //if (A1.activeSelf == true) A1.SetActive(false);

        }
        if (tool.instanceOfEnumAccuracy.ToString() == "Accuracy2")
        {
            Accuracy2();
           // if (A2.activeSelf == false) A2.SetActive(true);

        }
        else
        {

         //   if (A2.activeSelf == true) A2.SetActive(false);

        }
        if (tool.instanceOfEnumAccuracy.ToString() == "Accuracy3")
        {
            Accuracy3();
            //if (A3.activeSelf == false) A3.SetActive(true);

        }
        else
        {

           // if (A3.activeSelf == true) A3.SetActive(false);

        }
        if (tool.instanceOfEnumAccuracy.ToString() == "Accuracy4")
        {
            Accuracy4();
           // if (A4.activeSelf == false) A4.SetActive(true);
        }
        else
        {

           // if (A4.activeSelf == true) A4.SetActive(false);

        }
    }

    void DistanceCast1()
    {
        if (arc.enabled == true && Input.GetMouseButton(0))
        {
            velocity = 1 + tool.castRangeMultiplier * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
            _linePoints = arc.GetPosition(resolution) + new Vector3(0, 0, 0); ;
            landingZone.transform.localPosition = _linePoints;
        }

    }
    void DistanceCast2()
    {
        if (arc.enabled == true && Input.GetMouseButton(0))
        {
            velocity = 1 + tool.castRangeMultiplier * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
            _linePoints = arc.GetPosition(resolution) + new Vector3(0, 0, 0); ;
            landingZone.transform.localPosition = _linePoints;
        float size = 1 + tool.landingZoneMultiplier * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
            size = Mathf.Clamp(size, tool.landingZoneMinSize, tool.landingZoneMaxSize);
            landingZone.transform.localScale = new Vector3(size, 0.0818246f, size);
        }
    }
    void DistanceCast3()
    {
        if (Input.GetKey("w") && powerBar.value < 1 && goingUp == true && Input.GetMouseButton(0) && isReset == true)
        {
        //    print("its going up");

            powerBar.value += tool.powerBarSpeed;
        }
        if (powerBar.value >= 1)
        {
            goingUp = false;
        }
        if (Input.GetKey("w") && goingUp == false && Input.GetMouseButton(0) && isReset == true)
        {
          //  print("its going down");

            powerBar.value -= tool.powerBarSpeed;
        }
        if (powerBar.value <= 0 && Input.GetMouseButton(0) && isReset == true)
        {
            goingUp = true;
        }
        if (Input.GetKeyUp("w") && Input.GetMouseButton(0) && isReset == true)
        {
         
            isReset = false;

        }
        if (arc.enabled == true && isReset == false)
        {
            velocity = 1 + powerBar.value * tool.castRangeMultiplier;
            _linePoints = arc.GetPosition(resolution) + new Vector3(0, 0, 0); ;
            landingZone.transform.localPosition = _linePoints;
        }
       
        if (Input.GetMouseButtonUp(0))
        {
            isReset = true;
        }

    }
    void Accuracy1()
    {

        //  if (bober.transform.position != line.GetPosition(1))
        //  {

        aimBody.AddForce(Input.GetAxis("Vertical") * transform.right * tool.forceApplied, ForceMode.Acceleration);
        aimBody.AddForce(Input.GetAxis("Horizontal") * transform.forward * -tool.forceApplied, ForceMode.Acceleration);
        // }
        if (Input.GetMouseButtonDown(0))
        {
            aimBody.velocity = new Vector3(0,0,0);
            aim.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0))
        {
       if (aim.activeSelf == false) aim.SetActive(true);
        if (aimBody.isKinematic == true) aimBody.isKinematic = false;
            aim.transform.parent = landingZone.transform;
            aim.transform.position = landingZone.transform.position + new Vector3(0,.3f,0);
            //print("im flying");
            aimBody.AddForce(Random.Range(-1f, 2), 0, Random.Range(-3f, 3), ForceMode.Impulse);
        }
    }
    void Accuracy2()
    {
        aimBody.AddForce(Input.GetAxis("Vertical") * transform.right * tool.forceApplied, ForceMode.Acceleration);
        aimBody.AddForce(Input.GetAxis("Horizontal") * transform.forward * -tool.forceApplied, ForceMode.Acceleration);

      
        if (Input.GetMouseButtonDown(0))
            aimBody.velocity = new Vector3(0,0,0);
        {
            aim.SetActive(false);
            aim.transform.parent = timer.transform;
            aim.transform.position = timer.transform.position + new Vector3(0, .2f, 0);
            //  aimBody.velocity = new Vector3(0,0,0);
        }
        if (Input.GetMouseButtonUp(0))
        {
        if (aim.activeSelf == false) aim.SetActive(true);
        if (aimBody.isKinematic == true) aimBody.isKinematic = false;
           
            aim.transform.parent = timer.transform;
            aim.transform.position = timer.transform.position;
            aimBody.AddForce(Random.Range(-tool.forceApplied, tool.forceApplied), 0, Random.Range(-tool.forceApplied, tool.forceApplied), ForceMode.Impulse);
        }
    }
    void Accuracy3()
    {
        if (Input.GetMouseButtonDown(0))
        {
        if (aim.activeSelf == false) aim.SetActive(true);

            if (aimBody.isKinematic == false) aimBody.isKinematic = true;
        

        }
       
        time -= Time.deltaTime;
      
           
        if (Input.GetMouseButton(0) && _goingDown == false && x < tool.landingZoneMaxSize )
        {
           // print("going up");
            
            x += tool.landingZoneMultiplier;

            landingZone.transform.localScale = new Vector3(x, landingZone.transform.localScale.y, x);
        }
        if(x >= tool.landingZoneMaxSize)
        {
            _goingDown = true;
        }
        if (Input.GetMouseButton(0) && _goingDown == true && x > tool.landingZoneMinSize)
        {
          //  print("going down");

            x -= tool.landingZoneMultiplier;
            landingZone.transform.localScale = new Vector3(x, landingZone.transform.localScale.y, x);
        }
        if(x <= tool.landingZoneMinSize)
        {
            _goingDown = false;
        }
        if (time <= 0 && Input.GetMouseButton(0))
        {
           change = true;
            time = tool.TimeBeforeSwitch;
        }
        else
        {
            change = false;
        }
        if (change == true)
        {
            aim.transform.position = new Vector3(line.GetPosition(1).x + Random.Range(-landingZone.transform.localScale.x/2, + landingZone.transform.localScale.x/2), line.GetPosition(1).y + .15f, line.GetPosition(1).z + Random.Range(-landingZone.transform.localScale.z/2,  landingZone.transform.localScale.z/2));
        }
        if (Input.GetMouseButtonUp(0))
        {
            EnticeMethdod();
        }
    }

    void Accuracy4()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aim.SetActive(false);




        }
        if (Input.GetMouseButton(0))
        {

            aim.transform.position = line.GetPosition(0);
            entice = true;
        }
        if (aim.activeSelf == true) aim.SetActive(false);
        if (Input.GetMouseButtonUp(0))
        {
            _noAccurcy = new Vector3(line.GetPosition(1).x + Random.Range(-aim.transform.localScale.x, aim.transform.localScale.x), line.GetPosition(1).y, line.GetPosition(1).z + Random.Range(-aim.transform.localScale.z, aim.transform.localScale.z));
         
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
