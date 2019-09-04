using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_Credit : MonoBehaviour {

    public Text[] credits;
    int i = 0;
    //float[] speeds;

	void Start () {
        InvokeRepeating("Credits", 2, 2);
	}
	
	void Update ()
    {
        for( int j = 0; j < i; j++)
        {
            credits[j].transform.Translate(0, Time.deltaTime * 75.0f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Main");
    }

    void Credits()
    {
        if(i < credits.Length - 1 )
            i++;
    }
}
