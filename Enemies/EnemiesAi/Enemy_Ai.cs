using UnityEngine;

public class Enemy_Ai : MonoBehaviour

{
    //movimiento
    [SerializeField] private float moveSpeed = 5f;
    private int  moveDirection;

    [Header("Patrol points")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;


    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))//for testing
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        PatrolMovement();
    }

    private void PatrolMovement()
    {
        CheckFacingDirection();
        
        if( moveDirection == -1)
        {
            if(transform.position.x > leftPoint.transform.position.x)
            {
                rb.velocity = new Vector3(moveSpeed * moveDirection, rb.velocity.y,0);
            }
            else{
                Flip();
            }
        }
        if(moveDirection == 1)
        {
            if(transform.position.x < rightPoint.transform.position.x)
            {
                rb.velocity = new Vector3(moveSpeed * moveDirection, rb.velocity.y,0);
            }
            else{
                Flip();
            }
        }
    }
    private void Flip()
    {
        CheckFacingDirection();
        if (moveDirection == -1)
        {
            transform.Rotate(0,180,0);
        }
        if (moveDirection == 1)
        {
            transform.Rotate(0,-180,0);
        }
    }
    private void CheckFacingDirection()
    {
        if(transform.localRotation.y == 0)
        {   
            moveDirection = -1;
        }
        else{
            moveDirection = 1;
        }
    }
}