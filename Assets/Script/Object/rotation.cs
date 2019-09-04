using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

   
    
    public float time = 0;
    

    void Update () {

        time += Time.deltaTime;
        if (time >= 360)
            time = 0;

        transform.rotation = Quaternion.Euler(30, time * 200, 0);
    }
}
