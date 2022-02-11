using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    public AIBaseState currentState;
    public AIPatrolState PatrolState = new AIPatrolState();
    public AIChaseState ChaseState = new AIChaseState();
    public AIAttackState AttackState = new AIAttackState();

    void Start()
    {
        currentState = PatrolState;

        currentState.EnterState(this);
    }

    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
