using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyScriptable enemyScriptable;
    [SerializeField] private NavMeshAgent navMeshAgent;
    public Transform target;
    void Start()
    {
        navMeshAgent.speed = enemyScriptable.speed;
        
    }
    private void Update()
    {
        navMeshAgent.destination = target.position;
    }
}
