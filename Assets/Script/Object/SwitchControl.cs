using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour {

    public GameObject Bridge;
	

    void SwitchOn()
    {
        GetComponent<Animator>().SetTrigger("play");
        Bridge.GetComponent<BridgeControl>().isOn = true;
    }
}
