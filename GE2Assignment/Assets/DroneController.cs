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
        if(deathCheck == true)
        {
            DestroyShip();
        }
    }

    System.Collections.IEnumerator DroneActivation()
    {
        yield return new WaitForSeconds(16.3f);
        //Starts the drone in pursue state
        GetComponent<StateMachine>().ChangeState(new PursueShip());
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("drone was hit");
        DestroyShip();
        
    }

    public void DestroyShip()
    {
        GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionObj.gameObject, 3);
        Destroy (this.gameObject);
    }
    
}
