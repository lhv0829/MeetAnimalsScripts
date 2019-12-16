using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        var p = GameObject.Find("Player").GetComponent<player>();
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        p.playerSpeed = 0;
        Time.timeScale = 0;
    }
}
