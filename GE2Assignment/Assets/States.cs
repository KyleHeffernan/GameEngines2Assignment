using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class WaitState : State
{
    public override void Enter()
    {
        //owner.GetComponent<FollowPath>().enabled = true;
    }

    public override void Think()
    {
        /*
        MeshCollider milanoCollider = owner.GetComponent<MeshCollider>();
        if(milanoCollider.isTrigger == true)
        {
            owner.ChangeState(new FleeState());
        }
        */
        if(owner.GetComponent<MilanoController>().shot == true)
        {
            owner.ChangeState(new FleeState());
        }

    }

    

    public override void Exit()
    {
        owner.GetComponent<FollowPath>().enabled = true;
    }
}

class FleeState: State
{
    public override void Enter()
    {
        
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<AttackShip>().milano.transform.position - owner.transform.position;
        if (Vector3.Angle(-owner.transform.forward, toEnemy) < 180 && toEnemy.magnitude < 350)
        {
            //Vector3 flipped = owner.transform.InverseTransformDirection(Vector3.forward);
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.GetComponent<MilanoController>().bulletSpawn.transform.forward * 2, owner.GetComponent<MilanoController>().bulletSpawn.transform.rotation);       
        }

        //Debug.Log(owner.GetComponent<FollowPath>().nextWaypoint);
        //Debug.Log(owner.transform.position.z);
        if(owner.transform.position.z < -660)
        {
            //Debug.Log("Destination reached");
            owner.ChangeState(new EscapedState());

        }
    }

    public override void Exit()
    {
        owner.GetComponent<FollowPath>().enabled = false;
    }

}

class EscapedState : State
{

}

class PursueShip : State
{
    public override void Enter()
    {
        owner.GetComponent<OffsetPursue>().enabled = true;
    }

    public override void Think()
    {
        
        Vector3 toEnemy = owner.GetComponent<AttackShip>().milano.transform.position - owner.transform.position;
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 50 && toEnemy.magnitude < 200)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);       
        }
        
        if(owner.GetComponent<AttackShip>().milano.transform.position.z < -660)
        {
            //Debug.Log("Destination reached");
            owner.ChangeState(new DeathState());

        }


    }

    public override void Exit()
    {
        //owner.GetComponent<FollowPath>().enabled = false;
    }
}

class DeathState : State
{
    public override void Enter()
    {
        owner.GetComponent<DroneController>().deathCheck = true;
    }

}
