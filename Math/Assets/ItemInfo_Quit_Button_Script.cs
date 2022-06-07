using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo_Quit_Button_Script : MonoBehaviour
{
    Button QuitButton;

    public void OnClickQuitButton()
    {
        GameObject.Find("UI").transform.Find("ItemInfo_Panel").gameObject.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        QuitButton = GetComponent<Button>();
        QuitButton.onClick.AddListener(OnClickQuitButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
