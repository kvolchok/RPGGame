using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            Open();
        }
    }

    private void Open()
    {
        _animator.SetTrigger("open");
    }
}