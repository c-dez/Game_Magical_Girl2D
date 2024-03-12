using UnityEngine;

public class PlayerHealtScript : MonoBehaviour
{
    public int playerMaxHealt = 10;
    public int playerCurrentHealt;


    private void Awake()
    {
        playerCurrentHealt = playerMaxHealt;
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "enemy")//testing
        {

            if(colision.gameObject.name == "DroneEnemy")
            {
                EnemyStats enemyStats = colision.gameObject.GetComponent<EnemyStats>();

                playerCurrentHealt = ReciveDamage(playerCurrentHealt, enemyStats.damage);
                Debug.Log(colision.gameObject.name);

            }
            if (colision.gameObject.name == "GroundEnemy")
            {
                GroundEnemyStats groundEnemyStats = colision.gameObject.GetComponent<GroundEnemyStats>();
                playerCurrentHealt = ReciveDamage(playerCurrentHealt, groundEnemyStats.damage);
                Debug.Log(colision.gameObject.name);

            }

        } 
    }

    private int ReciveDamage(int playerCurrentHealt, int damage)
    {
        int returnHealth = playerCurrentHealt - damage;
        return returnHealth;

    }
}
