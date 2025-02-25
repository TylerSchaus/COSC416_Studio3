using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB; 
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpForce = 15f;
    [SerializeField] private CinemachineCamera freeLookCamera;
    private bool jumpReady = false; 
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
        if (wantToJump && jumpReady)
        {
   
            Vector3 jumpPlane = new(0, 1, 0);
            playerRB.AddForce(jumpPlane * jumpForce, ForceMode.Impulse);
            jumpReady = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Surface"))
        {
            jumpReady = true; 
        } 
    
    }
}
