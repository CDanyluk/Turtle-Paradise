using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    //public Transform target;
    NavMeshAgent agent;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("target");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.GetComponent<Transform>().position);
    }
}
