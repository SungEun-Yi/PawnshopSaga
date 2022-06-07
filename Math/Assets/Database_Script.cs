using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Database_Script : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;

    public bool isItem1Bought = false;
    public bool isItem2Bought = false;
    public bool isItem3Bought = false;
    public bool isItem4Bought = false;
    public bool isItem5Bought = false;
    public bool isItem6Bought = false;

    public int Item1Price = 0;
    public int Item2Price = 0;
    public int Item3Price = 0;
    public int Item4Price = 0;
    public int Item5Price = 0;
    public int Item6Price = 0;

    // int ÇüÅÂ·Î 0, 1, 2, 3, 4·Î ¸Å±æ ¿¹Á¤ (0Àº ¹Ì°¨Á¤, 1Àº ½ÇÆÐÇÑ °¨Á¤)
    // Ruined Common Processed Rare
    public int item1Material = 0;
    public int item2Material = 0;
    public int item3Material = 0;
    public int item4Material = 0;
    public int item5Material = 0;
    public int item6Material = 0;

    //  Poor Normal Good Best
    public int item1Quality = 0;
    public int item2Quality = 0;
    public int item3Quality = 0;
    public int item4Quality = 0;
    public int item5Quality = 0;
    public int item6Quality = 0;

    // Ancient Aged Young Newest 
    public int item1Year = 0;
    public int item2Year = 0;
    public int item3Year = 0;
    public int item4Year = 0;
    public int item5Year = 0;
    public int item6Year = 0;

    // Unknown Common Famous Named
    public int item1Fame = 0;
    public int item2Fame = 0;
    public int item3Fame = 0;
    public int item4Fame = 0;
    public int item5Fame = 0;
    public int item6Fame = 0;

    // Fake  Ordinary Luxury High-End
    public int item1Brand = 0;
    public int item2Brand = 0;
    public int item3Brand = 0;
    public int item4Brand = 0;
    public int item5Brand = 0;
    public int item6Brand = 0;
    

    public Button resellButton;
    public Button ExamineMaterial;
    public Button ExamineQuality;
    public Button ExamineYear;
    public Button ExamineFame;
    public Button ExamineBrand;

    public Button reExamineMaterial;
    public Button reExamineQuality;
    public Button reExamineYear;
    public Button reExamineFame;
    public Button reExamineBrand;

    public string selectedItemName;

    public GameObject ItemUI;

    public Text ItemName_Text;
    public Text Material_Text;
    public Text Quality_Text;
    public Text Year_Text;
    public Text Fame_Text;
    public Text Brand_Text;
    public Text TotalValue_Text;
    
    public bool isQuizSolved = false;

    public GameObject customerManager;
    public CustomerManager customerManager_Script;

    public GameObject quizDatabase;
    public Quiz_Script quizScript;

    public GameObject scoreManager;
    public ScoreScript scoreScript;

    float MaterialValue = 1000;
    float QualityValue = 1500;
    float YearValue = 2000;
    float FameValue = 2500;
    float BrandValue = 3000;

    bool showingQuiz = false;
    int whichExamine = 0;

    public bool sub1;
    public bool sub2;
    public bool sub3;
    public bool sub4;
    public bool sub5;

    public int ReExamineScrollCount = 0;
    public Text ReExamineScrollText;
    // Start is called before the first frame update
    void Start()
    {
        sub1 = true;
        sub2 = false;
        sub3 = false;
        sub4 = false;
        sub5 = false;

        quizScript = quizDatabase.GetComponent<Quiz_Script>();
        customerManager_Script = customerManager.GetComponent<CustomerManager>();
        scoreScript = scoreManager.GetComponent<ScoreScript>();

        resellButton.onClick.AddListener(OnclickResellButton);

        ExamineMaterial.onClick.AddListener(OnclickExamineMaterialButton);
        ExamineQuality.onClick.AddListener(OnclickExamineQualityButton);
        ExamineYear.onClick.AddListener(OnclickExamineYearButton);
        ExamineFame.onClick.AddListener(OnclickExamineFameButton);
        ExamineBrand.onClick.AddListener(OnclickExamineBrandButton);

        reExamineMaterial.onClick.AddListener(OnclickreExamineMaterialButton);
        reExamineQuality.onClick.AddListener(OnclickreExamineQualityButton);
        reExamineYear.onClick.AddListener(OnclickreExamineYearButton);
        reExamineFame.onClick.AddListener(OnclickreExamineFameButton);
        reExamineBrand.onClick.AddListener(OnclickreExamineBrandButton);

    }
    
    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Return) && showingQuiz)
        {
            // Quiz input ¹Þ°í Á¤´äÀ» ¸Â®A´ÂÁö Æ²·È´ÂÁö ÆÇ´Ü
            // ¼º°ø½Ã true, ½ÇÆÐ ½Ã false ¹ÝÈ¯
            isQuizSolved = quizScript.solveQuiz();
            quizScript.hideQuiz();
            Examine(whichExamine);
        }

    }

    public void OnclickResellButton()
    {
        // ÆÇ¸ÅÇÑ ¾ÆÀÌÅÛÀÇ °¡°Ý¸¸Å­ currency Ãß°¡
        // ÆÇ¸ÅÇÑ ¾ÆÀÌÅÛ ºñÈ°¼ºÈ­
        // iteminfo UI ºñÈ°¼ºÈ­
        // database¿¡¼­ ¼±ÅÃÇÑ ¾ÆÀÌÅÛÀÇ °¡°Ý & °¨Á¤»óÅÂ ÃÊ±âÈ­ 
        if(selectedItemName == "Art")
        {
            customerManager_Script.myMoney += (int)updatePrice(1);
            customerManager_Script.mySubscribers += (int)updatePrice(1);
            customerManager_Script.mySubscribers -= (int)Item1Price;
            customerManager_Script.updateMoney();
            customerManager_Script.updateSub();
            scoreScript.score += (int)updatePrice(1);

            item1.SetActive(false);
            ItemUI.SetActive(false);
            resetItemInfo(1);
            Debug.Log("Art sold");
        }
        else if (selectedItemName == "Book_White")
        {
            customerManager_Script.myMoney += (int)updatePrice(2);
            customerManager_Script.mySubscribers += (int)updatePrice(2);
            customerManager_Script.mySubscribers -= (int)Item2Price;
            customerManager_Script.updateMoney();
            customerManager_Script.updateSub();
            scoreScript.score += (int)updatePrice(2);
            item2.SetActive(false);
            ItemUI.SetActive(false);
            resetItemInfo(2);
            Debug.Log("Book_White sold");
        }
        else if (selectedItemName == "Book_Gray")
        {
            customerManager_Script.myMoney += (int)updatePrice(3);
            customerManager_Script.mySubscribers += (int)updatePrice(3);
            customerManager_Script.mySubscribers -= (int)Item3Price;
            customerManager_Script.updateMoney();
            customerManager_Script.updateSub();
            scoreScript.score += (int)updatePrice(3);
            item3.SetActive(false);
            ItemUI.SetActive(false);
            resetItemInfo(3);
            Debug.Log("Book_Gray sold");
        }
        else if (selectedItemName == "Book_Green")
        {
            customerManager_Script.myMoney += (int)updatePrice(4);
            customerManager_Script.mySubscribers += (int)updatePrice(4);
            customerManager_Script.mySubscribers -= (int)Item4Price;
            customerManager_Script.updateMoney();
            customerManager_Script.updateSub();
            scoreScript.score += (int)updatePrice(4);
            item4.SetActive(false);
            ItemUI.SetActive(false);
            resetItemInfo(4);
            Debug.Log("Book_Green sold");
        }
        else if (selectedItemName == "Coke")
        {
            customerManager_Script.myMoney += (int)updatePrice(5);
            customerManager_Script.mySubscribers += (int)updatePrice(5);
            customerManager_Script.mySubscribers -= (int)Item5Price;
            customerManager_Script.updateMoney();
            customerManager_Script.updateSub();
            scoreScript.score += (int)updatePrice(5);
            item5.SetActive(false);
            ItemUI.SetActive(false);
            resetItemInfo(5);
            Debug.Log("Coke sold");
        }
        else if (selectedItemName == "Necklace")
        {            
            customerManager_Script.myMoney += (int)updatePrice(6);
            customerManager_Script.mySubscribers += (int)updatePrice(6);
            customerManager_Script.mySubscribers -= (int)Item6Price;
            customerManager_Script.updateMoney();
            customerManager_Script.updateSub();
            scoreScript.score += (int)updatePrice(6);
            item6.SetActive(false);
            ItemUI.SetActive(false);
            resetItemInfo(6);
            Debug.Log("Necklace sold");
        }
    }


    public void OnclickExamineMaterialButton()
    {
        if (sub1)
        {
            quizScript.WhichQuestion = 1;
            DoQuiz();

            whichExamine = 1;


            // examineQualityButton ºñÈ°¼ºÈ­
            ExamineQuality.gameObject.SetActive(false);

            //Á¤º¸Ã¢ Update
            showItemInfo();
        }
        else
        {
            Debug.Log("Not Enough Subscribers");
        }

        

    }
    public void OnclickExamineQualityButton()
    {
        if (sub2)
        {
            quizScript.WhichQuestion = 2;
            DoQuiz();

            whichExamine = 2;


            // examineQualityButton ºñÈ°¼ºÈ­
            ExamineQuality.gameObject.SetActive(false);

            //Á¤º¸Ã¢ Update
            showItemInfo();
        }
        else
        {
            Debug.Log("Not Enough Subscribers");
        }
        
    }
    public void OnclickExamineYearButton()
    {
        if (sub3)
        {
            quizScript.WhichQuestion = 3;
            DoQuiz();
            whichExamine = 3;
            ExamineQuality.gameObject.SetActive(false);
            showItemInfo();
        }
        else
        {
            Debug.Log("Not Enough Subscribers");
        }
    
    }
    public void OnclickExamineFameButton()
    {
        if (sub4)
        {
            quizScript.WhichQuestion = 4;
            DoQuiz();
            whichExamine = 4;
            ExamineQuality.gameObject.SetActive(false);
            showItemInfo();
        }
        else
        {
            Debug.Log("Not Enough Subscribers");
        }
    }
    public void OnclickExamineBrandButton()
    {
        if (sub5)
        {
            quizScript.WhichQuestion = 5;
            DoQuiz();
            whichExamine = 5;
            ExamineQuality.gameObject.SetActive(false);
            showItemInfo();
        }
        else
        {
            Debug.Log("Not Enough Subscribers");
        }
    }


    public void DoQuiz()
    {
        // QuizUI º¸¿©ÁÜ
        quizScript.showQuiz();
        showingQuiz = true;

        // Quiz input ¹Þ°í Á¤´äÀ» ¸Â®A´ÂÁö Æ²·È´ÂÁö ÆÇ´Ü
        // ¼º°ø½Ã true, ½ÇÆÐ ½Ã false ¹ÝÈ¯
        // Update()¿¡¼­ ÀÌ·ïÁü

    }

    
    public void Examine(int n)
    {
        if(n == 1) // material
        {
            if (isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Material = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Material = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Material = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Material = Random.Range(2, 5);
                }
                else if (selectedItemName == "Coke")
                {
                    item5Material = Random.Range(2, 5);
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Material = Random.Range(2, 5);
                }
            }
            else if (!isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Material = 1;
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Material = 1;
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Material = 1;
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Material = 1;
                }
                else if (selectedItemName == "Coke")
                {
                    item5Material = 1;
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Material = 1;
                }
            }
        }
        else if (n == 2) // quality
        {
            if (isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Quality = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Quality = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Quality = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Quality = Random.Range(2, 5);
                }
                else if (selectedItemName == "Coke")
                {
                    item5Quality = Random.Range(2, 5);
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Quality = Random.Range(2, 5);
                }
            }
            else if (!isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Quality = 1;
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Quality = 1;
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Quality = 1;
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Quality = 1;
                }
                else if (selectedItemName == "Coke")
                {
                    item5Quality = 1;
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Quality = 1;
                }
            }
        }
        else if (n == 3) // year
        {
            if (isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Year = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Year = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Year = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Year = Random.Range(2, 5);
                }
                else if (selectedItemName == "Coke")
                {
                    item5Year = Random.Range(2, 5);
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Year = Random.Range(2, 5);
                }
            }
            else if (!isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Year = 1;
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Year = 1;
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Year = 1;
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Year = 1;
                }
                else if (selectedItemName == "Coke")
                {
                    item5Year = 1;
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Year = 1;
                }
            }
        }
        else if (n == 4) // fame
        {
            if (isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Fame = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Fame = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Fame = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Fame = Random.Range(2, 5);
                }
                else if (selectedItemName == "Coke")
                {
                    item5Fame = Random.Range(2, 5);
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Fame = Random.Range(2, 5);
                }
            }
            else if (!isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Fame = 1;
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Fame = 1;
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Fame = 1;
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Fame = 1;
                }
                else if (selectedItemName == "Coke")
                {
                    item5Fame = 1;
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Fame = 1;
                }
            }
        }
        else if (n == 5) // brand
        {
            if (isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Brand = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Brand = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Brand = Random.Range(2, 5);
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Brand = Random.Range(2, 5);
                }
                else if (selectedItemName == "Coke")
                {
                    item5Brand = Random.Range(2, 5);
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Brand = Random.Range(2, 5);
                }
            }
            else if (!isQuizSolved)
            {
                if (selectedItemName == "Art")
                {
                    item1Brand = 1;
                }
                else if (selectedItemName == "Book_White")
                {
                    item2Brand = 1;
                }
                else if (selectedItemName == "Book_Gray")
                {
                    item3Brand = 1;
                }
                else if (selectedItemName == "Book_Green")
                {
                    item4Brand = 1;
                }
                else if (selectedItemName == "Coke")
                {
                    item5Brand = 1;
                }
                else if (selectedItemName == "Necklace")
                {
                    item6Brand = 1;
                }
            }
        }

        isQuizSolved = false;

        //Á¤º¸Ã¢ Update
        showItemInfo();
    }









    public void resetItemInfo(int n)
    {
        if (n == 1)
        {
            Item1Price = 0;
            item1Material = 0;
            item1Quality = 0;
            item1Year = 0;
            item1Fame = 0;
            item1Brand = 0;
        }
        else if (n == 2)
        {
            Item2Price = 0;
            item2Material = 0;
            item2Quality = 0;
            item2Year = 0;
            item2Fame = 0;
            item2Brand = 0;
        }
        else if (n == 3)
        {
            Item3Price = 0;
            item3Material = 0;
            item3Quality = 0;
            item3Year = 0;
            item3Fame = 0;
            item3Brand = 0;
        }
        else if (n == 4)
        {
            Item4Price = 0;
            item4Material = 0;
            item4Quality = 0;
            item4Year = 0;
            item4Fame = 0;
            item4Brand = 0;
        }
        else if (n == 5)
        {
            Item5Price = 0;
            item5Material = 0;
            item5Quality = 0;
            item5Year = 0;
            item5Fame = 0;
            item5Brand = 0;
        }
        else if (n == 6)
        {
            Item6Price = 0;
            item6Material = 0;
            item6Quality = 0;
            item6Year = 0;
            item6Fame = 0;
            item6Brand = 0;
        }

    }

    public float updatePrice(int n) 
    {
        float result = 0f;
        // total Value °è»êÇØÁÖ´Â ÇÔ¼ö
        if (n == 1)
        {
            result = Item1Price;
            if (item1Material != 0)
                result += ((float)item1Material - 1.5f) * MaterialValue;
            if (item1Quality != 0)
                result += ((float)item1Quality - 1.5f) * QualityValue;
            if (item1Year != 0)
                result += ((float)item1Year - 1.5f) * YearValue;
            if (item1Fame != 0)
                result += ((float)item1Fame - 1.5f) * FameValue;
            if (item1Brand != 0)
                result += ((float)item1Brand - 1.5f) * BrandValue;
        }
        else if (n == 2)
        {
            result = Item2Price;
            if (item2Material != 0)
                result += ((float)item2Material - 1.5f) * MaterialValue;
            if (item2Quality != 0)
                result += ((float)item2Quality - 1.5f) * QualityValue;
            if (item2Year != 0)
                result += ((float)item2Year - 1.5f) * YearValue;
            if (item2Fame != 0)
                result += ((float)item2Fame - 1.5f) * FameValue;
            if (item2Brand != 0)
                result += ((float)item2Brand - 1.5f) * BrandValue;
        }
        else if (n == 3)
        {
            result = Item3Price;
            if (item3Material != 0)
                result += ((float)item3Material - 1.5f) * MaterialValue;
            if (item3Quality != 0)
                result += ((float)item3Quality - 1.5f) * QualityValue;
            if (item3Year != 0)
                result += ((float)item3Year - 1.5f) * YearValue;
            if (item3Fame != 0)
                result += ((float)item3Fame - 1.5f) * FameValue;
            if (item3Brand != 0)
                result += ((float)item3Brand - 1.5f) * BrandValue;
        }
        else if (n == 4)
        {
            result = Item4Price;
            if (item4Material != 0)
                result += ((float)item4Material - 1.5f) * MaterialValue;
            if (item4Quality != 0)
                result += ((float)item4Quality - 1.5f) * QualityValue;
            if (item4Year != 0)
                result += ((float)item4Year - 1.5f) * YearValue;
            if (item4Fame != 0)
                result += ((float)item4Fame - 1.5f) * FameValue;
            if (item4Brand != 0)
                result += ((float)item4Brand - 1.5f) * BrandValue;
        }
        else if (n == 5)
        {
            result = Item5Price;
            if (item5Material != 0)
                result += ((float)item5Material - 1.5f) * MaterialValue;
            if (item5Quality != 0)
                result += ((float)item5Quality - 1.5f) * QualityValue;
            if (item5Year != 0)
                result += ((float)item5Year - 1.5f) * YearValue;
            if (item5Fame != 0)
                result += ((float)item5Fame - 1.5f) * FameValue;
            if (item5Brand != 0)
                result += ((float)item5Brand - 1.5f) * BrandValue;
        }
        else if (n == 6)
        {
            result = Item6Price;
            if (item6Material != 0)
                result += ((float)item6Material - 1.5f) * MaterialValue;
            if (item6Quality != 0)
                result += ((float)item6Quality - 1.5f) * QualityValue;
            if (item6Year != 0)
                result += ((float)item6Year - 1.5f) * YearValue;
            if (item6Fame != 0)
                result += ((float)item6Fame - 1.5f) * FameValue;
            if (item6Brand != 0)
                result += ((float)item6Brand - 1.5f) * BrandValue;
        }

        return result;
    }

    public void showItemInfo()
    {
        // Item ÀÌ¸§ update
        // item °¨Á¤»óÅÂ update
        // item °¡Ä¡ update
        // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
        
        if (selectedItemName == "Art")
        {
            // Item ÀÌ¸§ update
            ItemName_Text.text = "Name: " + "Art";

            // item °¨Á¤»óÅÂ update
            // Material Update
            if (item1Material == 1)
                Material_Text.text = "Material: \n" + "Ruined";
            else if (item1Material == 2)
                Material_Text.text = "Material: \n" + "Common";
            else if (item1Material == 3)
                Material_Text.text = "Material: \n" + "Processed";
            else if (item1Material == 4)
                Material_Text.text = "Material: \n" + "Rare";
            else
                Material_Text.text = "Material: \n ???";

            // Quality Update 
            if (item1Quality == 1)
                Quality_Text.text = "Quality: \n" + "Poor";
            else if (item1Quality == 2)
                Quality_Text.text = "Quality: \n" + "Normal";
            else if (item1Quality == 3)
                Quality_Text.text = "Quality: \n" + "Good";
            else if (item1Quality == 4)
                Quality_Text.text = "Quality: \n" + "Best";
            else
                Quality_Text.text = "Quality: \n ???";

            // Year Update
            if (item1Year == 1)
                Year_Text.text = "Year: \n" + "Very Old";
            else if (item1Year == 2)
                Year_Text.text = "Year: \n" + "Aged";
            else if (item1Year == 3)
                Year_Text.text = "Year: \n" + "Young";
            else if (item1Year == 4)
                Year_Text.text = "Year: \n" + "Newest";
            else
                Year_Text.text = "Year: \n ???";

            // Fame Update
            if (item1Fame == 1)
                Fame_Text.text = "Fame: \n" + "Unknown";
            else if (item1Fame == 2)
                Fame_Text.text = "Fame: \n" + "Common";
            else if (item1Fame == 3)
                Fame_Text.text = "Fame: \n" + "Famous";
            else if (item1Fame == 4)
                Fame_Text.text = "Fame: \n" + "Legendary";
            else
                Fame_Text.text = "Fame: \n ???";

            // Brand Update
            if (item1Brand == 1)
                Brand_Text.text = "Brand: \n" + "Fake";
            else if (item1Brand == 2)
                Brand_Text.text = "Brand: \n" + "Ordinary";
            else if (item1Brand == 3)
                Brand_Text.text = "Brand: \n" + "Luxury";
            else if (item1Brand == 4)
                Brand_Text.text = "Brand: \n" + "High-End";
            else
                Brand_Text.text = "Brand: \n ???";

            // item °¡Ä¡ update
            TotalValue_Text.text = "Resell Price: " + updatePrice(1);

            // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
            if (item1Material == 0)
                ExamineMaterial.gameObject.SetActive(true);
            else
                ExamineMaterial.gameObject.SetActive(false);
            if (item1Quality == 0)
                ExamineQuality.gameObject.SetActive(true);
            else
                ExamineQuality.gameObject.SetActive(false);
            if (item1Year == 0)
                ExamineYear.gameObject.SetActive(true);
            else
                ExamineYear.gameObject.SetActive(false);
            if (item1Fame == 0)
                ExamineFame.gameObject.SetActive(true);
            else
                ExamineFame.gameObject.SetActive(false);
            if (item1Brand == 0)
                ExamineBrand.gameObject.SetActive(true);
            else
                ExamineBrand.gameObject.SetActive(false);
        }
        else if (selectedItemName == "Book_White")
        {
            // Item ÀÌ¸§ update
            ItemName_Text.text = "Name: " + "White Book";

            // Material Update
            if (item2Material == 1)
                Material_Text.text = "Material: \n" + "Ruined";
            else if (item2Material == 2)
                Material_Text.text = "Material: \n" + "Common";
            else if (item2Material == 3)
                Material_Text.text = "Material: \n" + "Processed";
            else if (item2Material == 4)
                Material_Text.text = "Material: \n" + "Rare";
            else
                Material_Text.text = "Material: \n ???";

            // Quality Update 
            if (item2Quality == 1)
                Quality_Text.text = "Quality: \n" + "Poor";
            else if (item2Quality == 2)
                Quality_Text.text = "Quality: \n" + "Normal";
            else if (item2Quality == 3)
                Quality_Text.text = "Quality: \n" + "Good";
            else if (item2Quality == 4)
                Quality_Text.text = "Quality: \n" + "Best";
            else
                Quality_Text.text = "Quality: \n ???";
            // Year Update
            if (item2Year == 1)
                Year_Text.text = "Year: \n" + "Very Old";
            else if (item2Year == 2)
                Year_Text.text = "Year: \n" + "Aged";
            else if (item2Year == 3)
                Year_Text.text = "Year: \n" + "Young";
            else if (item2Year == 4)
                Year_Text.text = "Year: \n" + "Newest";
            else
                Year_Text.text = "Year: \n ???";
            // Fame Update
            if (item2Fame == 1)
                Fame_Text.text = "Fame: \n" + "Unknown";
            else if (item2Fame == 2)
                Fame_Text.text = "Fame: \n" + "Common";
            else if (item2Fame == 3)
                Fame_Text.text = "Fame: \n" + "Famous";
            else if (item2Fame == 4)
                Fame_Text.text = "Fame: \n" + "Legendary";
            else
                Fame_Text.text = "Fame: \n ???";
            // Brand Update
            if (item2Brand == 1)
                Brand_Text.text = "Brand: \n" + "Fake";
            else if (item2Brand == 2)
                Brand_Text.text = "Brand: \n" + "Ordinary";
            else if (item2Brand == 3)
                Brand_Text.text = "Brand: \n" + "Luxury";
            else if (item2Brand == 4)
                Brand_Text.text = "Brand: \n" + "High-End";
            else
                Brand_Text.text = "Brand: \n ???";
            // item °¡Ä¡ update
            TotalValue_Text.text = "Resell Price: " + updatePrice(2);
            // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
            if (item2Material == 0)
                ExamineMaterial.gameObject.SetActive(true);
            else
                ExamineMaterial.gameObject.SetActive(false);
            if (item2Quality == 0)
                ExamineQuality.gameObject.SetActive(true);
            else
                ExamineQuality.gameObject.SetActive(false);
            if (item2Year == 0)
                ExamineYear.gameObject.SetActive(true);
            else
                ExamineYear.gameObject.SetActive(false);
            if (item2Fame == 0)
                ExamineFame.gameObject.SetActive(true);
            else
                ExamineFame.gameObject.SetActive(false);
            if (item2Brand == 0)
                ExamineBrand.gameObject.SetActive(true);
            else
                ExamineBrand.gameObject.SetActive(false);
        }
        else if (selectedItemName == "Book_Gray")
        {
            // Item ÀÌ¸§ update
            ItemName_Text.text = "Name: " + "Gray Book";

            // Material Update
            if (item3Material == 1)
                Material_Text.text = "Material: \n" + "Ruined";
            else if (item3Material == 2)
                Material_Text.text = "Material: \n" + "Common";
            else if (item3Material == 3)
                Material_Text.text = "Material: \n" + "Processed";
            else if (item3Material == 4)
                Material_Text.text = "Material: \n" + "Rare";
            else
                Material_Text.text = "Material: \n ???";
            // Quality Update 
            if (item3Quality == 1)
                Quality_Text.text = "Quality: \n" + "Poor";
            else if (item3Quality == 2)
                Quality_Text.text = "Quality: \n" + "Normal";
            else if (item3Quality == 3)
                Quality_Text.text = "Quality: \n" + "Good";
            else if (item3Quality == 4)
                Quality_Text.text = "Quality: \n" + "Best";
            else
                Quality_Text.text = "Quality: \n ???";
            // Year Update
            if (item3Year == 1)
                Year_Text.text = "Year: \n" + "Very Old";
            else if (item3Year == 2)
                Year_Text.text = "Year: \n" + "Aged";
            else if (item3Year == 3)
                Year_Text.text = "Year: \n" + "Young";
            else if (item3Year == 4)
                Year_Text.text = "Year: \n" + "Newest";
            else
                Year_Text.text = "Year: \n ???";
            // Fame Update
            if (item3Fame == 1)
                Fame_Text.text = "Fame: \n" + "Unknown";
            else if (item3Fame == 2)
                Fame_Text.text = "Fame: \n" + "Common";
            else if (item3Fame == 3)
                Fame_Text.text = "Fame: \n" + "Famous";
            else if (item3Fame == 4)
                Fame_Text.text = "Fame: \n" + "Legendary";
            else
                Fame_Text.text = "Fame: \n ???";
            // Brand Update
            if (item3Brand == 1)
                Brand_Text.text = "Brand: \n" + "Fake";
            else if (item3Brand == 2)
                Brand_Text.text = "Brand: \n" + "Ordinary";
            else if (item3Brand == 3)
                Brand_Text.text = "Brand: \n" + "Luxury";
            else if (item3Brand == 4)
                Brand_Text.text = "Brand: \n" + "High-End";
            else
                Brand_Text.text = "Brand: \n ???";
            // item °¡Ä¡ update
            TotalValue_Text.text = "Resell Price: " + updatePrice(3);
            // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
            if (item3Material == 0)
                ExamineMaterial.gameObject.SetActive(true);
            else
                ExamineMaterial.gameObject.SetActive(false);
            if (item3Quality == 0)
                ExamineQuality.gameObject.SetActive(true);
            else
                ExamineQuality.gameObject.SetActive(false);
            if (item3Year == 0)
                ExamineYear.gameObject.SetActive(true);
            else
                ExamineYear.gameObject.SetActive(false);
            if (item3Fame == 0)
                ExamineFame.gameObject.SetActive(true);
            else
                ExamineFame.gameObject.SetActive(false);
            if (item3Brand == 0)
                ExamineBrand.gameObject.SetActive(true);
            else
                ExamineBrand.gameObject.SetActive(false);
        }
        else if (selectedItemName == "Book_Green")
        {
            // Item ÀÌ¸§ update
            ItemName_Text.text = "Name: " + "Green Book";
            // Material Update
            if (item4Material == 1)
                Material_Text.text = "Material: \n" + "Ruined";
            else if (item4Material == 2)
                Material_Text.text = "Material: \n" + "Common";
            else if (item4Material == 3)
                Material_Text.text = "Material: \n" + "Processed";
            else if (item4Material == 4)
                Material_Text.text = "Material: \n" + "Rare";
            else
                Material_Text.text = "Material: \n ???";

            // Quality Update 
            if (item4Quality == 1)
                Quality_Text.text = "Quality: \n" + "Poor";
            else if (item4Quality == 2)
                Quality_Text.text = "Quality: \n" + "Normal";
            else if (item4Quality == 3)
                Quality_Text.text = "Quality: \n" + "Good";
            else if (item4Quality == 4)
                Quality_Text.text = "Quality: \n" + "Best";
            else
                Quality_Text.text = "Quality: \n ???";

            // Year Update
            if (item4Year == 1)
                Year_Text.text = "Year: \n" + "Very Old";
            else if (item4Year == 2)
                Year_Text.text = "Year: \n" + "Aged";
            else if (item4Year == 3)
                Year_Text.text = "Year: \n" + "Young";
            else if (item4Year == 4)
                Year_Text.text = "Year: \n" + "Newest";
            else
                Year_Text.text = "Year: \n ???";

            // Fame Update
            if (item4Fame == 1)
                Fame_Text.text = "Fame: \n" + "Unknown";
            else if (item4Fame == 2)
                Fame_Text.text = "Fame: \n" + "Common";
            else if (item4Fame == 3)
                Fame_Text.text = "Fame: \n" + "Famous";
            else if (item4Fame == 4)
                Fame_Text.text = "Fame: \n" + "Legendary";
            else
                Fame_Text.text = "Fame: \n ???";

            // Brand Update
            if (item4Brand == 1)
                Brand_Text.text = "Brand: \n" + "Fake";
            else if (item4Brand == 2)
                Brand_Text.text = "Brand: \n" + "Ordinary";
            else if (item4Brand == 3)
                Brand_Text.text = "Brand: \n" + "Luxury";
            else if (item4Brand == 4)
                Brand_Text.text = "Brand: \n" + "High-End";
            else
                Brand_Text.text = "Brand: \n ???";
            // item °¡Ä¡ update
            TotalValue_Text.text = "Resell Price: " + updatePrice(4);
            // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
            if (item4Material == 0)
                ExamineMaterial.gameObject.SetActive(true);
            else
                ExamineMaterial.gameObject.SetActive(false);
            if (item4Quality == 0)
                ExamineQuality.gameObject.SetActive(true);
            else
                ExamineQuality.gameObject.SetActive(false);
            if (item4Year == 0)
                ExamineYear.gameObject.SetActive(true);
            else
                ExamineYear.gameObject.SetActive(false);
            if (item4Fame == 0)
                ExamineFame.gameObject.SetActive(true);
            else
                ExamineFame.gameObject.SetActive(false);
            if (item4Brand == 0)
                ExamineBrand.gameObject.SetActive(true);
            else
                ExamineBrand.gameObject.SetActive(false);
        }
        else if (selectedItemName == "Coke")
        {
            // Item ÀÌ¸§ update
            ItemName_Text.text = "Name: " + "Coke";
            // Material Update
            if (item5Material == 1)
                Material_Text.text = "Material: \n" + "Ruined";
            else if (item5Material == 2)
                Material_Text.text = "Material: \n" + "Common";
            else if (item5Material == 3)
                Material_Text.text = "Material: \n" + "Processed";
            else if (item5Material == 4)
                Material_Text.text = "Material: \n" + "Rare";
            else
                Material_Text.text = "Material: \n ???";

            // Quality Update 
            if (item5Quality == 1)
                Quality_Text.text = "Quality: \n" + "Poor";
            else if (item5Quality == 2)
                Quality_Text.text = "Quality: \n" + "Normal";
            else if (item5Quality == 3)
                Quality_Text.text = "Quality: \n" + "Good";
            else if (item5Quality == 4)
                Quality_Text.text = "Quality: \n" + "Best";
            else
                Quality_Text.text = "Quality: \n ???";

            // Year Update
            if (item5Year == 1)
                Year_Text.text = "Year: \n" + "Very Old";
            else if (item5Year == 2)
                Year_Text.text = "Year: \n" + "Aged";
            else if (item5Year == 3)
                Year_Text.text = "Year: \n" + "Young";
            else if (item5Year == 4)
                Year_Text.text = "Year: \n" + "Newest";
            else
                Year_Text.text = "Year: \n ???";


            // Fame Update
            if (item5Fame == 1)
                Fame_Text.text = "Fame: \n" + "Unknown";
            else if (item5Fame == 2)
                Fame_Text.text = "Fame: \n" + "Common";
            else if (item5Fame == 3)
                Fame_Text.text = "Fame: \n" + "Famous";
            else if (item5Fame == 4)
                Fame_Text.text = "Fame: \n" + "Legendary";
            else
                Fame_Text.text = "Fame: \n ???";

            // Brand Update
            if (item5Brand == 1)
                Brand_Text.text = "Brand: \n" + "Fake";
            else if (item5Brand == 2)
                Brand_Text.text = "Brand: \n" + "Ordinary";
            else if (item5Brand == 3)
                Brand_Text.text = "Brand: \n" + "Luxury";
            else if (item5Brand == 4)
                Brand_Text.text = "Brand: \n" + "High-End";
            else
                Brand_Text.text = "Brand: \n ???";
            // item °¡Ä¡ update
            TotalValue_Text.text = "Resell Price: " + updatePrice(5);
            // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
            if (item5Material == 0)
                ExamineMaterial.gameObject.SetActive(true);
            else
                ExamineMaterial.gameObject.SetActive(false);
            if (item5Quality == 0)
                ExamineQuality.gameObject.SetActive(true);
            else
                ExamineQuality.gameObject.SetActive(false);
            if (item5Year == 0)
                ExamineYear.gameObject.SetActive(true);
            else
                ExamineYear.gameObject.SetActive(false);
            if (item5Fame == 0)
                ExamineFame.gameObject.SetActive(true);
            else
                ExamineFame.gameObject.SetActive(false);
            if (item5Brand == 0)
                ExamineBrand.gameObject.SetActive(true);
            else
                ExamineBrand.gameObject.SetActive(false);
        }
        else if (selectedItemName == "Necklace")
        {
            // Item ÀÌ¸§ update
            ItemName_Text.text = "Name: " + "Necklace";
            // Material Update
            if (item6Material == 1)
                Material_Text.text = "Material: \n" + "Ruined";
            else if (item6Material == 2)
                Material_Text.text = "Material: \n" + "Common";
            else if (item6Material == 3)
                Material_Text.text = "Material: \n" + "Processed";
            else if (item6Material == 4)
                Material_Text.text = "Material: \n" + "Rare";
            else
                Material_Text.text = "Material: \n ???";
            // Quality Update 
            if (item6Quality == 1)
                Quality_Text.text = "Quality: \n" + "Poor";
            else if (item6Quality == 2)
                Quality_Text.text = "Quality: \n" + "Normal";
            else if (item6Quality == 3)
                Quality_Text.text = "Quality: \n" + "Good";
            else if (item6Quality == 4)
                Quality_Text.text = "Quality: \n" + "Best";
            else
                Quality_Text.text = "Quality: \n ???";
            // Year Update
            if (item6Year == 1)
                Year_Text.text = "Year: \n" + "Very Old";
            else if (item6Year == 2)
                Year_Text.text = "Year: \n" + "Aged";
            else if (item6Year == 3)
                Year_Text.text = "Year: \n" + "Young";
            else if (item6Year == 4)
                Year_Text.text = "Year: \n" + "Newest";
            else
                Year_Text.text = "Year: \n ???";
            // Fame Update
            if (item6Fame == 1)
                Fame_Text.text = "Fame: \n" + "Unknown";
            else if (item6Fame == 2)
                Fame_Text.text = "Fame: \n" + "Common";
            else if (item6Fame == 3)
                Fame_Text.text = "Fame: \n" + "Famous";
            else if (item6Fame == 4)
                Fame_Text.text = "Fame: \n" + "Legendary";
            else
                Fame_Text.text = "Fame: \n ???";
            // Brand Update
            if (item6Brand == 1)
                Brand_Text.text = "Brand: \n" + "Fake";
            else if (item6Brand == 2)
                Brand_Text.text = "Brand: \n" + "Ordinary";
            else if (item6Brand == 3)
                Brand_Text.text = "Brand: \n" + "Luxury";
            else if (item6Brand == 4)
                Brand_Text.text = "Brand: \n" + "High-End";
            else
                Brand_Text.text = "Brand: \n ???";
            // item °¡Ä¡ update
            TotalValue_Text.text = "Resell Price: " + updatePrice(6);
            // °¨Á¤¹öÆ° ¼±ÅÃÀû ¶ç¿ì±â
            if (item6Material == 0)
                ExamineMaterial.gameObject.SetActive(true);
            else
                ExamineMaterial.gameObject.SetActive(false);
            if (item6Quality == 0)
                ExamineQuality.gameObject.SetActive(true);
            else
                ExamineQuality.gameObject.SetActive(false);
            if (item6Year == 0)
                ExamineYear.gameObject.SetActive(true);
            else
                ExamineYear.gameObject.SetActive(false);
            if (item6Fame == 0)
                ExamineFame.gameObject.SetActive(true);
            else
                ExamineFame.gameObject.SetActive(false);
            if (item6Brand == 0)
                ExamineBrand.gameObject.SetActive(true);
            else
                ExamineBrand.gameObject.SetActive(false);
        }

        ItemUI.SetActive(true);
        Debug.Log("Showing Info of " + selectedItemName);
    }
    

    void OnclickreExamineMaterialButton()
    {
        if(ReExamineScrollCount > 0)
        {            
            if (selectedItemName == "Art")
            {
                if(item1Material > 0)
                {
                    item1Material = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;

                }
                else
                {
                    Debug.Log("materialNotExamined");
                }
            }
            else if (selectedItemName == "Book_White")
            {
                if (item2Material > 0)
                {
                    item2Material = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("materialNotExamined");
                }
            }
            else if (selectedItemName == "Book_Gray")
            {
                if (item3Material > 0)
                {
                    item3Material = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("materialNotExamined");
                }
            }
            else if (selectedItemName == "Book_Green")
            {
                if (item4Material > 0)
                {
                    item4Material = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("materialNotExamined");
                }
            }
            else if (selectedItemName == "Coke")
            {
                if (item5Material > 0)
                {
                    item5Material = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("materialNotExamined");
                }
            }
            else if (selectedItemName == "Necklace")
            {
                if (item6Material > 0)
                {
                    item6Material = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("materialNotExamined");
                }
            }

        }
        else
        {
            Debug.Log("Not Enough ReExamineScroll");
        }
        
    }
    void OnclickreExamineQualityButton()
    {
        if (ReExamineScrollCount > 0)
        {
            if (selectedItemName == "Art")
            {
                if (item1Quality > 0)
                {
                    item1Quality = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;

                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_White")
            {
                if (item2Quality > 0)
                {
                    item2Quality = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Gray")
            {
                if (item3Quality > 0)
                {
                    item3Quality = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Green")
            {
                if (item4Quality > 0)
                {
                    item4Quality = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Coke")
            {
                if (item5Quality > 0)
                {
                    item5Quality = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Necklace")
            {
                if (item6Quality > 0)
                {
                    item6Quality = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }

        }
        else
        {
            Debug.Log("Not Enough ReExamineScroll");
        }
    }    
    void OnclickreExamineYearButton()
    {
        if (ReExamineScrollCount > 0)
        {
            if (selectedItemName == "Art")
            {
                if (item1Year > 0)
                {
                    item1Year = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;

                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_White")
            {
                if (item2Year > 0)
                {
                    item2Year = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Gray")
            {
                if (item3Year > 0)
                {
                    item3Year = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Green")
            {
                if (item4Year > 0)
                {
                    item4Year = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Coke")
            {
                if (item5Year > 0)
                {
                    item5Year = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Necklace")
            {
                if (item6Year > 0)
                {
                    item6Year = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }

        }
        else
        {
            Debug.Log("Not Enough ReExamineScroll");
        }
    }
    void OnclickreExamineFameButton()
    {
        if (ReExamineScrollCount > 0)
        {
            if (selectedItemName == "Art")
            {
                if (item1Fame > 0)
                {
                    item1Fame = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;

                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_White")
            {
                if (item2Fame > 0)
                {
                    item2Fame = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Gray")
            {
                if (item3Fame > 0)
                {
                    item3Fame = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Green")
            {
                if (item4Fame > 0)
                {
                    item4Fame = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Coke")
            {
                if (item5Fame > 0)
                {
                    item5Fame = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Necklace")
            {
                if (item6Fame > 0)
                {
                    item6Fame = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }

        }
        else
        {
            Debug.Log("Not Enough ReExamineScroll");
        }
    }
    void OnclickreExamineBrandButton()
    {
        if (ReExamineScrollCount > 0)
        {
            if (selectedItemName == "Art")
            {
                if (item1Brand > 0)
                {
                    item1Brand = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;

                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_White")
            {
                if (item2Brand > 0)
                {
                    item2Brand = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Gray")
            {
                if (item3Brand > 0)
                {
                    item3Brand = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Book_Green")
            {
                if (item4Brand > 0)
                {
                    item4Brand = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Coke")
            {
                if (item5Brand > 0)
                {
                    item5Brand = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }
            else if (selectedItemName == "Necklace")
            {
                if (item6Brand > 0)
                {
                    item6Brand = 0;
                    showItemInfo();
                    ReExamineScrollCount--;
                    ReExamineScrollText.text = "Re-Examine Scroll: " + ReExamineScrollCount;
                }
                else
                {
                    Debug.Log("qualityNotExamined");
                }
            }

        }
        else
        {
            Debug.Log("Not Enough ReExamineScroll");
        }
    }    
}
