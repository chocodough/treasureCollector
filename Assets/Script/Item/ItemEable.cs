using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEable : MonoBehaviour {


    void OnCollisionStay(Collision col)
    {
       
        if (GetComponent<Rigidbody>().velocity.y == 0)
            GetComponentInChildren<CapsuleCollider>().enabled = true;
    }
}
