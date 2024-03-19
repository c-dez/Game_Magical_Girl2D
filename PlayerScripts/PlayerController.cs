using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //moving
    [Header("Move")]
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    public float moveInput;//public to be read by PlayerAnimationsScript
    private bool facingRight = true;

    //jumping
    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpTime;
    public bool isGrounded;//public to be read by PlayerAnimationsScript
    [SerializeField] private float checkRadius;
    [SerializeField] private int maxExtraJumps;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private float jumpCounter;
    private bool isJumping;
    private int extraJumps;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate()
    {
        FaceDirection();
        
        MovePlayer();
        CheckIsGrounded();

        
    }

    private void Update()
    {
        Jump();

        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        // {
        //     rb.velocity = Vector2.up * jumpForce;
        //     isJumping = true;
        //     jumpCounter = jumpTime;
        // }
        // if (isGrounded == false && extraJumps >= 1 && Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.velocity = Vector2.up * jumpForce * 1.2f;
        //     extraJumps--;
        // }
        // if (isGrounded == true)
        // {
        //     extraJumps = maxExtraJumps;
        // }
        // if(Input.GetKey(KeyCode.Space) && isJumping == true)
        // {
        //     if (jumpCounter > 0)
        //     {
        //         rb.velocity = Vector2.up * jumpForce;
        //         jumpCounter -= Time.deltaTime;
        //     }
        //     else
        //     {
        //         isJumping = false;
        //     }
        // }
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     isJumping = false;
        // }
    }

    private void Jump()
    {

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpCounter = jumpTime;
        }
        if(isJumping && Input.GetKey(KeyCode.Space))
        {
            if(jumpCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void FaceDirection()
    {
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void MovePlayer()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f,0);
    }
}
