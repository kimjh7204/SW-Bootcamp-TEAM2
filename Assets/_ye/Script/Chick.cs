using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : WeakAnimal
{
    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {
        RandomSound();

        int _random = Random.Range(0, 4); // ���, Ǯ���, �θ���, �ȱ�

        if (_random == 0)
            Wait();
        else if (_random == 1)
            Eat();
        else if (_random == 2)
            Peek();
        else if (_random == 3)
            TryWalk();
    }

    private void Wait()  // ���
    {
        currentTime = waitTime;
    }

    private void Eat()  // Ǯ ���
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
    }

    private void Peek()  // �θ���
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
    }
}
