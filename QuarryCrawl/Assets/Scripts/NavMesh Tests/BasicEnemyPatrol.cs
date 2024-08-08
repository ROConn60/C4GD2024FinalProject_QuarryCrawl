using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint;
    private UnityEngine.AI.NavMeshAgent agent;

    public AudioSource source;
    public AudioSource screamSource;
    public AudioClip scream;
    public AudioClip steps;
    public AudioClip screech;

    private bool walking;

    [SerializeField] private float waitTime;

    [SerializeField] private bool chasingPlayer = false;
    private bool playerInRange;
    Animator anim;

    private bool stopEverything;
    public float walkSpeed;
    public float runSpeed;

    void Start()
    {
        stopEverything = false;
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
            agent.speed = runSpeed;
        }else
        {
            agent.destination = points[destPoint].position;
            agent.speed = walkSpeed;
        }
        
        

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (Random.Range(0, points.Length)) % points.Length;
        

        
    }


    void Update()
    {
        if (!stopEverything)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (chasingPlayer)
                {
                    StopWalking();
                    Invoke("GotoNextPoint", waitTime);
                }
                else
                {
                    GotoNextPoint();
                }

            }
            if (!source.isPlaying && walking)
            {
                source.PlayOneShot(steps);
            }
            if (source.isPlaying && !walking)
            {
                source.Stop();
            }
        }
        else
        {
            //source.Stop();
            //screamSource.PlayOneShot(screech);
        }
        
            
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 8)
        {
            stopEverything = true;
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
                screamSource.PlayOneShot(scream);
            }
            
            agent.destination = other.gameObject.transform.position;
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
        if(chasingPlayer && !walking)
        {
            screamSource.PlayOneShot(scream);
        }
        walking = true;
        anim.SetBool("Walking", true);
 
    }

    void StopWalking()
    {
        walking = false;
        anim.SetBool("Walking", false);

        
    }

}

