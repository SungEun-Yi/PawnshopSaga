using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCitizen2_script : MonoBehaviour
{
    bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10.0f, -0.45f, -13f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight == true)
            transform.position += new Vector3(1.5f, 0f, 0f) * Time.deltaTime;
        else if (isRight == false)
            transform.position -= new Vector3(1.5f, 0f, 0f) * Time.deltaTime;



        if (isRight == true && transform.position.x > 10f)
        {
            isRight = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (isRight == false && transform.position.x < -16f)
        {
            isRight = true;
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

    }
}
