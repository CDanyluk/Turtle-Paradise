using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{

    public NavMeshAgent ePath;
    public GameObject[] waypoints;
    int currentPointIndex;

    void Start()
    {
        ePath = GetComponent<NavMeshAgent>();
        currentPointIndex = Random.Range(0, waypoints.Length - 1);
        //Start navigating to first *random* waypoint
        //ePath = NavMeshAgent.SetDestination(waypoints[0].transform.position);
        ePath.speed = 2;
    }

    void Update()
    {
        //reaching current waypoint
        if (Vector3.Distance(waypoints[currentPointIndex].transform.position, transform.position) < 1)
        {
            //Find next random waypoint
            currentPointIndex = Random.Range(0, waypoints.Length - 1);
            //Navigate to next waypoint 
            ePath.SetDestination(waypoints[currentPointIndex].transform.position);
        }
    }

}