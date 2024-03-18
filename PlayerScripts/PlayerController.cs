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
    public bool isGrounded;//public to be read by PlayerAnimationsScript
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    [SerializeField] private float jumpTime;
    private float jumpCounter;
    private bool isJumping;
    public int maxExtraJumps = 1;
    private int extraJumps;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpCounter = jumpTime;
        }
        if (isGrounded == false && extraJumps >= 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce * 1.2f;
            extraJumps--;
        }
        if (isGrounded == true)
        {
            extraJumps = maxExtraJumps;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f,0);
    }
}
