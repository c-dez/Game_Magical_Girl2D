using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private bool showGizmos;
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
    public bool isTouchingWall; //public to be read in the future for PlayerAnimation?
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private Vector3 wallBoxSize;

    [Header("Wall Jump")]
    private bool isWallJumping = false;
    [SerializeField] private float wallJumpForce = 30f;
    [SerializeField] private float WallSlideSpeed;




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
        WallJump();
        WallSlide();
    }

    
    private void WallSlide() //incompleto
    {
        if(isTouchingWall && moveInput != 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, -WallSlideSpeed);
            //por hacer: cuando estoy sliding y salto por primera vez, salta, a la segunda vez saltar, no lo hace y deja de slide
        }
    }

    private void WallJump()
    {
         if(!isWallJumping  && isTouchingWall && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, wallJumpForce);
            isWallJumping = true;
        }
        if(isWallJumping  && !isTouchingWall)
        {
            isWallJumping = false;
        }
        if(isGrounded && isTouchingWall)
        {
            isWallJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        if(showGizmos)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(boxCollider2D.bounds.center + boxOffset, boxSize); //groundCheck

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(boxCollider2D.bounds.center, wallBoxSize); //wall check
        }


    }
    private void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpCounter = jumpTime;
        }
        if(isJumping && !isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if(isJumping && Input.GetKey(KeyCode.Space))
        {
            if(jumpCounter> 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpCounter -= Time.deltaTime;
            }
        }
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
            isTouchingWall = true;
            return isTouchingWall;
        }
        else{
            isTouchingWall = false;
            return isTouchingWall;
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
