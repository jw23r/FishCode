using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    bool landingZone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "LandingZone" )
        {
            landingZone = true;
            //  print(Casting.hitZone);
        }
        if (other.transform.tag == "LandingZone" && Casting.hitZone != "Bull's-eye")
        {
            Casting.hitZone = "LandingZone";
          //  print(Casting.hitZone);
        }
        if (other.transform.tag == "Bull's-eye")
        {
            Casting.hitZone = "Bull's-eye";
           // print(Casting.hitZone);

        }
    }
    private void OnTriggerExit(Collider other)
    {


        if (other.transform.tag == "Bull's-eye" && landingZone == false)
        {
            Casting.hitZone = "nothing";
            //    print(Casting.hitZone);

        }

        if (other.transform.tag == "LandingZone")
        {
            landingZone = false;
            Casting.hitZone = "nothing";
        //    print(Casting.hitZone);

        }
    }
}
