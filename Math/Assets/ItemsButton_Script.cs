using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsButton_Script : MonoBehaviour
{
    Button ItemsButton;

    public GameObject Camera_Main;
    public GameObject Camera_Item1;
    public GameObject Camera_Item2;


    public void OnClickItemsButton()
    {
        Camera_Main.SetActive(false);
        Camera_Item1.SetActive(true);
        Camera_Item2.SetActive(false);

        GameObject.Find("UI").transform.Find("Undo_Button").gameObject.SetActive(true);

        Debug.Log("itemsbutton clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        ItemsButton = GetComponent<Button>();
        ItemsButton.onClick.AddListener(OnClickItemsButton);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
