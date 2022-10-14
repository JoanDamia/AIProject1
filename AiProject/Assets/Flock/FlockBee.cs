using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBee : MonoBehaviour
{
    float speed;
    Vector3 direction;
    public FlockBeeManager myManager;
    
    // Start is called before the first frame update
    void Start()
    {


        myManager = GetComponentInParent<FlockBeeManager>();


        //Define cohesion, alignment and separation and then work with these variables in a foreach, covering all the ifs in a single, bigger one
        Vector3 cohesion = Vector3.zero;
        Vector3 align = Vector3.zero;
        Vector3 separation = Vector3.zero;

        int num = 0;

        foreach (GameObject go in myManager.bees)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    align += go.GetComponent<FlockBee>().direction;
                    separation -= (transform.position - go.transform.position) / (distance * distance);
                    num++;
                }
            }
            //direction = (cohesion + align + separation).normalized * speed;
        }
        if (num > 0)
        {
            cohesion = (cohesion / num - transform.position).normalized * speed;
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }

        direction = (cohesion + align + separation).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }
}

//Variables of the bees movement and behaviour

/*
 * 
//Cohesion:

Vector3 cohesion = Vector3.zero;
int num = 0;
foreach (GameObject go in myManager.allFish)
{
    if (go != this.gameObject)
    {
        float distance = Vector3.Distance(go.transform.position, transform.position);
        if (distance <= myManager.neighbourDistance)
        {
            cohesion += go.transform.position;
            num++;
        }
    }
}
if (num > 0)
    cohesion = (cohesion / num - transform.position).normalized * speed;


//Match velocity/align

Vector3 align = Vector3.zero;
num = 0;
foreach (GameObject go in myManager.allFish)
{
    if (go != this.gameObject)
    {
        float distance = Vector3.Distance(go.transform.position, transform.position);
        if (distance <= myManager.neighbourDistance)
        {
            align += go.GetComponent<Flock>().direction;
            num++;
        }
    }
}
if (num > 0)
{
    align /= num;
    speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
}


//Separation

Vector3 separation = Vector3.zero;
foreach (GameObject go in myManager.allFish)
{
    if (go != this.gameObject)
    {
        float distance = Vector3.Distance(go.transform.position, transform.position);
        if (distance <= myManager.neighbourDistance)
            separation -= (transform.position - go.transform.position) / (distance * distance);
    }
}


//Combination

direction = (cohesion + align + separation).normalized * speed;

*/