using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz_Script : MonoBehaviour
{
    private int Q1Number = 10;
    private int Q2Number = 10;
    private int Q3Number = 10;
    private int Q4Number = 10;
    private int Q5Number = 10;

    public List<Sprite> Q1List = new List<Sprite>();
    public List<Sprite> Q2List = new List<Sprite>();
    public List<Sprite> Q3List = new List<Sprite>();
    public List<Sprite> Q4List = new List<Sprite>();
    public List<Sprite> Q5List = new List<Sprite>();

    public List<string> A1List = new List<string>();
    public List<string> A2List = new List<string>();
    public List<string> A3List = new List<string>();
    public List<string> A4List = new List<string>();
    public List<string> A5List = new List<string>();

    public Image QuizImage;
    public InputField inputfield;
    public Text inputAnswer;
    public Database_Script database;


    public Button Examine1;
    public Button Examine2;
    public Button Examine3;
    public Button Examine4;
    public Button Examine5;

    public GameObject QuizUI;

    public int WhichQuestion = 0;
    public int WhichNumber = 0;

    public bool isAnswerUpdated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showQuiz()
    {
        QuizUI.SetActive(true);

        if (WhichQuestion == 1)
        {
            WhichNumber = Random.Range(0, Q1Number);
            QuizImage.sprite = Q1List[WhichNumber];
        }
        if (WhichQuestion == 2)
        {
            WhichNumber = Random.Range(0, Q2Number);
            QuizImage.sprite = Q2List[WhichNumber];
        }
        if (WhichQuestion == 3)
        {
            WhichNumber = Random.Range(0, Q3Number);
            QuizImage.sprite = Q3List[WhichNumber];
        }
        if (WhichQuestion == 4)
        {
            WhichNumber = Random.Range(0, Q4Number);
            QuizImage.sprite = Q4List[WhichNumber];
        }
        if (WhichQuestion == 5)
        {
            WhichNumber = Random.Range(0, Q5Number);
            QuizImage.sprite = Q5List[WhichNumber];
        }

    }
    public void hideQuiz()
    {
        isAnswerUpdated = false;
        QuizUI.SetActive(false);
    }

    public bool solveQuiz()
    {
        string answer = inputAnswer.text;
        bool result = false;
        if (WhichQuestion == 1)
        {
            if (answer == A1List[WhichNumber])
                result = true;
            else
                result = false;
        }
            
        else if (WhichQuestion == 2)
        {
            if (answer == A2List[WhichNumber])
                result = true;
            else
                result = false;
        }            
        else if (WhichQuestion == 3)
        {
            if (answer == A3List[WhichNumber])
                result = true;
            else
                result = false;
        }            
        else if (WhichQuestion == 4)
        {
            if (answer == A4List[WhichNumber])
                result = true;
            else
                result = false;
        }            
        else if (WhichQuestion == 5)
        {
            if (answer == A5List[WhichNumber])
                result = true;
            else
                result = false;
        }            
        else
            Debug.Log("Error: WhichQuestion Empty");

        if (result == true)
            Debug.Log("Answer!");
        else
            Debug.Log("Wrong Answer!");

        return result;
    }

}
