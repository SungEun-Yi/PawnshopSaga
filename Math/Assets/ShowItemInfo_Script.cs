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
                    // 출현한 itemInfo 수정하는 작업
                    itemInfo_Name.text = hit.collider.name;
                    // database에 최근 클릭한 아이템 이름 업데이트
                    databaseScript.selectedItemName = hit.collider.name;

                    //UI를 띄우기
                    //GameObject.Find("UI").transform.Find("ItemInfo_Panel").gameObject.SetActive(true);
                    databaseScript.showItemInfo();
                }
                
            }
        }

       
       
    }
}
