using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilanoController : MonoBehaviour
{
    public GameObject bulletSpawn;

    public GameObject explosion;

    public float lastHit = 0;

    public bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
        //Starts the dog in the Go To Player State
        GetComponent<StateMachine>().ChangeState(new WaitState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        shot = true;
        //Debug.Log(other);
        if(lastHit < Time.time - 2)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            //Destroy (this.gameObject);
            lastHit = Time.time;
        }
        
    }

    

}
