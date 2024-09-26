using System.Collections;
using UnityEngine;

[AddComponentMenu("AnhDuy/EnemyAI")]
public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Transform currentTarget;
    public Transform pointAttack;

    public float moveSpeed = 0.25f;
    public float waitTime = 1f;
    public float attackRadius = 1f;
    public float requiredDistance = 5f;
    public float attackRate = 1f;
    public int attackDamage = 10;

    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = false;
    private Transform player;
    private bool isAttackOnCooldown = false;
    // private Enemy enemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // enemy = GetComponent<Enemy>();
        currentTarget = pointB;
        StartCoroutine(MoveBetweenPoints());
    }

    private IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            // if (enemy.CurrentHealth <= 0)
            // {
            //     rb.velocity = Vector2.zero;
            //     animator.SetBool("isWalking", false);
            //     yield break; 
            // }

            if (player != null && Vector2.Distance(pointAttack.position, player.position) <= requiredDistance)
            {

                MoveTowards(player.position);
                if (Vector2.Distance(pointAttack.position, player.position) <= attackRadius && !isAttackOnCooldown)
                {
                    StartCoroutine(PerformAttack());
                }
            }
            else
            {

                MoveTowards(currentTarget.position);
                if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("isWalking", false);
                    yield return new WaitForSeconds(waitTime);
                    currentTarget = (currentTarget == pointA) ? pointB : pointA;
                    Flip();
                }
            }
            yield return null;
        }

    }

    private void MoveTowards(Vector2 target)
    {
        // if (enemy.CurrentHealth <= 0) return; 
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        animator.SetBool("isWalking", true);
    }



    private void Flip()
    {

        if ((currentTarget == pointB && !facingRight) || (currentTarget == pointA && facingRight))
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private IEnumerator PerformAttack()
    {
        // if (enemy.CurrentHealth <= 0) yield break;
        
            isAttackOnCooldown = true;
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f);
            if (player != null && Vector2.Distance(pointAttack.position, player.position) <= attackRadius)
            {
                player.GetComponent<Player>().TakeDamage(gameObject, attackDamage);
            }
            yield return new WaitForSeconds(attackRate);
            isAttackOnCooldown = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
