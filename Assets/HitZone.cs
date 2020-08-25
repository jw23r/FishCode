using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
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
        if (other.transform.tag == "LandingZone")
        {
            Casting.hitZone = "LandingZone";
            print(Casting.hitZone);
        }
        if (other.transform.tag == "Bull's-eye")
        {
            Casting.hitZone = "Bull's-eye";
            print(Casting.hitZone);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "LandingZone")
        {
            Casting.hitZone = "nothing";
            print(Casting.hitZone);

        }
    }
}
