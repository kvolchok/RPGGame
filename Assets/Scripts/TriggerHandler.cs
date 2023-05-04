using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private const string FIRE_TRIGGER_TAG = "FireTrigger";

    [SerializeField]
    private GameObject _fire;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag(FIRE_TRIGGER_TAG))
        {
            _fire.SetActive(true);
        }
    }
}