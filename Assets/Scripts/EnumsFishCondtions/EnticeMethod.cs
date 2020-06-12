using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnticeMethod", menuName = "Entice Method ")]
public class EnticeMethod : ScriptableObject
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum enticeMethod
    { None, Any, Rhythmic, Random, Predictive }

    public enticeMethod instanceOfEnum;

}
