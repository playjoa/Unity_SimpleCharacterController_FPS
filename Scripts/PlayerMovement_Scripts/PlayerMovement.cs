using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform, groundChecker;

    [SerializeField]
    private CharacterController controllerPlayer;

    [SerializeField]
    [Range(2f, 10f)]
    private float playerHorizontalSpeed = 8;

    [SerializeField]
    private bool useGravity = true;

    [SerializeField]
    [Range(-20f, -9.8f)]
    private float gravityValue = -10;

    [SerializeField]
    [Range(0.1f, 1f)]
    private float groundDistance = 0.5f;

    [SerializeField]
    private LayerMask groundMask;

    private Vector3 gravityVelocity;
    private bool isGrounded;

    private void Update()
    {
        if (!GameState.IsPlayingFPS())
            return;

        MovePlayer();
        CalculateGravity();
    }

    void CalculateGravity() 
    {
        if (!useGravity)
            return;

        if (groundChecker == null)
            return;

        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

        //Reseting gravity speed
        if (isGrounded && gravityVelocity.y < 0)
            gravityVelocity.y = -1.5f;

        gravityVelocity.y += gravityValue * Time.deltaTime;

        controllerPlayer.Move(gravityVelocity * Time.deltaTime);
    }

    void MovePlayer() 
    {
        if (playerTransform == null)
            return;

        controllerPlayer.Move(PlayerMovementDirection());
    }

    Vector3 PlayerMovementDirection()
    {
        Vector3 baseDirection = playerTransform.right * PlayerInputs.MoveInputs().x +
                                playerTransform.forward * PlayerInputs.MoveInputs().y;

        baseDirection *= playerHorizontalSpeed * Time.deltaTime;

        return baseDirection;
    }
}
