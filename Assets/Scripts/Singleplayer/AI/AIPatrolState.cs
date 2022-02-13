using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolState : AIBaseState
{
    public AISightController sightController;
    
    private GameObject waypointBase;

    private NavMeshAgent agent;

    private Vector3 targetWayPoint;
    private Vector3 agentPosition;

    private float rotationSpeed = 3;

    private int currentWaypointIndex;
    private int newWaypointIndex;
 
    private Animator animator;

    List<Transform> waypoints = new List<Transform>();

    public override void EnterState(AIStateManager bot)
    {
        sightController = bot.GetComponentInChildren<AISightController>();
        waypointBase = GameObject.Find("Waypoints");
        waypoints = waypointBase.GetComponentsInChildren<Transform>().Skip(1).ToList();
        animator = bot.GetComponent<Animator>();
        agent = bot.GetComponent<NavMeshAgent>();
        currentWaypointIndex = Random.Range(0, waypoints.Count);
        targetWayPoint = waypoints[currentWaypointIndex].position;
    }

    public override void UpdateState(AIStateManager bot)
    {
        animator.SetBool("moving", true);
        agent.SetDestination(targetWayPoint);
        agentPosition = bot.GetComponent<Transform>().position;
        if ((agentPosition - targetWayPoint).magnitude <= 2)
        {
            SelectWaypointIndex(currentWaypointIndex);
        }
        RotateToTarget(targetWayPoint);
        if (sightController.enemiesInSight.Any())
            bot.SwitchState(bot.ChaseState);
    }

    private void SelectWaypointIndex(int waypoint)
    {
        waypoint = currentWaypointIndex;
        newWaypointIndex = Random.Range(0, waypoints.Count);
        if (newWaypointIndex == waypoint)
            SelectWaypointIndex(currentWaypointIndex);
        else
            SetWaypoint(newWaypointIndex);
    }

    private void SetWaypoint(int targetpoint)
    {
        currentWaypointIndex = targetpoint;
        targetWayPoint = waypoints[currentWaypointIndex].position;

    }
    public void RotateToTarget(Vector3 target)
    {
        var direction = target - agentPosition;
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }
}
