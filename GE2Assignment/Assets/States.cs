using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class IdleState : State
{
    public override void Think()
    {
        
        if(owner.GetComponent<MilanoController>().videoplayer.activeSelf == false)
        {
            owner.ChangeState(new WaitState());
        }

    }

}
class WaitState : State
{
    public override void Enter()
    {
        owner.GetComponent<FollowPath>().enabled = true;
        owner.GetComponent<Boid>().maxSpeed = 10;
    }

    public override void Think()
    {
        
        
        if(owner.GetComponent<MilanoController>().shot == true)
        {
            owner.ChangeState(new FleeState());
        }

    }

    

    public override void Exit()
    {
        owner.GetComponent<Boid>().maxSpeed = 100;
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
        if (Vector3.Angle(-owner.transform.forward, toEnemy) < 220 && toEnemy.magnitude < 550)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.GetComponent<MilanoController>().bulletSpawn.transform.forward * 2, owner.GetComponent<MilanoController>().bulletSpawn.transform.rotation);       
        }

        if(owner.transform.position.z < -500)
        {
            owner.ChangeState(new AlmostEscapedState());

        }
    }

    

}

class AlmostEscapedState : State
{
    public override void Enter()
    {
        owner.GetComponent<Boid>().maxSpeed = 30;
    }

    public override void Think()
    {

        if(owner.transform.position.z < -660)
        {
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
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 50 && toEnemy.magnitude < 400)
        {
            AudioSource audio = owner.GetComponent<AudioSource>();
            audio.Play();
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);       
        }
        
        if(owner.GetComponent<AttackShip>().milano.transform.position.z < -660)
        {
            owner.ChangeState(new DeathState());

        }


    }

    public override void Exit()
    {
        
    }
}

class DeathState : State
{
    public override void Enter()
    {
        owner.GetComponent<DroneController>().deathCheck = true;
    }

}
