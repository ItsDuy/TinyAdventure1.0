using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("AnhDuy/PlayerAttack")]


public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public float attackCooldown = 1f;
    private bool canAttack = true;
    private int isAttackingId;

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isAttackingId=Animator.StringToHash("isAttacking");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Play attack animation
        anim.SetTrigger(isAttackingId);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(this.gameObject,attackDamage);
        }

        canAttack = false;
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


