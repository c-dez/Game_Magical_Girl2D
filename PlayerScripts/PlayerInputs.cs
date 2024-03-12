using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool fire1;
    public bool fire2;
    public bool E_key;
    public bool Q_key;

    private void Update()
    {
        fire1 = Input.GetKeyDown(KeyCode.Mouse0);
        fire2 = Input.GetKeyDown(KeyCode.Mouse1);
        E_key = Input.GetKeyDown(KeyCode.E);
        Q_key = Input.GetKeyDown(KeyCode.Q);

    }
}
