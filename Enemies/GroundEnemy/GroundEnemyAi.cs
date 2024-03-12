using UnityEngine;

public class GroundEnemyAi : MonoBehaviour
{
    [Header("Move")]
    // [SerializeField] private int moveDir = 1;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    [Header("Patrol points")]
    [SerializeField] private Transform patrolRight;
    [SerializeField] private Transform patrolLeft;
    private bool movingRight = true;
    private Vector3 initSacale;

    private void Awake()
    {
        rb =  GetComponent<Rigidbody2D>();
        initSacale = transform.localScale;
    }

    private void FixedUpdate()
    {
        PatrolMovement();
    }

    private void MovingTo(int moveDir)
    {
        rb.velocity = new Vector3(moveSpeed * moveDir, 0,0);

    }

    private void ChangeDirection()
    {
        movingRight = !movingRight;
    }
    private void Flip(int moveDir)
    {
       transform.localScale = new Vector3 ((initSacale.x * moveDir)
            , initSacale.y, initSacale.z);
    }
    private void PatrolMovement()
        {
            if (movingRight)
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

