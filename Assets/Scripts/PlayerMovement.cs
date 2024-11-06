using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

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
    static public bool isDay = true;
    float moveDir;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int currentJumps;
    private int maxJumps;
    private float moveSpeed;
    public Animator animator;
    [Header("Day/Night Animators")]
    public RuntimeAnimatorController nightAnimator;
    public RuntimeAnimatorController dayAnimator;

    [Header("Day/Night Swap")]
    public float swapCooldown = 1;
    static public UnityEvent swappedToDay = new UnityEvent();
    static public UnityEvent swappedToNight = new UnityEvent();
    bool canSwap = true;

    static private UnityEvent instanceSwappedToDay = new UnityEvent();
    static private UnityEvent instanceSwappedToNight = new UnityEvent();

    [Header("Events")]
    public UnityEvent onMove = new UnityEvent();
    public UnityEvent onIdle = new UnityEvent();
    public UnityEvent onGroundJump = new UnityEvent();
    public UnityEvent onAirJump = new UnityEvent();
    public UnityEvent onMoonAirJump = new UnityEvent();
    public UnityEvent onLand = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxJumps = dayMaxJumps;
        moveSpeed = dayMoveSpeed;
    }

    IEnumerator SwapCooldown()
    {
        canSwap = false;
        yield return new WaitForSeconds(swapCooldown);
        canSwap = true;
    }
    // Update is called once per frame
    void Update()
    {
        var oldMoveDire = moveDir;
        //Movement direction
        moveDir = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        //Turn player according to movement
        if (moveDir > 0f)
        {
            animator.transform.localScale = new Vector3(3f, 3f, 3f);
        }
        else if(moveDir < 0f)
        {
            animator.transform.localScale = new Vector3(-3f, 3f, 3f);
        }

        //Jumping
        if((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && currentJumps < maxJumps) {
            currentJumps += 1;
            if (isGrounded)
            {
                GroundJump();
                isGrounded = false;
            }
            else
            {
                AirJump();
                isGrounded = false;
            }
            animator.SetBool("isJumping", !isGrounded);
        }

        //Switch between day and night mode movement
        if(Input.GetKeyDown(KeyCode.E) && canSwap) {
            print("swapped");
            isDay = !isDay;
            maxJumps = isDay ? dayMaxJumps : nightMaxJumps;
            moveSpeed =  isDay ? dayMoveSpeed : nightMoveSpeed;
            StartCoroutine(SwapCooldown());

            //Change player animators and sprites based on day or night
            if (isDay)
            {
                swappedToDay.Invoke();
                animator.runtimeAnimatorController = dayAnimator;
            }
            else
            {
                swappedToNight.Invoke();
                animator.runtimeAnimatorController = nightAnimator;
            }
        }


        if (isGrounded)
        {
            if (moveDir - oldMoveDire > 0.7f)
            {
                onMove.Invoke();
            }
            else if (moveDir - oldMoveDire < -0.7f)
            {
                onIdle.Invoke();
            }
        }

    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(moveSpeed * moveDir, rb.velocity.y);

        rb.velocity = movement;
    }

    private void GroundJump(){
        Vector2 jump = new Vector2(rb.velocity.x, jumpForce);
        
        rb.velocity = jump;
        onGroundJump.Invoke();
    }

    private void AirJump()
    {
        Vector2 jump = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = jump;

        if (currentJumps == nightMaxJumps)
        {
            onMoonAirJump.Invoke();
            print("moon jump");
            return;
        }
        onAirJump.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.isTrigger) return;
        isGrounded = true;
        currentJumps = 0;
        animator.SetBool("isJumping", !isGrounded);
        onLand.Invoke();
    }
}
