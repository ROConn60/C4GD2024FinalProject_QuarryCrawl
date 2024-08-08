using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint;
    private UnityEngine.AI.NavMeshAgent agent;

    private AudioSource source;
    public AudioClip scream;
    public AudioClip steps;

    private bool walking;

    [SerializeField] private float waitTime;

    [SerializeField] private bool chasingPlayer = false;
    private bool playerInRange;
    Animator anim;

    void Start()
    {
        source = GetComponent<AudioSource>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        destPoint = Random.Range(0, points.Length);
        anim = GetComponent<Animator>();
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if(!walking)
        {
            StartWalking();
            anim.SetBool("Walking", true);
        }
        if (!playerInRange)
        {
            chasingPlayer = false;
        }
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        if(chasingPlayer)
        {
            
            agent.destination = GameObject.Find("Player").transform.position;
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
        {
            if(chasingPlayer)
            {
                StopWalking();
                Invoke("GotoNextPoint", waitTime);
            }
            else
            {
                GotoNextPoint();
            }
            
        }
        if(!source.isPlaying && walking)
        {
            source.PlayOneShot(steps);
        }
        if(source.isPlaying && !walking)
        {
            source.Stop();
        }
            
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 8)
        {
            anim.SetBool("Attacking", true);
            MenuManager.instance.Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (!chasingPlayer)
            {
                source.PlayOneShot(scream);
            }
            
            agent.destination = GameObject.Find("Player").transform.position;
            agent.speed = 5f;
            playerInRange = true;
            chasingPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            playerInRange = false;
        }
    }

    void StartWalking()
    {
        walking = true;
    }

    void StopWalking()
    {
        walking = false;
    }

}

