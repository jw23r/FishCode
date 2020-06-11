using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractant : ScriptableObject
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum attractant
    { None, Any, Lure, Living }

    public attractant instanceOfEnum;


}
