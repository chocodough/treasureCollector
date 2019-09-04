using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour {


    //자신이 원하는 랜덤한 블록이 다리의 구성요소가 됩니다.
    public GameObject[] bridgeComponent;
    //timer 이후 블록이 지하에서부터 올라옵니다.
    public float timer = 3.0f;
    public AudioClip adc;

    //isOn true 이면 블록을 생성하고 블럭이 존재해야 할 위치까지 올려보냅니다. 
    //isOn이 false이고 동작이 작동중일 때 다리를 사라지게 합니다.
    public bool isOn = false;
    //현재 동작이 작동중인지 판단하는 함수입니다.
    private bool nowAction =false;
    private bool isUp = false;


	// Use this for initialization
	void Start () {
        //isOn = true;
	}
	
	// Update is called once per frame
	void Update () {


        //off하지 않으면 isOn과 nowAction은 true입니다. 조건을 파악하고 한번만(다시 돌아가는 동작을 할 때까지) 작동합니다. 
        if (isOn == true && nowAction == false && isUp == false)
        {
            nowAction = true;


            //child의 개수를 파악하고 그 위치를 파악하여 다리를 만드는 함수를 호출.
            Transform thisT = gameObject.transform;
            for (int i = 0; i< thisT.childCount ; i++)
            {
                //child의 위치 파악
                Transform targetT = thisT.GetChild(i).transform;
                

                //function(targetT, thisT.childCount)

                MakeBridge(targetT, bridgeComponent.Length);

            }




        }

        //동작 작동중, 오브젝트에 할당된 다리를 삭제한다.
        else if(isOn == false && nowAction == false && isUp == true)
        {
            nowAction = true;

            Transform thisT = gameObject.transform;
            for (int i = 0; i < thisT.childCount; i++)
            {
                //child의 위치 파악
                Transform targetT = thisT.GetChild(i).transform;
                

                //function(targetT, thisT.childCount)
                //child에 다리가 있으면 파괴하고 nowaction,isUp false로 변경  
                //MakeBridge(targetT, thisT.childCount);
                if(targetT.childCount >= 1)
                {
                    for(int j = 0; j< targetT.childCount; j++)
                    {
                        GameObject targetG = targetT.GetChild(j).gameObject;
                        AudioSource.PlayClipAtPoint(adc, targetG.transform.position);

                        Destroy(targetG);
                    
                    }
                }




                isUp = false;
                nowAction = false;
            }
        }

	}




    private void MakeBridge(Transform target, int CC)
    {
        Debug.Log(CC);
        Vector3 generatingPosition = target.position + new Vector3(0, -Random.Range(5.0f, 10.0f), 0);
        GameObject presentBridgeComponent = bridgeComponent[Random.Range(0, CC)]; //문제발생
        Debug.Log(presentBridgeComponent);


        Debug.Log(generatingPosition);

        GameObject bridgePiece = Instantiate(presentBridgeComponent,generatingPosition,target.rotation,target.transform) as GameObject ;

        StartCoroutine(moveBridgepiece(bridgePiece, target));

    }
     

    
    
    IEnumerator moveBridgepiece(GameObject bridgePiece, Transform targetTransform)
    {
        //Debug.Log("상승함수 작동");
        float functionOver= 0;
        
        Vector3 distance = (targetTransform.position - bridgePiece.transform.position );
        while (true)
        {
            functionOver += Time.deltaTime;

            bridgePiece.transform.position += distance * (Time.deltaTime / timer);

            if (functionOver >= timer)
            {
                nowAction = false;
                isUp = true;
                //AudioSource.PlayClipAtPoint(adc, bridgePiece.transform.position);
                break;
            }


            yield return new WaitForEndOfFrame();
        }
    }
        
        



        




}





