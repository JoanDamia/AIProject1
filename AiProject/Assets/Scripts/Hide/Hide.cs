using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Linq;

public class Hide : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    GameObject[] hidingSpots;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Hiding();
    }

    void Hiding()
    {
        Func<GameObject, float> distance =
            (hs) => Vector3.Distance(target.transform.position,
                                     hs.transform.position);
        GameObject hidingSpot = hidingSpots.Select(
            ho => (distance(ho), ho)
            ).Min().Item2;
        Vector3 dir = hidingSpot.transform.position - target.transform.position;
        Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        RaycastHit info;
        hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 50f);
        Seek(info.point + dir.normalized);
    }
    void Seek(Vector3 vector3)
    {
        agent.destination = vector3;
    }

}
