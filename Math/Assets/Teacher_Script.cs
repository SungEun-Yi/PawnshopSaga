using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher_Script : MonoBehaviour
{
    public Button helpButton;
    public GameObject Buttons;

    public Button Material_Help;
    public Button Quality_Help;
    public Button Year_Help;
    public Button Fame_Help;
    public Button Brand_Help;

    public Button closeButton;

    public Button nextButton;

    public GameObject InstructionScreen;
    public Image InstructionImage;

    private int materialImgNum = 1;
    private int qualityImgNum = 1;
    private int yearImgNum = 1;
    private int fameImgNum = 2;
    private int brandImgNum = 3;

    public Sprite Material_Image1;
    public Sprite Quality_Image1;
    public Sprite Year_Image1;
    public Sprite Fame_Image1;
    public Sprite Fame_Image2;
    public Sprite Brand_Image1;
    public Sprite Brand_Image2;
    public Sprite Brand_Image3;

    private int whichScreen = 0; // 1 = Mat, 2  = Quality, 3 = Year, 4 = Fame, 5 = Brand

    private int materialPointer = 0;
    private int qualityPointer = 0;
    private int yearPointer = 0;
    private int famePointer = 0;
    private int brandPointer = 0;

    public GameObject BG;

    // Start is called before the first frame update
    void Start()
    {
        helpButton.onClick.AddListener(helpButtonClicked);

        Material_Help.onClick.AddListener(MaterialClicked);
        Quality_Help.onClick.AddListener(QualityClicked);
        Year_Help.onClick.AddListener(Year_Clicked);
        Fame_Help.onClick.AddListener(Fame_Clicked);
        Brand_Help.onClick.AddListener(Brand_Clicked);

        closeButton.onClick.AddListener(CloseButtonClicked);

        nextButton.onClick.AddListener(nextButtonClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MaterialClicked()
    {
        whichScreen = 1;
        materialPointer = 1;
        InstructionScreen.SetActive(true);
        Buttons.SetActive(false);
        InstructionImage.sprite = Material_Image1;

    }
    void QualityClicked()
    {
        whichScreen = 2;
        qualityPointer = 1;
        InstructionScreen.SetActive(true);
        Buttons.SetActive(false);
        InstructionImage.sprite = Quality_Image1;
    }
    void Year_Clicked()
    {
        whichScreen = 3;
        yearPointer = 1;
        InstructionScreen.SetActive(true);
        Buttons.SetActive(false);
        InstructionImage.sprite = Year_Image1;
    }
    void Fame_Clicked()
    {
        whichScreen = 4;
        famePointer = 1;
        InstructionScreen.SetActive(true);
        Buttons.SetActive(false);
        InstructionImage.sprite = Fame_Image1;
    }
    void Brand_Clicked()
    {
        whichScreen = 5;
        brandPointer = 1;
        InstructionScreen.SetActive(true);
        Buttons.SetActive(false);
        InstructionImage.sprite = Brand_Image1;
    }

    void nextButtonClicked()
    {
        if(whichScreen == 1)
        {
            InstructionScreen.SetActive(false);
            Buttons.SetActive(true);
        }
        else if(whichScreen == 2)
        {
            InstructionScreen.SetActive(false);
            Buttons.SetActive(true);
        }
        else if (whichScreen == 3)
        {
            InstructionScreen.SetActive(false);
            Buttons.SetActive(true);
        }
        else if (whichScreen == 4)
        {
            if(famePointer == 1)
            {
                InstructionImage.sprite = Fame_Image2;
                famePointer++;
            }
            else if(famePointer == 2)
            {
                InstructionScreen.SetActive(false);
                Buttons.SetActive(true);                
            }
        }
        else if (whichScreen == 5)
        {
            if(brandPointer == 1)
            {
                InstructionImage.sprite = Brand_Image2;
                brandPointer++;
            }
            else if(brandPointer == 2)
            {
                InstructionImage.sprite = Brand_Image3;
                brandPointer++;
            }
            else if (brandPointer == 3)
            {
                InstructionScreen.SetActive(false);
                Buttons.SetActive(true);
            }
        }
    }

    void CloseButtonClicked()
    {
        BG.SetActive(false);
        helpButton.gameObject.SetActive(true);
        Buttons.SetActive(false);
    }
    
    void helpButtonClicked()
    {
        BG.SetActive(true);
        Buttons.SetActive(true);
        helpButton.gameObject.SetActive(false);
    }
}
