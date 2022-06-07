using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Script : MonoBehaviour
{
    public Button StartButton;
    public Button QuitButton;

    public GameObject Camera_Title;
    public GameObject Camera_Main;
    public GameObject Camera_Item1;
    public GameObject Camera_Item2;

    public GameObject UI;
    public GameObject TitleUI;

    public void setUI()
    {
        UI.SetActive(true);
        TitleUI.SetActive(false);
    }

    public void OnClickStartButton()
    {
        

        Camera_Title.SetActive(false);
        Camera_Main.SetActive(true);
        Camera_Item1.SetActive(false);
        Camera_Item2.SetActive(false);

        setUI();

        Debug.Log("TitleButton Clicked");        
    }
    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("QuitButton Clicked");
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1980, 1080, false);

        StartButton.onClick.AddListener(OnClickStartButton);
        QuitButton.onClick.AddListener(OnClickQuitButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
