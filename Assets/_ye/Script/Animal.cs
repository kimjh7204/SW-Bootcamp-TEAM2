using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [SerializeField] protected string animalName; // ������ �̸�
    [SerializeField] protected int hp;  // ������ ü��
    private int firstHp;

    [SerializeField] protected float walkSpeed;  // �ȱ� �ӷ�
    [SerializeField] protected float runSpeed;  // �޸��� �ӷ�
    [SerializeField] protected float turningSpeed;  // ȸ�� �ӷ�
    protected float applySpeed;

    protected Vector3 direction;  // ����

    // ���� ����
    protected bool isAction;  // �ൿ ������ �ƴ��� �Ǻ�
    protected bool isWalking; // �ȴ���, �� �ȴ��� �Ǻ�
    protected bool isRunning; // �޸����� �Ǻ�
    protected bool isDead;   // �׾����� �Ǻ�

    [SerializeField] protected float walkTime;  // �ȱ� �ð�
    [SerializeField] protected float waitTime;  // ��� �ð�
    [SerializeField] protected float runTime;  // �ٱ� �ð�
    [SerializeField] protected float deadTime; //��� �ð�
    protected float currentTime;

    // �ʿ��� ������Ʈ
    [SerializeField] protected Animator anim;
    protected AudioSource theAudio;

    [SerializeField] protected AudioClip[] sound_Normal;
    [SerializeField] protected string sound_Hurt;
    [SerializeField] protected string sound_Dead;

    protected FieldOfViewAngle theFieldOfViewAngle;
    protected bool isChasing;
    protected bool isAttacking;
    protected HPBar thePlayerStatus;



    protected Vector3 destination;  // ������

    // �ʿ��� ������Ʈ
    protected NavMeshAgent nav;

    protected void Start()
    {
        currentTime = waitTime;   // ��� ����
        isAction = true;   // ��⵵ �ൿ
        theAudio = GetComponent<AudioSource>();
        nav = GetComponent<NavMeshAgent>();
        theFieldOfViewAngle = GetComponent<FieldOfViewAngle>();
        firstHp = hp;
    }

    protected virtual void Update()
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
            Vector3 randomPosition = GetRandomPositionOnNavMesh(20f);
            nav.SetDestination(randomPosition);
        }

    }
    public Vector3 GetRandomPositionOnNavMesh(float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, distance, NavMesh.AllAreas))
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
            if (currentTime <= 0 && !isChasing)  // �����ϰ� ���� �ൿ�� ����
                ReSet();
        }
    }

    protected virtual void ReSet()  // ���� �ൿ �غ�
    {
        isAction = true;

        nav.ResetPath();

        isWalking = false;
        anim.SetBool("Walking", isWalking);
        isRunning = false;
        anim.SetBool("Running", isRunning);
        nav.speed = walkSpeed;

    }
    
    protected void TryWalk()  // �ȱ�
    {
        currentTime = walkTime;
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        nav.speed = walkSpeed;
        Debug.Log("�ȱ�");
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

            SoundManager.instance.PlaySound(sound_Hurt);
            anim.SetTrigger("Hurt");
        }
    }

    protected void Dead()
    {
        SoundManager.instance.PlaySound(sound_Dead);

        nav.enabled = false;
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetBool("Running", isRunning);
        anim.SetTrigger("Dead");

        nav.velocity = Vector3.zero;
        Invoke("ItemSpawn", deadTime + 2f);


    }

    private void ItemSpawn()
    {
        GetComponent<AnimalDeath>().ItemDrop(this.transform);
        this.gameObject.SetActive(false);
        Respawn();
    }

    private void Respawn()
    {
        if (gameObject.activeSelf == false)
        {

            isDead = false;
            Vector3 randomPosition = GetRandomPositionOnNavMesh(100f);
            this.gameObject.transform.position = randomPosition;
            nav.enabled = true;
            anim.SetTrigger("Reset");
            hp = firstHp;
            this.gameObject.SetActive(true);
            ReSet();



        }
    }

    protected void RandomSound()
    {
        if (sound_Normal.Length != 0)
        {
            int _random = Random.Range(0, sound_Normal.Length);  // ������ �ϻ� ����� 3 ��
            PlaySE(sound_Normal[_random]);
        }
    }

    protected void PlaySE(AudioClip _clip)
    {
        theAudio.clip = _clip;
        theAudio.Play();
    }
}


