using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcRendeer : MonoBehaviour
{
    LineRenderer arc;
   public LineRenderer line;

    public GameObject menue;
   public GameObject bober;
    public GameObject d1;
    public GameObject d2;
    public GameObject d3;
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    private  float time;
    public GameObject camrea1;
    public GameObject camrea2;




    public Scrollbar powerBar;
    public float powerBarSpeed;
    bool isReset = true;
    bool goingUp = true;
    public Dropdown optionsDistance;
    public Dropdown optionsAccuracy;
    public Slider sizeMultiplier;
    public Slider distance1Multiplier;
    public Slider distance2Multiplier;

    public Slider distanceMultiplier;

    public float sizes;
    public GameObject landingZone;
    public GameObject targetLandingZone;
    public GameObject aim;


    public Transform playerPostion;
    public float velocity;
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
        targetLandingZone.transform.localScale = new Vector3(landingZone.transform.localScale.x/2.5f, 0.0918246f, landingZone.transform.localScale.z/2.5f);
        targetLandingZone.transform.position = line.GetPosition(1);
        CastLine();
        EnableArc();
       BoberMovment();
        CastingOptions();

        //print(_linePoints);
        //  inputfieldTOfloat(sizeMultiplier, sizes);
        // print(sizes);

        velocity = Mathf.Clamp(velocity, .1f, 10000);

        RenderArc();
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

    private void BoberMovment()
    {
        if (Input.GetMouseButton(0))
        {
            bober.transform.position = line.GetPosition(0);
        }
        float speed = 1 * Time.deltaTime;

      
        if (!Input.GetMouseButton(0) && optionsAccuracy.value == 3)
        {
            bober.transform.position = Vector3.MoveTowards(bober.transform.position, _noAccurcy, speed);
           
            }
        if (!Input.GetMouseButton(0) && optionsAccuracy.value != 3)
        {
            bober.transform.position = Vector3.MoveTowards(bober.transform.position, line.GetPosition(1), speed);

        }
    }

    private void CastLine()
    {
        line.SetPosition(0, playerPostion.position);
        line.SetPosition(1, landingZone.transform.position);
    }

    private void EnableArc()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (landingZone.activeSelf == false) landingZone.SetActive(true);
         
            if (arc.enabled == false) arc.enabled = true;
            _mouseOnLeftClickPostion = Input.mousePosition;

        }
    }

    public  void OpenMenue()
    {
        if (menue.activeSelf == true)
        {
            menue.SetActive(false);
        }
        else
        {
            menue.SetActive(true);
        }
    }
    public void ChangeCamera()
    {
        if (camrea1.activeSelf == true)
        {
            camrea1.SetActive(false);
            if (camrea2.activeSelf == false) camrea2.SetActive(true);
        }
        else
        {
            if (camrea2.activeSelf == true)
            {
                camrea2.SetActive(false);
                if (camrea1.activeSelf == false) camrea1.SetActive(true);

            }
        }
    }
    private void inputfieldTOfloat(InputField text, float converter)
    {
        converter = float.Parse(text.ToString());
    }
    private void CastingOptions()
    {
       
        if (optionsDistance.value == 0)
        {
            DistanceCast1();
            if (d1.activeSelf == false) d1.SetActive(true);
        }
        else
        {
            if (d1.activeSelf == true) d1.SetActive(false);

        }
        if (optionsDistance.value == 1)
        {
            DistanceCast2();
            if (d2.activeSelf == false) d2.SetActive(true);
        }
        else
        {
            if (d2.activeSelf == true) d2.SetActive(false);

        }
        if (optionsDistance.value == 2)
        {
            DistanceCast3();
            if (d3.activeSelf == false) d3.SetActive(true);
        }
        else
        {

            if (d3.activeSelf == true) d3.SetActive(false);

        }
        if (optionsAccuracy.value == 0)
        {
            Accuracy1();
            if (A1.activeSelf == false) A1.SetActive(true);

        }
        else
        {

            if (A1.activeSelf == true) A1.SetActive(false);

        }
        if (optionsAccuracy.value == 1)
        {
            Accuracy2();
            if (A2.activeSelf == false) A2.SetActive(true);

        }
        else
        {

            if (A2.activeSelf == true) A2.SetActive(false);

        }
        if (optionsAccuracy.value == 2)
        {
            Accuracy3();
            if (A3.activeSelf == false) A3.SetActive(true);

        }
        else
        {

            if (A3.activeSelf == true) A3.SetActive(false);

        }
        if (optionsAccuracy.value == 3)
        {
            Accuracy4();
            if (A4.activeSelf == false) A4.SetActive(true);
        }
        else
        {

            if (A4.activeSelf == true) A4.SetActive(false);

        }
    }

    void DistanceCast1()
    {
        if (arc.enabled == true && Input.GetMouseButton(0))
        {
            velocity = 1 + distance1Multiplier.value * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
            _linePoints = arc.GetPosition(resolution) + new Vector3(0, 0, 0); ;
            landingZone.transform.localPosition = _linePoints;
        }

    }
    void DistanceCast2()
    {
        if (arc.enabled == true && Input.GetMouseButton(0))
        {
            velocity = 1 + distance2Multiplier.value * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
            _linePoints = arc.GetPosition(resolution) + new Vector3(0, 0, 0); ;
            landingZone.transform.localPosition = _linePoints;
        float size = 1 + sizeMultiplier.value * Mathf.Abs(Input.mousePosition.y - _mouseOnLeftClickPostion.y);
        landingZone.transform.localScale = new Vector3(size, 0.0818246f, size);
        }
    }
    void DistanceCast3()
    {
        if (Input.GetKey("w") && powerBar.value < 1 && goingUp == true && Input.GetMouseButton(0) && isReset == true)
        {
        //    print("its going up");

            powerBar.value += powerBarSpeed;
        }
        if (powerBar.value >= 1)
        {
            goingUp = false;
        }
        if (Input.GetKey("w") && goingUp == false && Input.GetMouseButton(0) && isReset == true)
        {
          //  print("its going down");

            powerBar.value -= powerBarSpeed;
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
            velocity = 1 + powerBar.value * distanceMultiplier.value;
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
        if (aim.activeSelf == false) aim.SetActive(true);
        if (aimBody.isKinematic == false) aimBody.isKinematic = true;

        //  if (bober.transform.position != line.GetPosition(1))
        //  {
        aimBody.AddForce(Input.GetAxis("Vertical") * transform.right * 1.1f);
            aimBody.AddForce(Input.GetAxis("Horizontal") * transform.forward * 1.1f);
       // }
        if (Input.GetMouseButtonDown(0))
        {
            aim.transform.parent = landingZone.transform;
            aim.transform.position = landingZone.transform.position + new Vector3(0,.2f,0);
          //  aimBody.velocity = new Vector3(0,0,0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            aimBody.AddForce(Random.Range(-3f, 3), 0, Random.Range(-3f, 3), ForceMode.Impulse);
        }
    }
    void Accuracy2()
    {
        if (aim.activeSelf == false) aim.SetActive(true);
        if (aimBody.isKinematic == false) aimBody.isKinematic = true;

        if (Input.GetMouseButtonDown(0))
        {
            aim.transform.parent = bober.transform;
            aim.transform.position = bober.transform.position;
        }
        if (Input.GetMouseButtonDown(0))
        {
            aim.transform.parent = landingZone.transform;
            aim.transform.position = landingZone.transform.position + new Vector3(0, .2f, 0);
            //  aimBody.velocity = new Vector3(0,0,0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            aimBody.AddForce(Random.Range(-3f, 3), 0, Random.Range(-3f, 3), ForceMode.Impulse);
        }
    }
    void Accuracy3()
    {
        if (aim.activeSelf == false) aim.SetActive(true);
       if(aimBody.isKinematic == false) aimBody.isKinematic = true;
        time += Time.deltaTime;
        print(time);
        if(time >= 60 && !Input.GetMouseButton(0))
;        {
            aim.transform.position = new Vector3(line.GetPosition(1).x + Random.Range(-bober.transform.localScale.x, bober.transform.localScale.x), line.GetPosition(1).y, line.GetPosition(1).z + Random.Range(-bober.transform.localScale.z, bober.transform.localScale.z));
            time = 0;
        }
    }
    void Accuracy4()
    {

       if(aim.activeSelf == true) aim.SetActive(false);
        if (Input.GetMouseButtonUp(0))
        {
            _noAccurcy = new Vector3(line.GetPosition(1).x + Random.Range(-bober.transform.localScale.x, bober.transform.localScale.x), line.GetPosition(1).y, line.GetPosition(1).z + Random.Range(-bober.transform.localScale.z, bober.transform.localScale.z));
         
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
