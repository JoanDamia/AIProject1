using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    float radius, offset;
    public UnityEngine.AI.NavMeshAgent agent;

    void Seek(Vector3 position)
    {
        agent.destination = position; 
    }


    // Start is called before the first frame update
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      radius = 10;
      offset = 10;


    }

    // Update is called once per frame
    void Update()
    {
             wander();
    }

    void wander(){

    Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
    localTarget += new Vector3(0, 0, offset);

    Vector3 worldTarget = transform.TransformPoint(localTarget);
    worldTarget.y = 0f;
    agent.SetDestination(worldTarget);

    /*Vector3 targetDir = target.transform.position - transform.position;
    float lookAhead = targetDir.magnitude / agent.speed;
    Seek(target.transform.position + target.transform.forward * lookAhead);*/

// Flee for evasion
    //Seek();



    //NavMesh.SamplePosition;
    }
}
