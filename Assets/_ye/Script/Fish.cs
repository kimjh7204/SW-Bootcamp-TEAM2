using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : WeakAnimal
{
    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {

        int _random = Random.Range(0, 3); // 대기, 풀뜯기, 두리번, 걷기

        if (_random == 0)
            Wait();
        else if (_random > 0)
            TryWalk();
    }

    private void Wait()  // 대기
    {
        currentTime = waitTime;
    }


}
