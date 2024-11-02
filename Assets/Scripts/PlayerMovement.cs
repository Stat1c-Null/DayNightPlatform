using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [Header("Day Movement")]
    
    public float dayMoveSpeed;
    public int dayMaxJumps;
    
    [Header("Night Movement")]
    public float nightMoveSpeed;
    public int nightMaxJumps;

    [Header("Stats")]
    public int healthAmount;
    public float jumpForce;
    public bool isDay;
    float moveDir;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int currentJumps;
    private int maxJumps;
    private float moveSpeed;
    Animator animator;
    [Header("Day/Night Animators")]
    public RuntimeAnimatorController nightAnimator;
    public RuntimeAnimatorController dayAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maxJumps = dayMaxJumps;
        moveSpeed = dayMoveSpeed;
        isDay = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement direction
        moveDir = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        //Turn player according to movement
        if (moveDir > 0f)
        {
            transform.localScale = new Vector3(3f, 3f, 4f);
        }
        else if(moveDir < 0f)
        {
            transform.localScale = new Vector3(-3f, 3f, 4f);
        }

        //Jumping
        if((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && currentJumps < maxJumps) {
            currentJumps += 1;
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            Jump();
        }

        //Switch between day and night mode movement
        if(Input.GetKeyDown(KeyCode.E)) {
            isDay = !isDay;
            maxJumps = isDay ? dayMaxJumps : nightMaxJumps;
            moveSpeed =  isDay ? dayMoveSpeed : nightMoveSpeed;
        }

        //Change player animators and sprites based on day or night
        if(isDay) {
            animator.runtimeAnimatorController = dayAnimator;
        } else {
            animator.runtimeAnimatorController = nightAnimator;
        }
        
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(moveSpeed * moveDir, rb.velocity.y);

        rb.velocity = movement;
    }

    private void Jump(){
        Vector2 jump = new Vector2(rb.velocity.x, jumpForce);
        
        rb.velocity = jump;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isGrounded = true;
        currentJumps = 0;
        animator.SetBool("isJumping", !isGrounded);
    }
}
