using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_Ai : MonoBehaviour

{
    //movimiento
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private int  moveDirection;

    [Header("Patrol points")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;


    [Header("BoxCast")]
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private Vector3 boxOffset;
    [SerializeField] private Vector3 boxSize;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // boxColider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))//for testing
        {
            // Flip();
        }
    }
    private void FixedUpdate()
    {
        PatrolMovement();
        // Physics2D.BoxCast(boxColider.bounds.center, boxSize, 0, boxDirection);
    }

    //detect player
    private void OnDrawGizmos()
    {   
        Gizmos.color = Color.red;
        if(moveDirection == 1)
        {
            Gizmos.DrawWireCube(boxColider.bounds.center + boxOffset, boxSize);

        }
        else{
            Gizmos.DrawWireCube(boxColider.bounds.center + boxOffset *-1, boxSize);

        }



    }
    
/// <summary>
/// patrol movement
/// </summary>
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