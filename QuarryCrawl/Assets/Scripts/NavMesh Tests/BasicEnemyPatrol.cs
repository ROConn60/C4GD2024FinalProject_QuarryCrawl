using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint;
    private UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private bool autobrake;

    [SerializeField] private bool chasingPlayer = false;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = autobrake;
        destPoint = Random.Range(0, points.Length);

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        if(chasingPlayer)
        {
            agent.destination = GameObject.Find("Player Dummy").transform.position;
            agent.speed = 5f;
        }else
        {
            agent.destination = points[destPoint].position;
            agent.speed = 2f;
        }
        
        

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (Random.Range(0, points.Length)) % points.Length;
        

        
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
