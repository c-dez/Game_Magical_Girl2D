using Unity.VisualScripting;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [Header("Boxcast")]
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask wallLayer;
    private bool hittingWall;

    private void FixedUpdate()
    {
        hittingWall = HittingWall();
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
