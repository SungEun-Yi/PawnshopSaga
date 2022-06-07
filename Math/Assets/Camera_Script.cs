using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject Camera_Main;
    public GameObject Camera_Item1;
    public GameObject Camera_Item2;

    // Start is called before the first frame update
    void Start()
    {
        Camera_Main.SetActive(true);
        Camera_Item1.SetActive(false);
        Camera_Item2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
