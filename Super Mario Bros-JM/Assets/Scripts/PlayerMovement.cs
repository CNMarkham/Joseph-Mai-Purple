using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    private RaycastHit2D hit;
    public float jumpForce;
    public bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * horizontal * moveSpeed * Time.deltaTime);

        Jump();
        FlipDirection();
        ChangeAnimations();
    }
    private void Jump()
    {
        hit = Physics2D.CircleCast(rb.position, 0.25f, Vector2.down, 0.375f, LayerMask.GetMask("Default"));

        if (hit.collider != null && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            jumping = true;
            Invoke("ResetJumping", 0.5f);

        }
        if (jumping && Input.GetKey(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }

    }
    private void ResetJumping()
    {
        jumping = false;
    }

    private void FlipDirection()
    {
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.flipX = rb.velocity.x < 0;
        }
    }
    private void ChangeAnimations()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>()) // Makes the animation work
        {
            animator.SetFloat("velocityX", rb.velocity.x); 
            animator.SetFloat("horizontalInput", Input.GetAxis("Horizontal")); //flips the animation when running
            animator.SetBool("inAir", hit.collider == null || jumping); // makes the jump animation when jumping
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//checks collision
    {
        float distance = 0.375f;//checks if it the distance is going up //raycast going up

        if(GetComponent<PlayerBehaviour>().big)//if mario is bigger than raycast will increase
        {
            distance += 1f; //adds 1 feet to the raycast
        }

        RaycastHit2D hitTop = Physics2D.CircleCast(rb.position, 0.25f, Vector2.up, distance, LayerMask.GetMask("Default"));// creates a circle cast

        if (hitTop.collider != null)// checks if it is hitting anything
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0;//sets the veloity to 0 so it can not jump
            rb.velocity = velocity;
            jumping = false;//sets jumping to false
            
            BlockHit blockHit = hitTop.collider.gameObject.GetComponent<BlockHit>();//gets the block hit game object
            if (blockHit != null)//if blockhit is something
            {
                blockHit.Hit();//call block hit
            }
        }

       
        

    }
}
