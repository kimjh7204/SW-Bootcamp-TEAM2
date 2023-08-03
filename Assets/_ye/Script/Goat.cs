using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : WeakAnimal
{
    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();

        int _random = Random.Range(0, 6); // ´ë±â, Ç®¶â±â, µÎ¸®¹ø, °È±â

        if (_random == 0)
            Wait();
        else if (_random == 1)
            Seat();
        else if (_random == 2)
            Peek();
        else if (_random == 3)
            TryWalk();
        else if (_random == 4)
            BackStep();
        else if (_random == 5)
            Eat();


    }

    public override void Damage(int _dmg, Vector3 _targetPos)
    {

        base.Damage(_dmg, _targetPos);
        if (!isDead)
        {
            int attackchoice = Random.Range(0, 4);

            if (attackchoice > 0)
            {
                var runIdx = Random.Range(0, 2);
                anim.SetInteger("RunIdx", runIdx);
                Run(_targetPos);
            }
            else
            {
                anim.SetTrigger("Attack");
                var runIdx = Random.Range(0, 2);
                anim.SetInteger("RunIdx", runIdx);
                Run(_targetPos);
            }
        }


    }


    private void Wait()  
    {
        currentTime = waitTime;
    }

    private void Seat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Seat");
    }

    private void Peek()
    {
        currentTime = waitTime;
        var runIdx = Random.Range(0, 2);
        anim.SetInteger("PeekIdx", runIdx);
        anim.SetTrigger("Peek");
    }

    private void BackStep()
    {
        currentTime = waitTime;
        anim.SetTrigger("BackStep");
    }

    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
    }

}