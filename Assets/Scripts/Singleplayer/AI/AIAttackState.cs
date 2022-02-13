using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAttackState : AIBaseState
{
    private AISightController aISightController;
    private AIChaseState chaseState;
    
    public Inventory inventory;
    
    public NavMeshAgent agent;
    
    public GameObject target;
    
    private float attackRange;
    public override void EnterState(AIStateManager bot)
    {
        aISightController = bot.GetComponent<AISightController>();
        chaseState = bot.GetComponent<AIChaseState>();
        agent = bot.GetComponent<NavMeshAgent>();
        target = chaseState.target;
        attackRange = chaseState.attackRange;
        inventory = bot.GetComponent<Inventory>();
        agent.Stop();
    }

    public override void UpdateState(AIStateManager bot)
    {
        agent.transform.LookAt(target.transform);
        inventory.UseWeapon();
        if ((agent.transform.position - target.transform.position).magnitude > attackRange)
        {
            if (aISightController.enemiesInSight.Contains(target))
            {
                agent.Resume();
                bot.SwitchState(bot.ChaseState);
            }
            else
            {
                agent.Resume();
                bot.SwitchState(bot.PatrolState);
            }
        }
    }
}
