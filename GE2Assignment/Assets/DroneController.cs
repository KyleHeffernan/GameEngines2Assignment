using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Starts the dog in the Go To Player State
        GetComponent<StateMachine>().ChangeState(new PursueShip());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
