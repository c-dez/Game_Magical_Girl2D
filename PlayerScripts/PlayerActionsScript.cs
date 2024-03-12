using UnityEngine;

public class PlayerActionsScript : MonoBehaviour
{
    //read from PlayerInputs Script
    private PlayerInputs playerInputs;
    private bool fire1;
    private bool fire2;
    private bool Q_key;
    private bool E_key;

    //FirePoint
    private GameObject firePoint;

    //bullet prefap
    public GameObject bulletPrefap;

    private void Awake()
    {
        playerInputs = GetComponent<PlayerInputs>();
        firePoint = GameObject.Find("FirePoint");
    }

    private void Update()
    {
        fire1 = playerInputs.fire1;
        fire2 = playerInputs.fire2;
        Q_key = playerInputs.Q_key;
        E_key = playerInputs.E_key;

        if (fire1)
        {
            Shoot();
        }



    }

    private void Shoot()
    {
        Instantiate(bulletPrefap, firePoint.transform.position, firePoint.transform.rotation);
    }
}
