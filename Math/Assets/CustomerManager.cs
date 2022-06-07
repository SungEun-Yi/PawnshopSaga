using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    public bool isCustomerIn = false;

    public GameObject Customer1;
    public GameObject Customer2;
    public GameObject Customer3;
    public GameObject Customer4;
    public GameObject Customer5;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;

    public GameObject ItemBought1;
    public GameObject ItemBought2;
    public GameObject ItemBought3;
    public GameObject ItemBought4;
    public GameObject ItemBought5;
    public GameObject ItemBought6;

    public GameObject SoundManager;
    public Sound soundScript;

    public GameObject PurchaseUI;
    public PurchaseUI_Script script;
    public GameObject Database;
    public Database_Script databaseScript;
    private int myCustomerNumber;
    private int myItemNumber;

    public Button purchaseButton;

    public int myMoney = 50000;
    public int mySubscribers = 0;
    public Text moneyText;
    public Text subscriberText;

    

    // Start is called before the first frame update
    void Start()
    {
        purchaseButton.onClick.AddListener(OnClickPurchaseButton);
        

        //초기 currency 세팅
        moneyText.text = "Money: " + myMoney;
        subscriberText.text = "Subscribers: " + mySubscribers;



        isCustomerIn = false;
        script = PurchaseUI.GetComponent<PurchaseUI_Script>();
        databaseScript = Database.GetComponent<Database_Script>();
        soundScript = SoundManager.GetComponent<Sound>();
    }




    // Update is called once per frame
    void Update()
    {
        if(isCustomerIn == false)
        {
            StartCoroutine(show());
            isCustomerIn = true;
        }
    }

    void showRandomCustomer()
    {
        soundScript.playShopBellSound();

        int CustomerNumber = Random.Range(1, 6); // 손님종류는 1, 2, 3, 4, 5
        myCustomerNumber = CustomerNumber;

        if (CustomerNumber == 1)
            Customer1.SetActive(true);
        else if (CustomerNumber == 2)
            Customer2.SetActive(true);
        else if (CustomerNumber == 3)
            Customer3.SetActive(true);
        else if (CustomerNumber == 4)
            Customer4.SetActive(true);
        else if (CustomerNumber == 5)
            Customer5.SetActive(true);

        Debug.Log("showedRandomCustomer");
    }

    void showRandomItem()
    {
        int ItemNumber = Random.Range(1, 7); // Item 종류는 1, 2, 3, 4, 5, 6
        myItemNumber = ItemNumber;

        if (ItemNumber == 1)
            Item1.SetActive(true);
        else if (ItemNumber == 2)
            Item2.SetActive(true);
        else if (ItemNumber == 3)
            Item3.SetActive(true);
        else if (ItemNumber == 4)
            Item4.SetActive(true);
        else if (ItemNumber == 5)
            Item5.SetActive(true);
        else if (ItemNumber == 6)
            Item6.SetActive(true);

    }

    void showPurchaseUI()
    {
        //myCustomerNumber  myItemNumber purchaseUI에 보내기
        script.customerNumber = myCustomerNumber;
        script.itemNumber = myItemNumber;
        script.isUpdated = true;
        Debug.Log("DataSend");

        PurchaseUI.SetActive(true);

    }


    public void OnClickPurchaseButton()
    {
        Debug.Log("PurchaseButtonClicked");
        //Database에 구매 기록 및 구매 금액 추가
        if (myItemNumber == 1)
        {
            databaseScript.isItem1Bought = true;
            databaseScript.Item1Price = script.itemPrice;
        }
        else if (myItemNumber == 2)
        {
            databaseScript.isItem2Bought = true;
            databaseScript.Item2Price = script.itemPrice;
        }
        else if (myItemNumber == 3)
        {
            databaseScript.isItem3Bought = true;
            databaseScript.Item3Price = script.itemPrice;
        }
        else if (myItemNumber == 4)
        {
            databaseScript.isItem4Bought = true;
            databaseScript.Item4Price = script.itemPrice;
        }
        else if (myItemNumber == 5)
        {
            databaseScript.isItem5Bought = true;
            databaseScript.Item5Price = script.itemPrice;
        }
        else if (myItemNumber == 6)
        {
            databaseScript.isItem6Bought = true;
            databaseScript.Item6Price = script.itemPrice;
        }

        // Currency UI에서 금액 차감 후 UI에 업데이트
        myMoney -= script.itemPrice;
        updateMoney();

        // 구매한 Item 전시장에 추가
        if (myItemNumber == 1)
            ItemBought1.SetActive(true);
        else if (myItemNumber == 2)
            ItemBought2.SetActive(true);
        else if (myItemNumber == 3)
            ItemBought3.SetActive(true);
        else if (myItemNumber == 4)
            ItemBought4.SetActive(true);
        else if (myItemNumber == 5)
            ItemBought5.SetActive(true);
        else if (myItemNumber == 6)
            ItemBought6.SetActive(true);

        // 손님, 물건, purchaseUI 활성화 해제
        if (myCustomerNumber == 1)
            Customer1.SetActive(false);
        else if (myCustomerNumber == 2)
            Customer2.SetActive(false);
        else if (myCustomerNumber == 3)
            Customer3.SetActive(false);
        else if (myCustomerNumber == 4)
            Customer4.SetActive(false);
        else if (myCustomerNumber == 5)
            Customer5.SetActive(false);

        if (myItemNumber == 1)
            Item1.SetActive(false);
        else if (myItemNumber == 2)
            Item2.SetActive(false);
        else if (myItemNumber == 3)
            Item3.SetActive(false);
        else if (myItemNumber == 4)
            Item4.SetActive(false);
        else if (myItemNumber == 5)
            Item5.SetActive(false);
        else if (myItemNumber == 6)
            Item6.SetActive(false);

        PurchaseUI.SetActive(false);

        // Customer Manager에서 isCustomerIn을 false로 수정
        isCustomerIn = false;

        // 구매한 item 정보를 데이터베이스에 전송

    }

    public void updateMoney()
    {
        moneyText.text = "Money: " + myMoney;
    }

    public void updateSub()
    {
        subscriberText.text = "Subs: " + mySubscribers;
    }

    IEnumerator show()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        Debug.Log("Waited");

        showRandomCustomer();
        showRandomItem();
        showPurchaseUI();

    }

    

}
