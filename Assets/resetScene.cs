using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class resetScene : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
