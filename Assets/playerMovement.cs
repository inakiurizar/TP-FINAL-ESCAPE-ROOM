using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public GameObject cam1, cam2;
    float movement = 0.1f;
    float rotation = 2f;
    int JumpForce = 5;
    bool hasJump = true;
    Rigidbody rb;
    float shift;
    bool esver;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shift = movement * 2;
        cam2.SetActive(false);
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
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
                transform.Translate(0, 0, shift);
                cam1.SetActive(false);
                cam2.SetActive(true);
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


