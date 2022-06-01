using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehaviour : MonoBehaviour
{
     void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            transform.position = new Vector3(0, -0.06f, 10);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            transform.position = new Vector3(0, 0, 10);
        }
    }
}
