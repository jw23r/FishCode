using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Attractant", menuName = "Attractant ")]
public class Attractant : SingletonScriptableObject<Attractant>
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum attractant
    { None, Any, Lure, Living }

    public attractant instanceOfEnum;


}
