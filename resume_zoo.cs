using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume_zoo : MonoBehaviour
{
    GameObject pausePanel;


    // Start is called before the first frame update
    public void resumeGame()
    {
        var p = GameObject.Find("Player").GetComponent<player>();
        pausePanel = GameObject.FindGameObjectWithTag("pause");
        pausePanel.SetActive(false);
        p.playerSpeed = 3;
        Time.timeScale = 1f;
        GameObject.Find("Main Camera").GetComponent<ZooPauseMenu>().isPaused = false;

    }
}
