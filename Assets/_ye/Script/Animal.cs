using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [SerializeField] protected string animalName; // 동물의 이름
    [SerializeField] protected int hp;  // 동물의 체력

    [SerializeField] protected float walkSpeed;  // 걷기 속력
    [SerializeField] protected float runSpeed;  // 달리기 속력
    [SerializeField] protected float turningSpeed;  // 회전 속력
    protected float applySpeed;

    protected Vector3 direction;  // 방향

    // 상태 변수
    protected bool isAction;  // 행동 중인지 아닌지 판별
    protected bool isWalking; // 걷는지, 안 걷는지 판별
    protected bool isRunning; // 달리는지 판별
    protected bool isDead;   // 죽었는지 판별

    [SerializeField] protected float walkTime;  // 걷기 시간
    [SerializeField] protected float waitTime;  // 대기 시간
    [SerializeField] protected float runTime;  // 뛰기 시간
    protected float currentTime;

    // 필요한 컴포넌트
    [SerializeField] protected Animator anim;
    protected AudioSource theAudio;

    [SerializeField] protected AudioClip[] sound_Normal;
    [SerializeField] protected AudioClip sound_Hurt;
    [SerializeField] protected AudioClip sound_Dead;

    protected Vector3 destination;  // 목적지

    // 필요한 컴포넌트
    protected NavMeshAgent nav;

    protected void Start()
    {
        currentTime = waitTime;   // 대기 시작
        isAction = true;   // 대기도 행동
        theAudio = GetComponent<AudioSource>();
        nav = GetComponent<NavMeshAgent>();
    }

    protected void Update()
    {
        if (!isDead)
        {
            Move();
            ElapseTime();
        }
    }

    protected void Move()
    {
        if (isWalking || isRunning)
        {
            Vector3 randomPosition = GetRandomPositionOnNavMesh();
            nav.SetDestination(randomPosition);
        }

    }
    Vector3 GetRandomPositionOnNavMesh()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 20f;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 20f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            return transform.position;
        }
    }

    protected void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)  // 랜덤하게 다음 행동을 개시
                ReSet();
        }
    }

    protected virtual void ReSet()  // 다음 행동 준비
    {
        isAction = true;

        nav.ResetPath();

        isWalking = false;
        anim.SetBool("Walking", isWalking);
        isRunning = false;
        anim.SetBool("Running", isRunning);
        nav.speed = walkSpeed;

    }
    
    protected void TryWalk()  // 걷기
    {
        currentTime = walkTime;
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        nav.speed = walkSpeed;
        Debug.Log("걷기");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                return;
            }

            PlaySE(sound_Hurt);
            anim.SetTrigger("Hurt");
            // Run(_targetPos);
        }
    }

    protected void Dead()
    {
        PlaySE(sound_Dead);

        isWalking = false;
        isRunning = false;
        isDead = true;

        anim.SetTrigger("Dead");

    }

    protected void RandomSound()
    {
        int _random = Random.Range(0, sound_Normal.Length);  // 돼지의 일상 사운드는 3 개
        PlaySE(sound_Normal[_random]);
    }

    protected void PlaySE(AudioClip _clip)
    {
        theAudio.clip = _clip;
        theAudio.Play();
    }
}


