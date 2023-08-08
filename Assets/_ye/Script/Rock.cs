using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; // 바위의 체력. 0 이 되면 파괴됨

    [SerializeField]
    private int destroyTime; // 파괴된 바위의 파편들의 생명 (이 시간이 지나면 Destroy)

    [SerializeField]
    private SphereCollider col; // 구체 콜라이더. 바위 파괴시키면 비활성화시킬 것.

    [SerializeField]
    private GameObject go_rock;  // 일반 바위 오브젝트. 평소에 활성화, 바위 깨지면 비활성화
    [SerializeField]
    private GameObject go_debris;  // 깨진 바위 오브젝트. 평소에 비활성화, 바위 깨지면 활성화

    [SerializeField]
    private GameObject go_effect_prefabs;  // 채굴 이펙트 효과로 사용할 깨진 바위 오브젝트.


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
        // 바위가 파괴될 때 effect_sound_2 오디오 클립 재생
        SoundManager.instance.PlaySound(destroy_Sound);


        col.enabled = false;
        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, destroyTime);
    }
}
