using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UndoButton_Script : MonoBehaviour
{
    Button UndoButton;

    public GameObject Camera_Main;
    public GameObject Camera_Item1;
    public GameObject Camera_Item2;

    public void OnClickUndoButton()
    {
        Camera_Main.SetActive(true);
        Camera_Item1.SetActive(false);
        Camera_Item2.SetActive(false);

        UndoButton.gameObject.SetActive(false);

        Debug.Log("UndoButton Clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        UndoButton = GetComponent<Button>();
        UndoButton.onClick.AddListener(OnClickUndoButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
