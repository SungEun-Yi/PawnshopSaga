using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop_Script : MonoBehaviour
{
    public Button Undo;
    public GameObject shopUI;

    public Button buyQuality;
    public Button buyYear;
    public Button buyFame;
    public Button buyBrand;
    public Button buyReExamine;

    public GameObject Database;
    public Database_Script databaseScript;

    public GameObject CustomerManager;
    public CustomerManager CustomerManagerScript;

    public Text ReExamineScrollText;
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        CustomerManagerScript = CustomerManager.GetComponent<CustomerManager>();
        databaseScript = Database.GetComponent<Database_Script>();

        Undo.onClick.AddListener(undoClicked);

        buyQuality.onClick.AddListener(buyQualityClicked);
        buyYear.onClick.AddListener(buyYearClicked);
        buyFame.onClick.AddListener(buyFameClicked);
        buyBrand.onClick.AddListener(buyBrandClicked);
        buyReExamine.onClick.AddListener(buyReExamineClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void undoClicked()
    {
        shopUI.SetActive(false);
    }

    void buyQualityClicked()
    {
        if(CustomerManagerScript.mySubscribers >= 1000)
        {
            databaseScript.sub2 = true;
            buyQuality.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Not Enough Sub");
        }
    }
    void buyYearClicked()
    {
        if (CustomerManagerScript.mySubscribers >= 2000)
        {
            databaseScript.sub3 = true;
        }
        else
        {
            Debug.Log("Not Enough Sub");
        }
    }
    void buyFameClicked()
    {
        if (CustomerManagerScript.mySubscribers >= 5000)
        {
            databaseScript.sub4 = true;
        }
        else
        {
            Debug.Log("Not Enough Sub");
        }
    }
    void buyBrandClicked()
    {
        if (CustomerManagerScript.mySubscribers >= 10000)
        {
            databaseScript.sub5 = true;
        }
        else
        {
            Debug.Log("Not Enough Sub");
        }
    }
    void buyReExamineClicked()
    {
        if(CustomerManagerScript.myMoney >= 1000)
        {
            CustomerManagerScript.myMoney -= 1000;
            databaseScript.ReExamineScrollCount += 1;
            ReExamineScrollText.text = "Re-Examine Scroll: " + databaseScript.ReExamineScrollCount;
            moneyText.text = "Money: " + CustomerManagerScript.myMoney;
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }
}
