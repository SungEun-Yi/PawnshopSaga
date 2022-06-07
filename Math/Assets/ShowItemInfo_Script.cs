using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemInfo_Script : MonoBehaviour
{
    public Camera getCamera;

    public Text itemInfo_Name;
    public GameObject Database;
    public Database_Script databaseScript;
    // Start is called before the first frame update
    void Start()
    {
        databaseScript = Database.GetComponent<Database_Script>();
    }
    private RaycastHit hit;

    // Update is called once per frame
    void Update() 
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if("Item" == hit.collider.tag)
                {
                    Debug.Log(hit.collider.name);                   
                    // ������ itemInfo �����ϴ� �۾�
                    itemInfo_Name.text = hit.collider.name;
                    // database�� �ֱ� Ŭ���� ������ �̸� ������Ʈ
                    databaseScript.selectedItemName = hit.collider.name;

                    //UI�� ����
                    //GameObject.Find("UI").transform.Find("ItemInfo_Panel").gameObject.SetActive(true);
                    databaseScript.showItemInfo();
                }
                
            }
        }

       
       
    }
}
