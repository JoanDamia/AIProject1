using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FlockBeeManager : MonoBehaviour
{
    public GameObject beePrefab;
    [HideInInspector] public GameObject[] bees;

    //Bee parameters
    public int allBees;
    public Vector3 Movement_Limit;
    public bool bounded;
    public bool randomize;
    public bool follow_lider;
    public GameObject lider;

    //Bee behaviour: movement and distance between them.
    [Header("Bee behaviour")]

    [Range(0.0f, 10.0f)] public float minSpeed;
    [Range(0.0f, 100.0f)] public float maxSpeed;
    [Range(0.0f, 20.0f)] public float neighbourDistance;
    [Range(0.0f, 10.0f)] public float rotationSpeed;


    // Start is called before the first frame update
    void Start() { 
    
        bees = new GameObject[allBees];

        // apply the variables given for every bee until they are all set

        for (int i = 0; i < allBees; ++i) { 
        
            Vector3 pos = this.transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)); // random position
            Vector3 randomize = new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3)); // random vector direction
            bees[i] = (GameObject)Instantiate(beePrefab, pos, Quaternion.LookRotation(randomize));
            bees[i].GetComponent<FlockBee>().myManager = this;
            bees[i].transform.parent = gameObject.transform; //modifying the parent-relative position, scale and rotation while keeping the world space position, rotation and scale
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}


//a base if the code I tried fails. It also works as a reference

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Fish creation and initialization
public class FlockingManager : MonoBehaviour
{
    //Flocking Manager parameters
    public GameObject fishPrefab;
    public int numFish;
    public float maxSpeed;
    public float minSpeed;
    public float neighbourDistance;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
            for (int i = 0; i < numFish; ++i) {
    Vector3 pos = this.transform.position + random.range(0,10) + random.range(0,10) + random.range(0,10); // random position
    Vector3 randomize =  Vector3(random.range(0,10),random.range(0,10),random.range(0,10))// random vector direction
    allFish[i] = (GameObject)Instantiate(fishPrefab, pos, 
                                Quaternion.LookRotation(randomize));
    allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}*/
