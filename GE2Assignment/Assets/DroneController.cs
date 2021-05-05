using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DroneActivation());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    System.Collections.IEnumerator DroneActivation()
    {
        yield return new WaitForSeconds(2.0f);
        //Starts the drone in pursue state
        GetComponent<StateMachine>().ChangeState(new PursueShip());
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("drone was hit");
        
        GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionObj.gameObject, 3);

        Destroy (this.gameObject);
    }
    
}
