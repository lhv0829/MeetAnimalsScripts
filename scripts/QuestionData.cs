using UnityEngine;
using System.Collections;

[System.Serializable]
public class QuestionData
{
    public string questionText;
    public AnswerData[] answers;

    public AudioSource audio;
    public AudioClip Sound;
}