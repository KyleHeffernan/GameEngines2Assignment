using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryController : MonoBehaviour
{
    public GameObject explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toEnemy = this.GetComponent<AttackShip>().milano.transform.position - this.transform.position;
        if (Vector3.Angle(this.transform.forward, toEnemy) < 180 && toEnemy.magnitude < 800)
        {
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play();
            GameObject bullet = GameObject.Instantiate(this.GetComponent<AttackShip>().bullet, this.transform.position + this.transform.forward * 2, this.transform.rotation);       
        }

        if(this.GetComponent<AttackShip>().milano.transform.position.z < -660)
        {
            GameObject explosionObj = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionObj.gameObject, 3);
            Destroy (this.gameObject);
    
        }
        
    }
}