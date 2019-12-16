using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZoo : MonoBehaviour
{
    public void startGame()
    {
        var p = GameObject.Find("Player").GetComponent<player>();
        Time.timeScale = 1f;
        p.playerSpeed = 3;
    }
}
