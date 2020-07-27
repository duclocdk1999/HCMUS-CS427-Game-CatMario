using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer;

    bool isGrounded;

    [SerializeField]
    protected Transform groundCheck;

    [SerializeField]
    protected float runSpeed;

    [SerializeField]
    protected float jumpSpeed;
    // -------------------------------------------------------------------------
    // Use this for initialization
    public void Start () {
        animator = GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
	}
	// -------------------------------------------------------------------------
	// Update is called once per frame
	public void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) 
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        bool go_left = Input.GetKey(KeyCode.LeftArrow);
        bool go_right = Input.GetKey(KeyCode.RightArrow);
        bool go_up = Input.GetKey(KeyCode.UpArrow);

        if (go_left || go_right || go_up)
        {
            if (go_left)
            {
                body2D.velocity = new Vector2(-runSpeed, body2D.velocity.y);
                if (!go_up)
                    animator.Play("player_run");
                renderer.flipX = true;
            }
            if (go_right)
            {
                body2D.velocity = new Vector2(runSpeed, body2D.velocity.y);
                if (!go_up)
                    animator.Play("player_run");
                renderer.flipX = false;
            }
            if (go_up && isGrounded)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, jumpSpeed);
                // body2D.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
                animator.Play("player_jump");
            }
        }
        else
        {
            animator.Play("player_idle");
            body2D.velocity = new Vector2(0, body2D.velocity.y);
        }
    }
    // -------------------------------------------------------------------------
    public void Update()
    {

    }
    // -------------------------------------------------------------------------
    public void OnHurtByEnemy()
    {
        animator.Play("player_hurt");
    }
}
