using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerAnimal : MonoBehaviour
{

    public Object Animal;
    public string animalName;

    private AnswerData answerData;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        animalName = this.gameObject.name;
    }


    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}