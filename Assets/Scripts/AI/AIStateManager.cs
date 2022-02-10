using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    AIBaseState currentState;
    AIPatrolState PatrolState = new AIPatrolState();
    AIChaseState AIChaseState = new AIChaseState();
    AIAttackState AIAttackState = new AIAttackState();


    // Start is called before the first frame update
    void Start()
    {
        currentState = PatrolState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
