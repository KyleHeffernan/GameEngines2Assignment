using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour
{
    public Path path;
    public Vector3 nextWaypoint;
    public float waypointDistance = 5;

    public void Start()
    {
        
    }

    public override Vector3 Calculate()
    {
        //Sets boids target to next waypoint in path then iterates to next path waypoint
        nextWaypoint = path.NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
        {
            path.AdvanceToNext();
        }

        if (!path.looped && path.IsLast())
        {
            return boid.ArriveForce(nextWaypoint);
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
