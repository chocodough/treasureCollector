using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBoxControl : MonoBehaviour {

    public GameObject Item;

    void Open()
    {
        GetComponent<Animator>().SetBool("StartOpen", true);
    }

    void PopItem()
    {
        GameObject PopedItem = Instantiate(Item, transform.position + new Vector3(0, 1f, 0), transform.rotation);   
    }
}
