using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    
    //read from PlayerControllerScript
    private PlayerController playerController;
    private float moveInput;
    private bool isGrounded;

    //read from PlayerInputs Script
    private PlayerInputs playerInputs;
    private bool fire1;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerInputs = GetComponent<PlayerInputs>();
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        moveInput = playerController.moveInput;
        isGrounded = playerController.isGrounded;

        fire1 = playerInputs.fire1;

        anim.SetBool("run", moveInput != 0);
        anim.SetBool("jump", !isGrounded);
        
        anim.SetBool("fire", fire1);

    }
}
