using UnityEngine;

public class WallJump : MonoBehaviour
{
    //traer moveInput de PlayerController
    public float moveInput;
    private PlayerController playerController;
    private Rigidbody2D rb;
    [Header("Boxcast")]
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask wallLayer;

    public float wallSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        
    }
    private void FixedUpdate()
    {
        moveInput = playerController.moveInput;
        WallSlide();

        /*
        if hittingWall true && moveDir == -1 
        change friction
        give jump
        */
    }

    private void WallSlide()
    {
        if(HittingWall() && moveInput !=0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y,- wallSpeed,20 ));
        }

    }

    private bool HittingWall()
    {
        RaycastHit2D hit = 
        Physics2D.BoxCast(boxColider.bounds.center,boxSize,0,Vector2.right,0, wallLayer);

        if(hit.collider != null)
        {
            // Debug.Log("hit wall");
            return true;
        }
        else{
            return false;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxColider.bounds.center, boxSize);
    }
}
/*
walljump
con un boxcast detectar muros con tag
checar la direccion del input, hacia muro entra en
slide state
cambiar friccion y velocidad de caida
poder brincar



*/
