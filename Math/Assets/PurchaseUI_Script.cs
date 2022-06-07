using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseUI_Script : MonoBehaviour
{
    public int customerNumber= 0;
    public int itemNumber = 1;
    public bool isUpdated = false;

    public Text nameText;
    public Text priceText;
    

    public int itemPrice = 0;

    private string[] ItemNames = new string[6]; 



    // Start is called before the first frame update
    void Start()
    {
        ItemNames[0] = "Art";
        ItemNames[1] = "White Book";
        ItemNames[2] = "Gray Book";
        ItemNames[3] = "Green Book";
        ItemNames[4] = "Coke";
        ItemNames[5] = "Necklace";


    }

    // Update is called once per frame
    void Update()
    {
        if (isUpdated == true)
        {
            Debug.Log("data received");
            Debug.Log(customerNumber);
            Debug.Log(itemNumber);

            itemPrice = Random.Range(1, 20) * 1000;


            nameText.text = "" + ItemNames[itemNumber - 1];
            priceText.text = "" + itemPrice;

            isUpdated = false;
        }
        else
        {

        }
    }
}
