using UnityEngine;
using System.Collections;

public class SlimesController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 7f;
    public float jumpInterval = 0.8f;
    public float jumpForce = 8f;

    public float attackDistance = 2f;
    public float detectDistance = 10f;

    private Rigidbody rb;
    private Animator anim;
    private bool isReadyToJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the Slime object. Please add one.");
        }
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > detectDistance)
        {
            anim.SetBool("isAttacking", false);
            StopAllCoroutines();
            isReadyToJump = true;
        }
        else if (distance > attackDistance)
        {
            anim.SetBool("isAttacking", false);
            HandleMovement();
        }
        else
        {
            anim.SetBool("isAttacking", true);
            StopAllCoroutines();
            isReadyToJump = true;
        }
    }

    void HandleMovement()
    {
        Vector3 direction = (target.position - transform.position);
        direction.y = 0;
        direction = direction.normalized;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (isReadyToJump && IsGrounded())
        {
            StartCoroutine(JumpRoutine(direction));
        }
    }

    IEnumerator JumpRoutine(Vector3 direction)
    {
        isReadyToJump = false;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        rb.AddForce(direction * moveSpeed, ForceMode.VelocityChange);

        yield return new WaitForSeconds(jumpInterval);

        isReadyToJump = true;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
}