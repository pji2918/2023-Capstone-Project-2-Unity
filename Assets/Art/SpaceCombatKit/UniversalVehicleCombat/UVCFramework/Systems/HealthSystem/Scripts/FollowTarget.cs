using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;  // 따라갈 타겟 오브젝트의 Transform

    public float moveSpeed = 5f;  // 이동 속도

    void Start()
    {
        target = FindObjectOfType<PortalController>().transform;
    }
    void Update()
    {
        if (target != null)
        {
            // 타겟 방향 계산
            Vector3 direction = target.position - transform.position;

            // 정규화된 방향으로 이동
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
