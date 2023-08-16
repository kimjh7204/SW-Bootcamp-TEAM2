using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Portal1 portal1; // 포탈1 오브젝트
    public Portal2 portal2; // 포탈2 오브젝트

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Portal1 enteredPortal1 = other.GetComponent<Portal1>();
            if (enteredPortal1 != null && portal2 != null)
            {
                // 도착 포탈로 순간이동할 위치 계산
                Vector3 teleportPosition = portal2.destinationPortal.position + (transform.position - enteredPortal1.transform.position);

                // 순간이동
                transform.position = teleportPosition;
            }
        }
    }
}
