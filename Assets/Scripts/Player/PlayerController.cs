using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public bool HasBridgeBreakingProtection { get; private set; }

        [SerializeField]
        private float _highlightIntensity = 2;
        
        private Outline _outline;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
        }

        public void TakePotion()
        {
            _outline.OutlineWidth = _highlightIntensity;
            HasBridgeBreakingProtection = true;
        }
    }
}