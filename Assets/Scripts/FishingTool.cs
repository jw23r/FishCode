using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fish.tool 
{
    [CreateAssetMenu(fileName = "New FishTool", menuName = "Fish tool Object")]
    public class FishingTool : ScriptableObject
    {
        // Start is called before the first frame update
        public float maxCastRange { get { return _maxCastRange; } }
        [SerializeField]
        private int _maxCastRange = 2;
        public float minCastRange { get { return _minCastRange; } }
        [SerializeField]
        private int _minCastRange = 1;
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
