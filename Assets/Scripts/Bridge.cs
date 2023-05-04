using Player;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    
    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (!otherCollider.CompareTag(GlobalConstants.PLAYER_TAG)) return;
        var playerController = otherCollider.GetComponent<PlayerController>();
        if (!playerController.HasBridgeBreakingProtection)
        {
            Break();
        }
    }

    private void Break()
    {
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;
        
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;
            
            // Придаем силу каждому rigidbody.
            rigidbody.AddForce(direction * forceValue);
        }
    }
}