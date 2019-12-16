
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneCtrl : MonoBehaviour
{
    public GameObject tutorialImage = GameObject.FindGameObjectWithTag("tutorial");

    public void ChangeScene(string sceneName)
    {
        var p = GameObject.Find("Player").GetComponent<player>();

        SceneManager.LoadScene(sceneName);

        Time.timeScale = 0;
        p.playerSpeed = 0;

        //tutorialImage.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
