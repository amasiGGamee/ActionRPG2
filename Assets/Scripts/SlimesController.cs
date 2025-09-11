using UnityEngine;

public class SlimesController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public float attackDistance = 2f; // ระยะโจมตี
    public float detectDistance = 10f; // ระยะเริ่มสนใจ Player

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > detectDistance)
        {
            // ไกลเกินไป → Idle
            anim.SetBool("isAttacking", false);
        }
        else if (distance > attackDistance)
        {
            // เดินเข้าหา Player
            Vector3 direction = (target.position - transform.position);
            direction.y = 0;
            direction = direction.normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);

            anim.SetBool("isAttacking", false);
        }
        else
        {
            // อยู่ในระยะโจมตี → โจมตีต่อเนื่อง
            anim.SetBool("isAttacking", true);
        }
    }
}
