using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB; 
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpForce = 15f;
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
        Vector3 inputXYZPlane = new(inputVector.x, 0, inputVector.y);
        playerRB.AddForce(inputXYZPlane * speed);
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
