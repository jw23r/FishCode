using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fish.tool 
{
    [CreateAssetMenu(fileName = "New FishTool", menuName = "Fish tool Object")]
    public class FishingTool : ScriptableObject
    {
        public string nameOfTool { get { return _nameOfTool; } }
        [Tooltip("sets what the tool is called.")]
        [SerializeField]
        private string _nameOfTool ="tool";
        public float timerSpeed { get { return _timerSpeed; } }
        [Tooltip("how fast the timer meets its target")]
        [SerializeField]
        private float _timerSpeed = 2;
        public float powerBarSpeed { get { return _powerBarSpeed; } }
        [Tooltip("speed of up and down on powerbar")]
        [SerializeField]
        private float _powerBarSpeed = 0.01f;
     
        public float forceApplied { get { return _forceApplied; } }
        [SerializeField]
        [Tooltip("force added to aim at start of cast random float from -x to x")]
        private float _forceApplied = 1f;
        public float bobberMovment { get { return _bobberMovment; } }
        [SerializeField]
        [Tooltip("amount of force aded when using WASD")]
        private float _bobberMovment = .02f;
        public float maxCastRange { get { return _maxCastRange; } }
        [SerializeField]
        [Tooltip("furthest distance you can cast")]
        private float _maxCastRange = 2;
        public float minCastRange { get { return _minCastRange; } }
        [SerializeField]
        [Tooltip("closest distance you can cast")]
        private float _minCastRange = 1;
        public float castRangeMultiplier { get { return _castRangeMultiplier; } }
        [SerializeField]
        [Tooltip("multiply's how far u will cast")]
        private float _castRangeMultiplier = 1;
        public float landingZoneMultiplier { get { return _landingZoneMultiplier; } }
        [SerializeField]
        [Tooltip("the amout of size added to the landing zone")]
        private float _landingZoneMultiplier = 1;
        public float landingZoneMaxSize{ get { return _landingZoneMaxSize; } }
        [SerializeField]
        [Tooltip("largest size landing zone can become")]

        private float _landingZoneMaxSize = 1;
        public float landingZoneMinSize { get { return _landingZoneMinSize; } }
        [SerializeField]
        [Tooltip("smalest size landing zone can become")]

        private float _landingZoneMinSize = 1;
        public float targetMultiplier { get { return _targetMultiplier; } }
        [SerializeField]
        [Tooltip("float that divides the target size by current parent size ")]

        private float _targetMultiplier = 2.5f;
        public GameObject bobber { get { return _bobber; } }
        [SerializeField]
        [Tooltip("not being used")]

        private GameObject _bobber;
        public GameObject aim { get { return _aim; } }
        [SerializeField]
        [Tooltip("not being used")]

        private GameObject _aim;
        public GameObject target { get { return _target; } }
        [SerializeField]
        [Tooltip("not being used")]
        private GameObject _target;

        [System.Serializable]
   public enum distanceOptions
    { Distance1, Distance2, Distance3}
        [Tooltip("changes distance methdod")]
        public distanceOptions instanceOfEnumDistance;

        [System.Serializable]
        public enum accuracyOptions
        { Accuracy1, Accuracy2, Accuracy3, Accuracy4 }
        [Tooltip("changes accuracy methdod")]

        public accuracyOptions instanceOfEnumAccuracy;
    }
}
