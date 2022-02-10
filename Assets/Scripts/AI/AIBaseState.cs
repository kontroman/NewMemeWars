using UnityEngine;

public abstract class AIBaseState : MonoBehaviour
{
    abstract public void EnterState(AIStateManager bot);
    abstract public void UpdateState(AIStateManager bot);
}
