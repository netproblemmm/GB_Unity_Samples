using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Ghost_patrol : MonoBehaviour
{
    private string _playerTag = "John";
    [SerializeField] private float _distanceForPursuit = 3.5f;
    [SerializeField] private bool _isInPursuit = false;
    private float DistanceForPursuitSQR => _distanceForPursuit * _distanceForPursuit;

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    private int m_CurrentWaypointIndex;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if(IsPlayerTooClose() && !IsHaveObstacleBetween())
        {
            _isInPursuit = true;
        }
        else
        {
            _isInPursuit = false;
        }

    }
    private void LateUpdate()
    {
        if (_isInPursuit)
        {
            //navMeshAgent.SetDestination(_player.transform.position);
        }
        else
        {
            var isCurrentDestinationInWaypoints =
                (from t in waypoints
                 where t.position == navMeshAgent.destination
                 select t.position).Count() == 1;

            if (!isCurrentDestinationInWaypoints)
            {
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            else
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
        }
    }

    private bool IsHaveObstacleBetween()
    {
        var hitDirection = (_player.transform.position - transform.position).normalized;
        var realDistance = _distanceForPursuit;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, hitDirection, out hit, _distanceForPursuit))
        {
            realDistance = hit.distance;
        }

        Debug.DrawRay(transform.position, hitDirection * realDistance, Color.red);

        if (hit.transform.tag == _playerTag) return false;
        return true;
    }

    private bool IsPlayerTooClose()
    {
        var distanceFromBotToPlayerSQR = (_player.transform.position - transform.position).sqrMagnitude;

        if (distanceFromBotToPlayerSQR > DistanceForPursuitSQR) return false;
        return true;
    }
}
