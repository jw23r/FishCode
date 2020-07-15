
	using UnityEngine;

	/// <summary>
	/// Monobehaviour singleton that will auto-generate an instance if one does not exist.
	/// </summary>
	public class MonoBehaviourSingletonAutoGenerating : MonoBehaviour
	{
		#region Properties
		/// <summary>
		/// Public singleton reference that can be accessed externally.
		/// </summary>
		static public MonoBehaviourSingletonAutoGenerating Instance
		{ 
			get
			{
				// If we don't have a singleton instance, then automatically create one now:
				if (_instance == null) _instance = new GameObject("Monohehaviour Singleton (Auto Generating)").AddComponent<MonoBehaviourSingletonAutoGenerating>();
				return _instance; 
			}
		}

		/// <summary>
		/// Static private reference to our singleton instance.
		/// </summary>
		static private MonoBehaviourSingletonAutoGenerating _instance = null;
		#endregion Properties (end)

		#region Initialization	
		private void Awake()
		{
			// Make sure we will only ever have one of these objects:
			if (_instance == null) _instance = this;
			else Destroy(this);
		}
		#endregion Initialization (end)

		public void LogSomeStuff()
		{
			Debug.Log("MonohehaviourSingletonAutoGenerating is logging some stuff!");
		}

		#region On Destroy
		private void OnDestroy()
		{
			// If we were the singleton, then clear the reference as we are being destroyed:
			if (_instance == this) _instance = null;
		}
		#endregion On Destroy (end)
	}

