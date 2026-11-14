using System;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum States
{
    idle,
    chase,
    escape
}

public class enemyAI : MonoBehaviour
{
    public int currentEnemyHealth = 3;
    Transform player; //reference to players position
    NavMeshAgent nav; //reference to the nav mesh agent
    States _state = States.idle; //Current enemy state

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <NavMeshAgent> ();
    }

    void Update()
    {   
        float distance = Vector3.Distance(transform.position,
        player.transform.position);
        Debug.Log(distance);
        ChangeState();
        switch (_state)
        {
            case States.idle:
                nav.SetDestination(transform.position);
                break;
            case States.chase:
                nav.SetDestination(player.position);
                break;
            case States.escape:
                transform.rotation = Quaternion.LookRotation(transform.position - player.position);
                Vector3 runTo = transform.position + transform.forward * 10;
                nav.SetDestination(runTo); 
                break;
        }
    }

    void ChangeState()
    {
        float distance = Vector3.Distance(transform.position,
        player.transform.position);

        if (distance <= 5 && _state==States.idle)
        {
            _state = States.chase;
        }

        if(distance > 5 && _state == States.chase)
        {
            _state = States.idle;
        }
        {
            
        }

        if (currentEnemyHealth == 1)
        {
            _state = States.escape;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            currentEnemyHealth--;
            if(currentEnemyHealth<=0) Destroy(gameObject);
        }
    }
}
