using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New TimeOfDay", menuName = "Time Of Day")]
public class TimeOfDay : SingletonScriptableObject<TimeOfDay>
{
    // Start is called before the first frame update
    [System.Serializable]
    public enum timeOfDay
    { None, Any, Morning, Day, Evening, Night }

    public timeOfDay instanceOfEnum;


}

