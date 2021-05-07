using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State milano starts off in. Idle until start cutscene ends
class IdleState : State
{
    public override void Think()
    {
        //Once the beginning video ends, change to waitstate
        if(owner.GetComponent<MilanoController>().videoplayer.activeSelf == false)
        {
            owner.ChangeState(new WaitState());
        }

    }

}

//State milano moves to. Ship slowly moves forward until it is shot, then transitions to flee state
class WaitState : State
{
    //Starts following the set path with a max speed of 10
    public override void Enter()
    {
        owner.GetComponent<FollowPath>().enabled = true;
        owner.GetComponent<Boid>().maxSpeed = 10;
    }

    public override void Think()
    {
        //Once the milano is shot, change to the flee state
        if(owner.GetComponent<MilanoController>().shot == true)
        {
            owner.ChangeState(new FleeState());
        }

    }

    public override void Exit()
    {
        //As it leaves this state, increase speed to 100
        owner.GetComponent<Boid>().maxSpeed = 100;
    }
}

//State milano moves to. Milano follows path and shoots until it gets to end of scene
class FleeState: State
{
    public override void Enter()
    {
        
    }

    public override void Think()
    {
        //Gets distance between milano and its target(Set to fleet1)
        Vector3 toEnemy = owner.GetComponent<AttackShip>().milano.transform.position - owner.transform.position;
        //If target is within set angle and distance, fire a bullet from the milano back at them
        if (Vector3.Angle(-owner.transform.forward, toEnemy) < 220 && toEnemy.magnitude < 550)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.GetComponent<MilanoController>().bulletSpawn.transform.forward * 2, owner.GetComponent<MilanoController>().bulletSpawn.transform.rotation);       
        }

        //Once the milano reaches the end of the scene, transition to almost escaped state
        if(owner.transform.position.z < -400)
        {
            owner.ChangeState(new AlmostEscapedState());

        }
    }

}

//State milano moves to once it almost reaches end of scene. Speed reduced. Once it reaches end, transition to escaped state
class AlmostEscapedState : State
{
    public override void Enter()
    {
        //Reduce speed to 25 as it gets shot by all the sentries
        owner.GetComponent<Boid>().maxSpeed = 25;
    }

    public override void Think()
    {
        //Once it reaches end of scene, transition to escaped state
        if(owner.transform.position.z < -660)
        {
            owner.ChangeState(new EscapedState());

        }
    }

    public override void Exit()
    {
        //On exit, turn the pathfollowing behaviour off
        owner.GetComponent<FollowPath>().enabled = false;
    }

}

//State milano moves to once it reaches end of scene
class EscapedState : State
{

}

//State drones start in. Follows the milano with the offset pursue behaviour and shoots at milano. Exits state once it dies.
class PursueShip : State
{
    public override void Enter()
    {
        //As drones enter state, the offset pursue behaviour is turned on
        owner.GetComponent<OffsetPursue>().enabled = true;
    }

    public override void Think()
    {
        //Gets distance between drone and the milano
        Vector3 toEnemy = owner.GetComponent<AttackShip>().milano.transform.position - owner.transform.position;
        //If milano is within set angle and distance, fire a bullet at it and play shooting sound
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 50 && toEnemy.magnitude < 400)
        {
            AudioSource audio = owner.GetComponent<AudioSource>();
            audio.Play();
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);       
        }
        
        if(owner.GetComponent<AttackShip>().milano.transform.position.z < -660)
        {
            //Once the milano reaches the end of the scene, change to death state
            owner.ChangeState(new DeathState());

        }

    }

}

//State drones move to once milano reaches end of scene, sets them to be destroyed
class DeathState : State
{
    public override void Enter()
    {
        //Setting this boolean to true calls a method in droen controller to explode the ship
        owner.GetComponent<DroneController>().deathCheck = true;
    }

}
