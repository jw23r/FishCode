using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New CastingRange", menuName = "Casting Range ")]
public class CastingRange : SingletonScriptableObject<CastingRange>
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum castingRange
    { Close, Far }

    public castingRange instanceOfEnum;


}