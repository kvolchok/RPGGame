using Player;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (!otherCollider.CompareTag(GlobalConstants.PLAYER_TAG)) return;
        var playerController = otherCollider.GetComponent<PlayerController>();
        playerController.TakePotion();
        Destroy(gameObject);
    }
}