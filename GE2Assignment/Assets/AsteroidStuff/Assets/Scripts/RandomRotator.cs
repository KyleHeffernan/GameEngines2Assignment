using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    void Start()
    {
        //Gives the asteroids some random rotation
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}