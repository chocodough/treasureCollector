using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
    //[Range(0.0f, 0.2f)]
    public float shakeAmount = 0.1f;
    public bool isShaking = false;
    public int RockLife = 3;
    public AudioClip Crash;
    private Vector3 presentPosition;
    private float timer = 0;


    public GameObject Boom;
    //public ParticleSystem Shake;
     
    // Use this for initialization
    void Start()
    {
        presentPosition = transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        presentPosition = transform.parent.transform.position;
        if (isShaking == true && timer < shakeAmount)
        {
            if (RockLife == 0)
            {
                Instantiate(Boom,transform.position,transform.rotation);
                Boom.GetComponent<ParticleSystem>().Play();
                Destroy(transform.parent.gameObject);
                AudioSource.PlayClipAtPoint(Crash, transform.position);
            }
            timer += Time.deltaTime;
            transform.Translate(Random.value * shakeAmount - shakeAmount / 2, Random.value * shakeAmount - shakeAmount / 2, 0);

            if (timer > shakeAmount)
            {
                
                transform.position = presentPosition;
                timer = 0;
                isShaking = false;
                RockLife--;
            }
        }

        

    }
}
    