using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 20f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   private void FixedUpdate()
   {
        rb.velocity = transform.right * bulletSpeed;
   }

   private void OnCollisionEnter2D(Collision2D colision)
   {
        Destroy(gameObject);
   }
}
