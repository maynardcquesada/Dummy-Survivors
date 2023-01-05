using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
    }
}
