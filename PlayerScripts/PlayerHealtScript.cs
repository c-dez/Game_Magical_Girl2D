using UnityEngine;

public class PlayerHealtScript : MonoBehaviour
{
    public int playerMaxHealt = 10;
    public int playerCurrentHealt;


    private void Awake()
    {
        playerCurrentHealt = playerMaxHealt;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")//testing
        {
            if(collision.gameObject.name == "DroneEnemy")
            {
                EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
                playerCurrentHealt = ReciveDamage(playerCurrentHealt, enemyStats.damage);
                Debug.Log(collision.gameObject.name);
            }
            if (collision.gameObject.name == "GroundEnemy")
            {
                GroundEnemyStats groundEnemyStats = collision.gameObject.GetComponent<GroundEnemyStats>();
                playerCurrentHealt = ReciveDamage(playerCurrentHealt, groundEnemyStats.damage);
                Debug.Log(collision.gameObject.name);
            }
        } 
        
        if(collision.gameObject.tag == "bullet")
        {
            playerCurrentHealt -= 1;
        }
    }

    private int ReciveDamage(int playerCurrentHealt, int damage)
    {
        int returnHealth = playerCurrentHealt - damage;
        return returnHealth;

    }
}
