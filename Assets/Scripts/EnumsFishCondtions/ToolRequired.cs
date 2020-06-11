using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New ToolRequired", menuName = "Tool Required")]
public class ToolRequired : ScriptableObject
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum toolRequired
    { None, Any, Rod, Spear }

    public toolRequired instanceOfEnum;


}
