using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_box : MonoBehaviour {

    bool isBox_alert = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && !isBox_alert)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().Looking_At(col.gameObject.transform.position, 1);
            isBox_alert = true;
        }
    }
}
