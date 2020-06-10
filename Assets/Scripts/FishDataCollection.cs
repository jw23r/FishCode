using UnityEngine;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[CreateAssetMenu(fileName = "New FishDataCollection", menuName = "Fish Data Collection")]
public class FishDataCollection : ScriptableObject
{
    #region Properties
    public ReadOnlyCollection<FishDataObject> FishDataObjects { get { return _fishDataObjects.AsReadOnly(); } } // NOTE: We can protect this data field by only allowing public access to a read only collection:
    [SerializeField]
    private List<FishDataObject> _fishDataObjects = new List<FishDataObject>();
    #endregion Properties (end)

    #region Initialization	
    public FishDataCollection()
    {

    }
    #endregion Initialization (end)

    #region Editor Methods
#if UNITY_EDITOR // NOTE: because we are referencing UnityEditor.EditorUtility here, we need to wrap the method in the UNITY_EDITOR so we won't get compiler errors
    public void SetDataObjectList(List<FishDataObject> dataObjectList)
    {
        // Store this new list of objects:
        _fishDataObjects = new List<FishDataObject>(dataObjectList);

        // Manually call SetDirty to tell Unity that this object was changed:
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
    #endregion Editor Methods (end)
}
