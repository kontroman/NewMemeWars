using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIChaseState : AIBaseState
{
    private AISightController sightController;

    public GameObject target;
    private GameObject closestTarget;
    
    private Transform targetTransform;
    
    private NavMeshAgent agent;

    public float attackRange;

    
    public override void EnterState(AIStateManager bot)
    {
        sightController = bot.GetComponentInChildren<AISightController>();
        agent = bot.GetComponent<NavMeshAgent>();
        target = FindClosestEnemy();
    }

    public override void UpdateState(AIStateManager bot)
    {
        target = FindClosestEnemy();
        targetTransform = target.GetComponent<Transform>();
        agent.SetDestination(targetTransform.position);
        if ((agent.transform.position - targetTransform.position).magnitude < (attackRange + 0.25f * attackRange))
            bot.SwitchState(bot.AttackState);
        if (!sightController.enemiesInSight.Any())
            bot.SwitchState(bot.PatrolState);
    }

    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in sightController.enemiesInSight)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if ((curDistance < distance) && (curDistance != 0f))
            {
                closestTarget = go;
                distance = curDistance;
            }
        }
        return closestTarget;
    }
}
