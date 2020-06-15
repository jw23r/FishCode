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
        if(other.transform.tag == "Player")
        {
            Fishing.currentFishBodyOfWaterType = water;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Fishing.currentFishBodyOfWaterType = "There is No Water";
        }
    }
}
