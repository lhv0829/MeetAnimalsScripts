using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pausePanel;
    int distance = 35;
    public bool isPaused;
    private bool panelShown;
    // Start is called before the first frame update
    public void Start()
    {
        pausePanel = GameObject.FindGameObjectWithTag("pause");
        pausePanel.SetActive(false);
        isPaused = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        var p = GameObject.Find("Player").GetComponent<player>();
        Vector3 forward = this.transform.forward;
        forward.y = 0;

        if ((transform.eulerAngles.x >= 85) && (transform.eulerAngles.x <= 90))
        {
            print("look down");
            pausePanel.SetActive(true);
            pausePanel.transform.position = this.transform.position + forward * distance;
            pausePanel.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
            p.playerSpeed = 0;
            Time.timeScale = 0;
            isPaused = true;
        } 
      
    }

}
