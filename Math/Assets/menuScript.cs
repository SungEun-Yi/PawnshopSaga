using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public Button PauseButton;
    public Button startButton;
    public Button continueButton;
    public GameObject TitleUI;

    // Start is called before the first frame update
    void Start()
    {
        PauseButton.onClick.AddListener(PauseClicked);
        continueButton.onClick.AddListener(continueClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PauseClicked()
    {
        startButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);

        TitleUI.SetActive(true);
        
    }
    void continueClicked()
    {
        startButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        TitleUI.SetActive(false);
    }
}
