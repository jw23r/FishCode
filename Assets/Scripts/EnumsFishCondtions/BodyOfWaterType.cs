using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BodyOfWwaterType", menuName = "Body of water Type")]
public class BodyOfWaterType : SingletonScriptableObject<BodyOfWaterType>  
{
    // Start is called before the first frame update
    [System.Serializable]
   public  enum bodyOfWaterType
    { None, Any, Ocean, Lake, Pond, Stream }

    public bodyOfWaterType instanceOfEnum;
 




}



