using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpitItem : MonoBehaviour {

    public bool isSpit = false;
    public GameObject[] SpitObject;
    public Vector3 SpitDirect = new Vector3(0, 1.0f,0);
    [Range(50f, 250f)]
    public float SpitPower = 150f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isSpit == true && SpitObject.Length != 0)
        {
            for(int i = 0; i< SpitObject.Length; i++)
            {
                GameObject appearInS = Instantiate(SpitObject[i], transform.position, transform.rotation);
                if (appearInS.GetComponent<Rigidbody>() == true)
                {
                    Vector3 Direct = SpitDirect.normalized;


                    appearInS.GetComponent<Rigidbody>().AddForce(SpitPower * Direct );
                    
                }
            }
        }


        isSpit = false;
	}
}
