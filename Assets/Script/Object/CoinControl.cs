using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour {

	
	void Update () {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerControl>().CollectedCoin++;
            //col.gameObject.GetComponent<AudioSource>().clip = col.gameObject.GetComponent<PlayerControl>().CoinSound;
            col.gameObject.GetComponent<AudioSource>().PlayOneShot(col.gameObject.GetComponent<PlayerControl>().CoinSound, 3);
            Destroy(this.gameObject);
        }
    }
}
