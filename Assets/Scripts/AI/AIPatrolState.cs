using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolState : AIBaseState
{
    List<Transform> waypoints = new List<Transform>();

    private bool playerInSightRange;
    private GameObject waypointBase;
    private float rotationSpeed = 3;
    private Vector3 agentPosition;
    private NavMeshAgent agent;
    private Vector3 targetWayPoint;
    private int currentWaypointIndex;
    private int newWaypointIndex;
    private Animator animator;
   
    public override void EnterState(AIStateManager bot)
    {
        waypointBase = GameObject.Find("Waypoints");
        waypoints = waypointBase.GetComponentsInChildren<Transform>().Skip(1).ToList();
        animator = bot.GetComponent<Animator>();
        agent = bot.GetComponent<NavMeshAgent>();
        currentWaypointIndex = Random.Range(0, waypoints.Count);
        targetWayPoint = waypoints[currentWaypointIndex].position;
        Debug.Log(currentWaypointIndex);
    }

    public override void UpdateState(AIStateManager bot)
    {
        animator.SetBool("moving", true);
        agent.SetDestination(targetWayPoint);
        agentPosition = bot.GetComponent<Transform>().position;
        if ((agentPosition - targetWayPoint).magnitude <= 2)
        {
            Debug.Log("yes");
            SelectWaypointIndex(currentWaypointIndex);
            Debug.Log("yes");
        }
        RotateToTarget(targetWayPoint);

    }
    private void SelectWaypointIndex(int waypoint)
    {
        waypoint = currentWaypointIndex;
        newWaypointIndex = Random.Range(0, waypoints.Count);
        Debug.Log(newWaypointIndex);
        if (newWaypointIndex == waypoint)
        {
            SelectWaypointIndex(currentWaypointIndex);
            Debug.Log("No");
        }
        else
            SetWaypoint(newWaypointIndex);
    }

    private void SetWaypoint(int targetpoint)
    {
        currentWaypointIndex = targetpoint;
        targetWayPoint = waypoints[currentWaypointIndex].position;
        //  Debug.Log(targetWayPoint.position);

    }
    public void RotateToTarget(Vector3 target)
    {
        var direction = target - agentPosition;
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }
}
