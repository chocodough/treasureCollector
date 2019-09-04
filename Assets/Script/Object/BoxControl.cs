using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour {

    //ToolBox의 스크립트

    public GameObject Item; //상자에서 나올 아이템

    void Open()
    {
        GetComponent<Animator>().SetBool("StartOpen",true);
    }

    void PopItem()
    {
        GameObject PopedItem = Instantiate(Item, transform.position + new Vector3(0,0.3f,0), transform.rotation);  
        PopedItem.GetComponent<Rigidbody>().AddForce(70, 100, 0);
    }
}
