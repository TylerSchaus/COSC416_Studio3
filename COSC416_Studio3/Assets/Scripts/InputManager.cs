using UnityEngine.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent<bool> Jumping = new UnityEvent<bool>();
    public UnityEvent<bool> Dashing = new UnityEvent<bool>();
    private bool jumpReleased = true;
    private bool dashReleased = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 inputVector = Vector2.zero;
        bool jump = false;
        bool dash = false;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpReleased)
            {
                jump = true;
                jumpReleased = false;
            }   
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpReleased = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dashReleased)
            {
                dash = true;
                dashReleased = false;
            }
       
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            dashReleased = true;
        }

        OnMove?.Invoke(inputVector);
        Jumping?.Invoke(jump); 
        Dashing?.Invoke(dash);
    }
}

