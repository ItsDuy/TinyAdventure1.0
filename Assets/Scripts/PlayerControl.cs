using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("AnhDuy/PlayerControl")]
public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f; 


    private Rigidbody2D rb;
    private Vector2 movement;
    private bool facingRight = true;
    private Animator anim;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        bool isWalking = movement.x != 0f || movement.y != 0f;
        anim.SetBool("isWalking", isWalking);
        if ((movement.x > 0 && !facingRight) || (movement.x < 0 && facingRight))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
