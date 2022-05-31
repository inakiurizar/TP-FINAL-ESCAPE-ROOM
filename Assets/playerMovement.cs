using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMovement : MonoBehaviour
{
    float movement = 0.1f;
    float rotation = 1.5f;
    int JumpForce = 5;
    bool hasJump = true;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,movement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -movement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotation, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotation, 0);
        }
         if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasJump)
            {
                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                hasJump = false;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plataforma")
            {
                hasJump = true;
            }   
    }
 }


