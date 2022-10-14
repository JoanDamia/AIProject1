using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
   
    public GameObject[] allBees;
    public GameObject beePrefab;


    //public Vector3 swimLimits = new Vector3(5.0f, 5.0f, 5.0f);

    [Header("Bee Settings")]
    //Flocking Manager parameters
    public int numBees;
    public float maxSpeed;
    public float minSpeed;
    public float neighbourDistance;
    public float rotationSpeed;



    // Start is called before the first frame update
    void Start()
    {
       

       

      //Flocking Manager

      allBees = new GameObject[numBees];
      for (int i = 0; i < numBees; ++i) {

        Vector3 pos = this.transform.position + new Vector3 (Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));  // random position
        Vector3 randomize = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)); // random vector direction
        allBees[i] = (GameObject)Instantiate(beePrefab, pos, Quaternion.LookRotation(randomize));
        allBees[i].GetComponent<Flock>().myManager = this;


      }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
