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
    [SerializeField] private int maxExtraJumps;
    private float jumpCounter;
    private bool isJumping;

    [Header("Ground check")]
    public bool isGrounded;//public to be read by PlayerAnimationsScript
    public LayerMask whatIsGround;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Vector3 boxOffset;
    [SerializeField] private Vector3 boxSize;

    [Header("Wall check")]
    [SerializeField] private bool isWalled;// serialized for testing
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private Vector3 wallBoxSize;





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate()
    {
        MovePlayer();
        BoxCastGroundCheck();
        BoxCastWallCheck();

        
    }

    private void Update()
    {
        Jump();

       
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + boxOffset, boxSize);//groundCheck

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center, wallBoxSize);//wall check


    }

    private bool BoxCastGroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast
        (boxCollider2D.bounds.center + boxOffset,boxSize, 0 , Vector2.right, 0, whatIsGround);

        if (hit.collider != null)
        {
            isGrounded = true;
            return isGrounded;
        }
        else{
            isGrounded = false;
            return isGrounded;
        }
    }

    private bool BoxCastWallCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast
        (boxCollider2D.bounds.center, wallBoxSize, 0, Vector2.right, 0 , whatIsWall );
        
        if(hit.collider != null)
        {
            isWalled = true;
            return isWalled;
        }
        else{
            isWalled = false;
            return isWalled;
        }
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
        FaceDirection();
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f,0);
    }
}
