using UnityEngine;

public class GroundEnemyLife : MonoBehaviour
{
    private GroundEnemyStats groundEnemyStats;
    private int life;

    private void Awake()
    {
        groundEnemyStats = GetComponent<GroundEnemyStats>();
        life = groundEnemyStats.life;
        
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "bullet")
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

   
}
