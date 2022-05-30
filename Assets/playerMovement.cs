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
    bool sePuedeMover = true;
    int vidas = 3;
    public Text gameOver;
    public Text corazones;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOver.enabled = false;
        
    }

    void Update()
    {
        corazones.text = vidas.ToString();
        if (Input.GetKey(KeyCode.W) && sePuedeMover)
        {
            transform.Translate(0,0,movement);
        }
        if (Input.GetKey(KeyCode.S) && sePuedeMover)
        {
            transform.Translate(0, 0, -movement);
        }
        if (Input.GetKey(KeyCode.A) && sePuedeMover)
        {
            transform.Rotate(0, -rotation, 0);
        }
        if (Input.GetKey(KeyCode.D) && sePuedeMover)
        {
            transform.Rotate(0, rotation, 0);
        }
         if (Input.GetKeyDown(KeyCode.Space) && sePuedeMover)
        {
            if (hasJump)
            {
                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                hasJump = false;
            }
        }
         if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 1, 0);
            vidas--;
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            hasJump = true;
        }
        if (collision.gameObject.name == "Obstacle")
        {
            transform.position = new Vector3(0, 1, 0);
            vidas--;
        }
        if(vidas == 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
            sePuedeMover = false;
            gameOver.enabled = true;
            gameOver.text = "GameOver";
        }
    }

}
