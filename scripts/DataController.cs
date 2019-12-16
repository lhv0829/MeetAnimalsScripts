using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    public string RoundName;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("MainMenu");
    }

    public RoundData GetCurrentRoundData(string RoundName)
    {
        this.RoundName = RoundName;
        if (RoundName.Equals("Farm"))
        {
            return allRoundData[0];
        }
        else
        {
            return allRoundData[1];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}