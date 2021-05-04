using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PursueShip : State
{
    public override void Enter()
    {
        //owner.GetComponent<FollowPath>().enabled = true;
    }

    public override void Think()
    {
        /*
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) < 10)
        {
            owner.ChangeState(new DefendState());
        }
        */
        Vector3 toEnemy = owner.GetComponent<AttackShip>().milano.transform.position - owner.transform.position;
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 50 && toEnemy.magnitude < 200)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<AttackShip>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);       
        }
        


    }

    public override void Exit()
    {
        //owner.GetComponent<FollowPath>().enabled = false;
    }
}

/*
public class DefendState : State
{
    public override void Enter()
    {
        owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position; 
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 20)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
            owner.GetComponent<Fighter>().ammo --;        
        }
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) > 30)
        {
            owner.ChangeState(new PatrolState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
    }

}


public class AttackState : State
{
    public override void Enter()
    {
        owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position; 
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 30)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
            owner.GetComponent<Fighter>().ammo --;
        }        
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) < 10)
        {
            owner.ChangeState(new FleeState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
    }
}

public class FleeState : State
{
    public override void Enter()
    {
        owner.GetComponent<Flee>().targetGameObject = owner.GetComponent<Fighter>().enemy;
        owner.GetComponent<Flee>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) > 30)
        {
            owner.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Flee>().enabled = false;
    }
}

public class Alive:State
{
    public override void Think()
    {

        if (owner.GetComponent<Fighter>().health <= 0)
        {
            Dead dead = new Dead();
            owner.ChangeState(dead);
            owner.SetGlobalState(dead);
            return;
        }

        if (owner.GetComponent<Fighter>().health <= 2)
        {
            owner.ChangeState(new FindHealth());
            return;
        }
        
        if (owner.GetComponent<Fighter>().ammo <= 0)
        {
            owner.ChangeState(new FindAmmo());
            return;
        }
    }
}

public class Dead:State
{
    public override void Enter()
    {
        SteeringBehaviour[] sbs = owner.GetComponent<Boid>().GetComponents<SteeringBehaviour>();
        foreach(SteeringBehaviour sb in sbs)
        {
            sb.enabled = false;
        }
        owner.GetComponent<StateMachine>().enabled = false;        
    }         
}
*/
