using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Bindings")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Settings")]
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;



    Vector3 velocity;


    [Header("Jumping")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpForce = 6f;
    public float jumpHeight = 3f;



    

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
       

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("test");
            print(isGrounded);
        }

    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("entered trigger");
        if (other.gameObject.layer.ToString() == "Ground")
        {
            isGrounded = true;
            Debug.Log("Entered Collision");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
        if (collision.gameObject.layer.ToString() == "Ground")
        {
            isGrounded = false;
            Debug.Log("Exited Collision");
        }
    }
}
