using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;


    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;


    [Range(0.0f, 1.0f)]
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;


    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    // For initializing boid
    void Start()
    {
        //Getting any attached steering behaviours and adding them to list
        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);            
        }
    }

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }

    public Vector3 ArriveForce(Vector3 target, float slowingDistance = 40.0f)
    {
        Vector3 toTarget = target - transform.position;

        float distance = toTarget.magnitude;

        
        if (distance > 0)
        {
            //Slowing speed down before target is reached
            float ramped = maxSpeed * (distance / slowingDistance);

            float clamped = Mathf.Min(ramped, maxSpeed);
            Vector3 desired = clamped * (toTarget / distance);

            return desired - velocity;
        }
        else
        {
            return Vector3.zero;
        }        
    }
    

    Vector3 Calculate()
    {
        force = Vector3.zero;

        // Weighted prioritised truncated running sum
        // 1. Behaviours are weighted
        // 2. Behaviours are prioritised
        // 3. Truncated
        // 4. Running sum

        //Calculating for active steering behaviours
        foreach (SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate() * b.weight;      
                float f = force.magnitude;
                if (f >= maxForce)
                {
                    force = Vector3.ClampMagnitude(force, maxForce);
                    break;
                }                         
            }
        }

        return force;
    }


    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        
        if (velocity.magnitude > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            transform.position += velocity * Time.deltaTime;
            velocity *= (1.0f - (damping * Time.deltaTime));
        }
    }
}
