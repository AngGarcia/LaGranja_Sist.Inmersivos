using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class animalGrazing : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 5f;
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Vector2 lowerLimit;
    [SerializeField]
    private Vector2 upperLimit;

    private NavMeshAgent agent;
    private Vector3 path;

    private float counter;
    private bool isDone = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if(isDone)
        {
            StartCoroutine(graze());
        }
    }

    IEnumerator graze()
    {
        isDone = false;

        animator.SetInteger("State", 1);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        agent.isStopped = true;

        waitTime = Random.Range(3f, 5f);
        counter = 0;
        while (counter < waitTime)
        {
            counter += Time.deltaTime;
            //Debug.Log("EAT: " + counter + " seconds");

            yield return null;
        }

        float RandX = Random.Range(lowerLimit.x, upperLimit.x);
        float RandZ = Random.Range(lowerLimit.y, upperLimit.y);
        path = new Vector3(RandX, transform.position.y, RandZ);
        //Debug.Log(path);
        this.transform.LookAt(path);

        counter = 0;
        while (true)
        {
            counter += Time.deltaTime;
            //Debug.Log("WALK: " + counter + " seconds");
            animator.SetInteger("State", 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            agent.isStopped = false;
            agent.speed = speed;
            agent.SetDestination(path);

            if (!agent.pathPending && agent.remainingDistance < 1)
            {
                break;
            }

            yield return null;
        }

        isDone = true;
    }
}
