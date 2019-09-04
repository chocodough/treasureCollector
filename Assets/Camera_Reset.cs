using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Reset : MonoBehaviour {

    GameObject a;

    //bool isCheck = false;
    public float resetDistance;
    public float resetHeight;

    // Use this for initialization
    void Start()
    {
        a = GameObject.FindWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            a.GetComponent<CameraControl>().distance = resetDistance;
            a.GetComponent<CameraControl>().height = resetHeight;
            //a.GetComponent<CameraControl>().Looking_At(this.transform.position, 1);
            //isCheck = true;
        }
    }

}
