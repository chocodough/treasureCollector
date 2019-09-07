using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Tool 박스의 동작을 구현한다
 */
public class BoxControl : MonoBehaviour {
    //상자에서 나오는 아이템
    public GameObject Item;


    /*
     * 박스열림 동작을 구현한다.
     */
    void Open(){
        GetComponent<Animator>().SetBool("StartOpen",true);
    }

    /*
     * 튀어나올 아이템의 동작을 구헌한다.
     */
    void PopItem(){
        GameObject PopedItem = Instantiate(Item, transform.position + new Vector3(0,0.3f,0), transform.rotation);  
        PopedItem.GetComponent<Rigidbody>().AddForce(70, 100, 0);
    }
}
