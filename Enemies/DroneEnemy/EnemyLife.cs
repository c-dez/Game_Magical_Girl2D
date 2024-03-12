using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private EnemyStats enemyStats;
    //stats
    private int life;



    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
        life = enemyStats.life;    
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "bullet")
        {
            life--;//hard code, cambiar a life - bullet.damage
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    
}
