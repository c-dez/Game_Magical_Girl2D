using UnityEngine;

public class GroundEnemyAi : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private Vector3 initScale;

    [Header("Patrol points")]
    [SerializeField] private Transform patrolLeft;
    [SerializeField] private Transform patrolRight;

    [Header("Raycast")]
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Vector3 rayOffSet;
    [SerializeField] private Vector3 raySize;


    private void Awake()
    {
        initScale = transform.localScale;
        rb =  GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        PatrolMovement();
        DetectPlayer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (facingRight)
        {
            Gizmos.DrawWireCube(boxColider.bounds.center + rayOffSet, raySize);

        }
        else
        {
            Gizmos.DrawWireCube(boxColider.bounds.center + rayOffSet * -1, raySize);

        }
        

    }

    private bool DetectPlayer()
    {
        if (facingRight)
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxColider.bounds.center + rayOffSet
                , raySize  
                , 0 ,Vector2.right, 0, playerLayer);

            return hit.collider != null;

        }
        else
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxColider.bounds.center + rayOffSet * -1
                , raySize  
                , 0 ,Vector2.right, 0, playerLayer);


            return hit.collider != null;
            
        }
    }


    private void MovingTo(int moveDir)
    {
        rb.velocity = new Vector3(moveSpeed * moveDir, 0,0);

    }

    private void ChangeDirection()
    {
        facingRight = !facingRight;
    }
    private void Flip(int moveDir)
    {
       transform.localScale = new Vector3 ((initScale.x * moveDir)
            , initScale.y, initScale.z);
    }
    private void PatrolMovement()
        {
            if (facingRight)
            {
                if (transform.position.x < patrolRight.transform.position.x)
                {
                    MovingTo(1);
                    Flip(-1);
                }
                else
                {
                    ChangeDirection();
                }
            }
            else
            {
                if (transform.position.x > patrolLeft.transform.position.x)
                {
                    MovingTo(-1);
                    Flip(1);
                }
                else
                {
                    ChangeDirection();
                }
            }

        }   
}

