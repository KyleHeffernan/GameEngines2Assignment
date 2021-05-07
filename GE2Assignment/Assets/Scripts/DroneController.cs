using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject explosion;
    public bool deathCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DroneActivation());
        
    }

    // Update is called once per frame
    void Update()
    {
        //If drone is set to dead, call death coroutine
        if(deathCheck == true)
        {
            DestroyShip();
        }
    }

    
    System.Collections.IEnumerator DroneActivation()
    {
        //Drones take about 16 seconds before they activate
        yield return new WaitForSeconds(16.3f);
        //Starts the drone in pursue state
        GetComponent<StateMachine>().ChangeState(new PursueShip());
    }

    //If the drone is shot or crashes, call death coroutine
    public void OnTriggerEnter(Collider other)
    {
        DestroyShip();
    }

    //Creates an explosion and destroys the ship gameobject
    public void DestroyShip()
    {
        GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation);
        //Destroys explosion effect after 3 seconds so scene isnt filled with them
        Destroy(explosionObj.gameObject, 3);
        Destroy (this.gameObject);
    }
    
}
