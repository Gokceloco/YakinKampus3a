using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Vector3 target;

    private void Update()
    {
        agent.SetDestination(target);
    }
}
