using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour {
    
    [Range(0.0f, 0.2f)]
    public float shakeAmount = 0.1f;
    public bool isShake = false;


    private Vector3 presentPosition;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        presentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(isShake == true && timer < shakeAmount)
        {
            timer += Time.deltaTime;
            transform.Translate(Random.value * shakeAmount - shakeAmount / 2, Random.value * shakeAmount - shakeAmount / 2, 0);

            if (timer > shakeAmount)
            { 
                transform.position = presentPosition;
                timer = 0;
                isShake = false;
            }
        }
	
	}

    

}
