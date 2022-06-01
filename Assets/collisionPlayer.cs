using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collisionPlayer : MonoBehaviour
{
    int vidas = 3;
    public Text gameOver;
    public Text corazones;
    public GameObject player, camara, btn, pared;

    void Start()
    {
        gameOver.enabled = false;
        camara.SetActive(false);
        btn.SetActive(false);
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        corazones.text = vidas.ToString();
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(0, 1, 0);
            vidas--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Obstacle")
        {
            transform.position = new Vector3(0, 1, 0);
            vidas--;
        }
        if(vidas == 0)
        {
            Destroy(player, 0);
            gameOver.enabled = true;
            camara.SetActive(true);
            corazones.enabled = false;
            btn.SetActive(true);

        }
        if (collision.gameObject.name == "BUTTON")
        {
            pared.SetActive(false);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            pared.SetActive(true);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
