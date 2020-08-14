using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsBodyOfWaterTyper : MonoBehaviour
{
    public List<BodyOfWaterType> objectsWaterType = new List<BodyOfWaterType>();
    string water;
    // Start is called before the first frame update
    void Start()
    {
        water = objectsWaterType[0].instanceOfEnum.ToString();
       // print(water);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Bobber")
        {
           
            Fishing.currentFishBodyOfWaterType = water;
            print("changed water type to " + Fishing.currentFishBodyOfWaterType);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Bobber")
        {
            Fishing.currentFishBodyOfWaterType = "nothing";
            print("your water is currently " + Fishing.currentFishBodyOfWaterType);
        }
    }
}
