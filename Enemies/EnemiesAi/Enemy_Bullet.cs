using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
     {
     private Rigidbody2D rb;
     [SerializeField] private float bulletSpeed = 6f;


     private void Awake()
     {
          rb = GetComponent<Rigidbody2D>();
     }

     private void FixedUpdate()
     {
          rb.velocity = transform.right * bulletSpeed * -1;
          
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
          Destroy(gameObject);
          if (collision.gameObject.tag != "enemy")
          {

          }
     }
   

}
