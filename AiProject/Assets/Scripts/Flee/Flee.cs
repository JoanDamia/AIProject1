using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    float radius, offset;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        radius = 6;
        offset = 6;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, target.transform.position);
        FleeFunc();
    }

    void FleeFunc()
    {
        Debug.Log("Flee working");

        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);

        agent.destination = transform.position - target.transform.position + localTarget;

        Scared();
    }

    void Scared()
    {
        Debug.Log("Scared working");

        switch (distance)
        {
            case < 3:
                Debug.Log("ScaredKid speed increased");
                agent.speed = 12;

                break;

            case >= 5:
                Debug.Log("ScaredKid speed is normal");
                agent.speed = 4;
                    break;
        }

    }
}
