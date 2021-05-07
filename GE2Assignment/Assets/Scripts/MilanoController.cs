using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilanoController : MonoBehaviour
{

    public GameObject bulletSpawn;
    public GameObject explosion;
    public float lastHit = 0;
    public GameObject videoplayer;

    public bool shot = false;

    // Start is called before the first frame update
    void Start()
    {
        //Starts the milano in the idle state
        GetComponent<StateMachine>().ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        shot = true;
        //Explosion animation plays if milano is shot. With 2 second cooldown between shots
        if(lastHit < Time.time - 2)
        {
            GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionObj.gameObject, 3);
            lastHit = Time.time;
        }
        
    }

    

}
