using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton_Script : MonoBehaviour
{
    Button shopButton;

    public GameObject shopUI;

    public void OnClickShopButton()
    {
        shopUI.SetActive(true);
        Debug.Log("shopbutton clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        shopButton = GetComponent<Button>();
        shopButton.onClick.AddListener(OnClickShopButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
