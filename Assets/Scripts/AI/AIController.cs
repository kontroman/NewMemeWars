using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class AIController : MonoBehaviour
{
    public Transform[] waypoints;
    public float rotationSpeed;

    private Vector3 agentPosition;
    private NavMeshAgent agent;
    private Vector3 targetWayPoint;

    private int currentWaypointIndex;
    private int newWaypointIndex;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        targetWayPoint = waypoints[currentWaypointIndex].position;
        Debug.Log(currentWaypointIndex);
        //    SelectWaypointIndex(currentWaypointIndex);
    }

    void Update()
    {
        Move();
    }

    private void SelectWaypointIndex(int waypoint)
    {
        waypoint = currentWaypointIndex;
        newWaypointIndex = Random.Range(0, waypoints.Length);
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

    public void Move()
    {
        animator.SetBool("moving", true);
        agent.SetDestination(targetWayPoint);
        agentPosition = GetComponent<Transform>().position;
        if ((agentPosition - targetWayPoint).magnitude <= 1)
        {
            Debug.Log("yes");
            SelectWaypointIndex(currentWaypointIndex);
            Debug.Log("yes");
        }

        RotateToTarget(targetWayPoint);
    }

    public void RotateToTarget(Vector3 target)
    {
        var direction = target - agentPosition;
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }
}
