using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
private GameObject player;
private int playerCurrentHealt;
private int playerMaxHealt;

private Slider slider;




    private void Awake()
    {
        GetPlayerValues();
        GetSliderValues();

        playerCurrentHealt = playerMaxHealt;

    }

    private void Update()
    {
        HealtBar();
    }

    private void HealtBar()
    {
        playerCurrentHealt = player.GetComponent<PlayerHealtScript>().playerCurrentHealt;
        slider.value = playerCurrentHealt;
    }

    private void GetPlayerValues()
    {
        player = GameObject.Find("Player");
        playerMaxHealt = player.GetComponent<PlayerHealtScript>().playerMaxHealt;
    }

    private void GetSliderValues()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = playerMaxHealt;
    }
        

}
