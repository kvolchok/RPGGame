using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject _fire;
    
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            _fire.SetActive(true);
        }
    }
}