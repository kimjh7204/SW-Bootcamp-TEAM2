using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; // ������ ü��. 0 �� �Ǹ� �ı���

    [SerializeField]
    private int destroyTime; // �ı��� ������ ������� ���� (�� �ð��� ������ Destroy)

    [SerializeField]
    private SphereCollider col; // ��ü �ݶ��̴�. ���� �ı���Ű�� ��Ȱ��ȭ��ų ��.

    [SerializeField]
    private GameObject go_rock;  // �Ϲ� ���� ������Ʈ. ��ҿ� Ȱ��ȭ, ���� ������ ��Ȱ��ȭ
    [SerializeField]
    private GameObject go_debris;  // ���� ���� ������Ʈ. ��ҿ� ��Ȱ��ȭ, ���� ������ Ȱ��ȭ

    [SerializeField]
    private GameObject go_effect_prefabs;  // ä�� ����Ʈ ȿ���� ����� ���� ���� ������Ʈ.


    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destroy_Sound;


    public void Mining()
    {
        SoundManager.instance.PlaySound(strike_Sound);

        GameObject clone = Instantiate(go_effect_prefabs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destroyTime);

        hp--;
        if (hp <= 0)
            Destruction();
    }

    private void Destruction()
    {
        // ������ �ı��� �� effect_sound_2 ����� Ŭ�� ���
        SoundManager.instance.PlaySound(destroy_Sound);


        col.enabled = false;
        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, destroyTime);
    }
}
