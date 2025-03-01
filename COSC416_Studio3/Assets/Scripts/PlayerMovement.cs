using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB; 
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpForce = 15f;
    [SerializeField] public float dashForce = 75f;
    [SerializeField] private CinemachineCamera freeLookCamera;
    private bool jumpReady = false;
    private bool doubleJumpReady = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 

    }

    public void MovePlayer(Vector2 inputVector)
    {
        Vector3 velocity = playerRB.linearVelocity;

        transform.rotation = Quaternion.Euler(0, freeLookCamera.transform.rotation.eulerAngles.y, 0);

        Vector3 directionalMovement = transform.forward * inputVector.y + transform.right * inputVector.x;

        playerRB.linearVelocity = new Vector3(directionalMovement.x *speed, velocity.y, directionalMovement.z*speed);
    }

    public void PlayerJump(bool wantToJump)
    {
        if (wantToJump && (jumpReady || doubleJumpReady))
        {
             playerRB.linearVelocity = new Vector3(playerRB.linearVelocity.x, jumpForce, playerRB.linearVelocity.z);

            if (jumpReady)
            {
                jumpReady = false;
            }
            else if (doubleJumpReady)
            {
                doubleJumpReady = false;
            }
            
        }
    }

    public void PlayerDash(bool wantToDash)
    {
        if (wantToDash)
        {
            Vector3 dashDirection = transform.forward;
            playerRB.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Surface"))
        {
            jumpReady = true;
            doubleJumpReady = true;
        } 
     
    }

    
}
