using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAttackState : AIBaseState
{
    public Inventory inventory;
    public NavMeshAgent agent;
    public GameObject target;
    public override void EnterState(AIStateManager bot)
    {
        target = GetComponent<AIChaseState>().target;
        inventory = GetComponent<Inventory>();
    }

    public override void UpdateState(AIStateManager bot)
    {
        agent.transform.LookAt(target.transform);
        inventory.UseWeapon();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
