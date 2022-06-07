using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;

    public Button trophyButton;
    public Button trophyCancel;

    public Sprite BronzeImg;
    public Sprite SilverImg;
    public Sprite GoldImg;

    public GameObject ScoreCanvas;

    public Image MedalImage;

    public Text scoreNumberText;
    public Text scoreGradeText;

    // Start is called before the first frame update
    void Start()
    {
        trophyButton.onClick.AddListener(trophyClicked);
        trophyCancel.onClick.AddListener(trophyCancelClicked);
    }

    // Update is called once per frame
    void Update()
    {
        scoreNumberText.text = "" + score;

        if(score < 100000)
        {
            scoreGradeText.text = "Bronze";
            MedalImage.sprite = BronzeImg;

        }
        else if(score >= 100000 && score < 1000000)
        {
            scoreGradeText.text = "Silver";
            MedalImage.sprite = SilverImg;
        }
        else
        {
            scoreGradeText.text = "Gold";
            MedalImage.sprite = GoldImg;
        }
    }
    void trophyClicked()
    {
        ScoreCanvas.SetActive(true);
    }
    void trophyCancelClicked()
    {
        ScoreCanvas.SetActive(false);
    }
}
