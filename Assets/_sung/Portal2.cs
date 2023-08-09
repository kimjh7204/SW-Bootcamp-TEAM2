using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public Transform destinationPortal; // 도착 포탈의 Transform

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            // 도착 포탈로 순간이동할 위치 계산
            Vector3 teleportPosition = destinationPortal.position + (other.transform.position - transform.position);

            // 순간이동
            other.transform.position = teleportPosition;
        }
    }
}
