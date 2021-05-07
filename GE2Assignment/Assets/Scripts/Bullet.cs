using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;

    public float bulletOffset;
    // Start is called before the first frame update
    void Start()
    {

        //Get current forward
        Vector3 variedDirection = transform.forward.normalized;
        //Adding some variance on the x and y axis
        variedDirection.x += Random.Range(-bulletOffset, bulletOffset);
        variedDirection.y += Random.Range(-bulletOffset, bulletOffset);
        //Applying the variance
        transform.forward = variedDirection;
        //Bullets are destroyed after 5 seconds
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        //Moving bullet forward at set speed
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
