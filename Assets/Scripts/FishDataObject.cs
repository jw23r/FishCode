using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FishDataObject", menuName = "Fish Data Object")]
public class FishDataObject : ScriptableObject
{
	#region Properties
	public string FishNameTextField { get { return _fishNameTextField; } } // NOTE: We can protect this data field by only allowing public access to read it but not change it:
	[SerializeField]
	private string _fishNameTextField = string.Empty;

	//public int CoolIntField { get { return _coolIntField; } } // NOTE: We can protect this data field by only allowing public access to read it but not change it:
	//[SerializeField]
	//private int _coolIntField = 0;
	#endregion Properties (end)
	public List<BodyOfWaterType> BodyOfWaterType = new List<BodyOfWaterType>();
	
	#region Initialization	
	public FishDataObject()
	{
 
	}
	#endregion Initialization (end)
}
