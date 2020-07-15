using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New FishDataObject", menuName = "Fish Data Object")]
public class FishDataObject : SingletonScriptableObject<FishDataObject>
{
    #region Properties
    public string FishNameTextField { get { return _fishNameTextField; } } // NOTE: We can protect this data field by only allowing public access to read it but not change it:
    [SerializeField]
    private string _fishNameTextField = string.Empty;

    //public int CoolIntField { get { return _coolIntField; } } // NOTE: We can protect this data field by only allowing public access to read it but not change it:
    //[SerializeField]
    //private int _coolIntField = 0;
    #endregion Properties (end)
    public List<BodyOfWaterType> BodyOfWaterType { get { return _bodyOfWaterType; } }
    [SerializeField]
    private List<BodyOfWaterType> _bodyOfWaterType = new List<BodyOfWaterType>();
    public List<TimeOfDay> TimeOfDay { get { return _timeOfDay; } }
    [SerializeField]
    private List<TimeOfDay> _timeOfDay = new List<TimeOfDay>();
    public List<ToolRequired> ToolRequired { get { return _toolRequired; } }
    [SerializeField]
    private List<ToolRequired> _toolRequired = new List<ToolRequired>();
    public List<CastingRange> CastingRange { get { return _castingRange; } }
    [SerializeField]
    private List<CastingRange> _castingRange = new List<CastingRange>();
    public List<Attractant> Attractant { get { return _attractant; } }
    [SerializeField]
    private List<Attractant> _attractant = new List<Attractant>();
    public List<EnticeMethod> EnticeMethod { get { return _enticeMethod; } }
    [SerializeField]
    private List<EnticeMethod> _enticeMethod = new List<EnticeMethod>();
    public List<RetrievalMethod> RetrievalMethod { get { return _retrievalMethod; } }
    [SerializeField]
    private List<RetrievalMethod> _retrievalMethod = new List<RetrievalMethod>();
    ScriptableObject water;

    private void OnValidate()
    {
        
        if (TimeOfDay.Count == 0) Debug.LogError("fish data object Must have TimeOfDay valeu of at lest one");
        if (ToolRequired.Count == 0) Debug.LogError("fish data object Must have ToolRequired valeu of at lest one");
        if (CastingRange.Count == 0) Debug.LogError("fish data object Must have CastingRange valeu of at lest one");
        if (Attractant.Count == 0) Debug.LogError("fish data object Must have Attractant valeu of at lest one");
        if (EnticeMethod.Count == 0) Debug.LogError("fish data object Must have EnticeMethod valeu of at lest one");
        if (RetrievalMethod.Count == 0) Debug.LogError("fish data object Must have RetrievalMethod valeu of at lest one");
        
        if (TimeOfDay.Count > 0)
        {
            if (TimeOfDay[0] == null) Debug.LogError(" TimeOfDay List Must Have a script in the list.");
        }
        if (ToolRequired.Count > 0)
        {
            if (ToolRequired[0] == null) Debug.LogError("ToolRequired Must Have a script in the list.");
        }
        if (CastingRange.Count > 0)
        {
            if (CastingRange[0] == null) Debug.LogError("CastingRange Must Have a script in the list.");
        }
        if (Attractant.Count > 0)
        {
            if (Attractant[0] == null) Debug.LogError("Attractant Must Have a script in the list.");
        }
        if (EnticeMethod.Count > 0)
        {
            if (EnticeMethod[0] == null) Debug.LogError("EnticeMethod Must Have a script in the list.");
        }
        if (RetrievalMethod.Count > 0)
        {
            if (RetrievalMethod[0] == null) Debug.LogError("RetrievalMethod Must Have a script in the list.");
        }
    }
    #region Initialization	
    public FishDataObject()
    {




    }
    #endregion Initialization (end)
}
