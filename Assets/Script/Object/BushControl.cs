using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushControl : MonoBehaviour
{

    public int hp = 3;
    public float f = 0.5f;
    public GameObject particle;
    public AudioClip WhenBoom;
    public AudioClip WhenShake;

    private GameObject player;
    private bool shakeable = true;
    private Animator playerAC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword" && shakeable == true && playerAC.GetBool("IsAttacking") == true)
        {
            shakeable = false;
            gameObject.GetComponent<ObjectShake>().isShake = true;
            if (WhenShake != null)
            {
                AudioSource.PlayClipAtPoint(WhenShake, transform.position);
            }
            StartCoroutine(WaitFloatTime(f));
        }
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAC = player.GetComponent<Animator>();


    }
    void Update()
    {
        if (hp == 0)
        {
            if (WhenBoom != null)
            {
                AudioSource.PlayClipAtPoint(WhenShake, transform.position);
            }

            GameObject p = Instantiate(particle, transform.position, transform.rotation) as GameObject;
            Destroy(this.gameObject);

        }
    }

    IEnumerator WaitFloatTime(float f)
    {
        yield return new WaitForSeconds(f);
        shakeable = true;
    }

}
