using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private const string CHEST_TAG = "Chest";
    private const string POTION_TAG = "Potion";
    private const string FIRE_TRIGGER_TAG = "FireTrigger";

    public event Action OnPotionPickedUp;

    [SerializeField]
    private GameObject _fire;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag(CHEST_TAG))
        {
            var chest = otherCollider.GetComponent<Chest>();
            chest.Open();
        }

        if (otherCollider.CompareTag(POTION_TAG))
        {
            var potion = otherCollider.GetComponent<Outline>();
            Destroy(potion.gameObject);
            
            var playerOutline = GetComponent<Outline>();
            playerOutline.OutlineWidth = 2;

            OnPotionPickedUp?.Invoke();
        }
        
        if (otherCollider.CompareTag(FIRE_TRIGGER_TAG))
        {
            _fire.SetActive(true);
        }
    }
}