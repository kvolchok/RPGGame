using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;
    private Camera _camera;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    private void Update()
    {
        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);
        
        // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
        if (!Input.GetMouseButtonDown(0)) return;
        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo)) return;
        var targetPoint = hitInfo.point;
        
        _destination = targetPoint;
    }
}