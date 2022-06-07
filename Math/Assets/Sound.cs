using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource titleBGM;
    public AudioSource mainBGM;

    public AudioSource shopBellSound;
    public AudioSource buttonClickSound;

    public Button startButton;
    public Button purchaseButton;

    // Start is called before the first frame update
    void Start()
    {
        titleBGM.Play();

        startButton.onClick.AddListener(startButtonClicked);
        purchaseButton.onClick.AddListener(purchaseButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void purchaseButtonClicked()
    {
        playShopBellSound();
    }
    void startButtonClicked()
    {
        titleBGM.Stop();
        mainBGM.Play();
    }

    public void playShopBellSound()
    {
        shopBellSound.PlayOneShot(shopBellSound.clip);
    }

    public void playButtonClickSound()
    {
        buttonClickSound.PlayOneShot(buttonClickSound.clip);
    }
}
