using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New RetrievalMethod", menuName = "Retrieval Method")]
public class RetrievalMethod : ScriptableObject
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum retrievalMethod
    { Instant, Constant, On,Off }

    public retrievalMethod instanceOfEnum;


}
