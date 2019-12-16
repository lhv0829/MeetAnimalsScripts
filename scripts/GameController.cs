using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    bool gDraw = false;
    public Vector3 touchpos;
    string boxContent;


    public Object animal;

    public GameObject NextQuestion;

    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;


    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private AnswerAnimal answerAnimal;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    public int playerScore;
    private int[] randomArray;
    private PauseMenu pause;

    public GameObject correctPanel;
    public GameObject uncorrectPanel;

    //sound
    private AudioSource audio;
    public AudioClip beepSound;

    private AudioSource animalEffect;
    public AudioClip animalSound;

    private AudioSource audioCorrect;
    public AudioClip correctSound;

    //오브젝트 거리
    private float distance;
    private player player;

    //게임 끝났을 때
    public GameObject finishedPanel;
    int distance2 = 35;
    private GameController controller;
    public Text scoreText;


    private bool paused;
    public bool isPanelShown;

    //오브젝트와 거리
    public int dist = 15;
    private bool isSignShown;
    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData("Farm");
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;

       
        

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.beepSound;
        this.audio.loop = false;

        this.animalEffect = this.gameObject.AddComponent<AudioSource>();
        this.animalEffect.clip = this.animalSound;
        this.animalEffect.loop = false;

        this.audioCorrect = this.gameObject.AddComponent<AudioSource>();
        this.audioCorrect.clip = this.correctSound;
        this.audioCorrect.loop = false;
        
        //distance = Vector3.Distance(player.transform.position, transform.position);

        playerScore = currentRoundData.score = 0;
        questionIndex = 0;
        
        isRoundActive = true;
        isPanelShown = false;
        isSignShown = false;

        RamdomQuestion(11);
        correctPanel = GameObject.FindGameObjectWithTag("correct");
        correctPanel.SetActive(false);

        uncorrectPanel = GameObject.FindGameObjectWithTag("uncorrect");
        uncorrectPanel.SetActive(false);

        finishedPanel = GameObject.FindGameObjectWithTag("gameFinished");
        finishedPanel.SetActive(false);

        UpdateTimeRemainingDisplay();

        ShowQuestion();


        UpdateTimeRemainingDisplay();

    }


    private void RamdomQuestion(int num)
    {
        randomArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            randomArray[i] = Random.Range(0, num);
        }


    }

    private void ShowQuestion()
    {

       
        QuestionData questionData = questionPool[(int)randomArray[questionIndex]];


        questionDisplayText.text = questionData.questionText;


        //Invoke("SetSound", 1.5f);
        

    }

    void SetSound()
    {
        questionPool[(int)randomArray[questionIndex]].audio = gameObject.AddComponent<AudioSource>();
        questionPool[(int)randomArray[questionIndex]].audio.clip = questionPool[(int)randomArray[questionIndex]].Sound;
        questionPool[(int)randomArray[questionIndex]].audio.loop = false;
        questionPool[(int)randomArray[questionIndex]].audio.Play();
    }

    void SetInit()
    {
        correctPanel.SetActive(false);
        uncorrectPanel.SetActive(false);
        isSignShown = false;
    }

    void TouchClick()
    {
        if (questionIndex == 10)
        {
            EndRound();
        }
        else
        {
        if ((Input.GetButton("Fire1")))
        {
            RaycastHit hit;

            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(touchray, out hit);

                
            if(hit.distance <= dist)
            {

                    if (hit.collider != null)
                    {
                        if (gDraw == false)
                        {
                            gDraw = true;
                        }
                        else
                        {
                            gDraw = false;
                        }
                        Debug.Log(hit.collider.gameObject.name);

                        paused = GameObject.Find("Main Camera").GetComponent<FarmPauseMenu>().isPaused;
                        if (hit.collider.gameObject.tag.Equals("Animal") && paused != true && isSignShown == false)
                        {
                            if (questionDisplayText.text.Equals(hit.collider.gameObject.name))
                            {
                                playerScore += 10;
                                currentRoundData.score += 10;
                                Debug.Log(currentRoundData.score);
                                scoreDisplayText.text = "Score: " + playerScore.ToString();


                                this.audioCorrect.Play();
                                this.animalEffect = GameObject.Find(hit.collider.gameObject.name).GetComponent<AudioSource>();
                                this.animalEffect.Play();

                                correctPanel.SetActive(true);
                                isSignShown = true;

                                Invoke("SetInit", 1f);
                                questionIndex++;
                                ShowQuestion();

                            }

                            else
                            {
                                uncorrectPanel.SetActive(true);
                                isSignShown = true;
                                this.audio.Play();
                                Invoke("SetInit", 1f);
                                ShowQuestion();
                            }


                        }




                    }
                }
            
        }
        
            }
        if (Input.touchCount >= 1)
        {
            touchpos = Input.GetTouch(0).position;
            boxContent = "위치\r\n" + touchpos;
        }


    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
            questionIndex++;
            ShowQuestion();
        }

        if (questionIndex > 10)
        {
            EndRound();
        }


    }

    public void EndRound()
    {
        isRoundActive = false;
        isPanelShown = true;
        questionDisplay.SetActive(false);

        Debug.Log("끝났어");
        showPanel();
    }

    private void showPanel()
    {
        var p = GameObject.Find("Player").GetComponent<player>();
        Vector3 forward = GameObject.Find("Main Camera").transform.forward;
        forward.y = 0;
        isPanelShown = true;

        if (isRoundActive == false)
        {
            finishedPanel.SetActive(true);
            scoreText.text = "Score : " + playerScore.ToString();
            
            finishedPanel.transform.position = GameObject.Find("Main Camera").transform.position + forward * 5;
            finishedPanel.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
            
            p.playerSpeed = 0;
            
        }
        
    }

    private void UpdateTimeRemainingDisplay()
    {
        TouchClick();

        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()

    {
        //showPanel();
        
        if (isRoundActive)
        {

            timeRemaining -= Time.deltaTime;

            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }
        }


    }

}