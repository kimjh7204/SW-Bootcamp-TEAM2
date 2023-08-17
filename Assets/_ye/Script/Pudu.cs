using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pudu : WeakAnimal
{
    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {

        int _random = Random.Range(0, 9); 

        if (_random == 0)
            Wait();
        else if (_random == 1)
            Eat();
        else if (_random == 2)
            Fear();
        else if (_random == 3)
            Jump();
        else if (_random == 4)
            Sit();
        else if (_random == 5)
            Spin();
        else if (_random > 5)
            TryWalk();
    }

    public override void Damage(int _dmg, Vector3 _targetPos)
    {

        base.Damage(_dmg, _targetPos);
        if (!isDead)
        {
            int attackchoice = Random.Range(0, 4);

            if (attackchoice > 0)
            {
                Run(_targetPos);
            }
            else
            {
                anim.SetTrigger("Attack");
                Run(_targetPos);
            }
        }


    }


    private void Wait() 
    {
        currentTime = waitTime;
    }

    private void Eat() 
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
    }

    private void Fear() 
    {
        currentTime = waitTime;
        anim.SetTrigger("Fear");
    }

    private void Jump() 
    {
        currentTime = waitTime;
        anim.SetTrigger("Jump");
    }

    private void Sit() 
    {
        currentTime = waitTime;
        anim.SetTrigger("Sit");
    }

    private void Spin()  
    {
        currentTime = waitTime;
        anim.SetTrigger("Spin");
    }


}