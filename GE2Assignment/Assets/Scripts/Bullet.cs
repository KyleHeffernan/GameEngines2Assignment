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

        //get current forward
        Vector3 variedDirection = transform.forward.normalized;
        //get variance
        variedDirection.x += Random.Range(-bulletOffset, bulletOffset);
        variedDirection.y += Random.Range(-bulletOffset, bulletOffset);
        //apply back to original
        transform.forward = variedDirection;

        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
