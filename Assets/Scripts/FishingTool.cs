using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fish.tool 
{
    [CreateAssetMenu(fileName = "New FishTool", menuName = "Fish tool Object")]
    public class FishingTool : ScriptableObject
    {
        public string nameOfTool { get { return _nameOfTool; } }
        [SerializeField]
        private string _nameOfTool ="tool";
        public List<ToolRequired> ToolRequired { get { return _toolRequired; } }
        [SerializeField]
        private List<ToolRequired> _toolRequired = new List<ToolRequired>();
        // Start is called before the first frame update
        public float maxCastRange { get { return _maxCastRange; } }
        [SerializeField]
        private float _maxCastRange = 2;
        public float minCastRange { get { return _minCastRange; } }
        [SerializeField]
        private float _minCastRange = 1;
        public float castRangeMultiplier { get { return _castRangeMultiplier; } }
        [SerializeField]
        private float _castRangeMultiplier = 1;
        public float landingZoneMultiplier { get { return _landingZoneMultiplier; } }
        [SerializeField]
        private float _landingZoneMultiplier = 1;
        public float landingZoneMaxSize{ get { return _landingZoneMaxSize; } }
        [SerializeField]
        private float _landingZoneMaxSize = 1;
        public float landingZoneMinSize { get { return _landingZoneMinSize; } }
        [SerializeField]
        private float _landingZoneMinSize = 1;
        public float targetMultiplier { get { return _targetMultiplier; } }
        [SerializeField]
        private float _targetMultiplier = 1;
        public GameObject bobber { get { return _bobber; } }
        [SerializeField]
        private GameObject _bobber;
        public GameObject aim { get { return _aim; } }
        [SerializeField]
        private GameObject _aim;
        public GameObject target { get { return _target; } }
        [SerializeField]
        private GameObject _target;

        [System.Serializable]
   public enum distanceOptions
    { Distance1, Distance2, Distance3}

    public distanceOptions instanceOfEnumDistance;

        [System.Serializable]
        public enum accuracyOptions
        { Accuracy1, Accuracy2, Accuracy3, Accuracy4 }

        public accuracyOptions instanceOfEnumAccuracy;
    }
}
