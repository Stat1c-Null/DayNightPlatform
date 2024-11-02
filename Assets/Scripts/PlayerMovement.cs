using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public LayerMask groundLayer;
    public Transform feet;
    float moveDir;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int currentJumps;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentJumps = dayMaxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement direction
        moveDir = Input.GetAxisRaw("Horizontal");

        if((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && currentJumps > 0) {
            Jump();
        }

        //If on the ground, reset jumps
        if(IsGrounded()) {
            currentJumps = dayMaxJumps;
        }
        
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(dayMoveSpeed * moveDir, rb.velocity.y);

        rb.velocity = movement;
    }

    private void Jump(){
        Vector2 jump = new Vector2(rb.velocity.x, jumpForce);
        currentJumps -= 1;
        rb.velocity = jump;
    }

    private bool IsGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);

        if(groundCheck != null) {
            return true;
        }

        return false;
    }
}
