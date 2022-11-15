using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour
{
   
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    
    void Seek(Vector3 position)
    {
        agent.destination = target.transform.position; 
    }


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
      
         Vector3 targetDir = target.transform.position - transform.position;
         float lookAhead = targetDir.magnitude / agent.speed;
         Seek(target.transform.position + target.transform.forward * lookAhead);
      
        

   
   
    }


}
