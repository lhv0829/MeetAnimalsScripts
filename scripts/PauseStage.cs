using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStage : MonoBehaviour
{
    public void ChangeScene(int scene)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

