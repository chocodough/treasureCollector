using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 플레이어가 소드를 들었을 경우의 동작
 */
public class SwordControl: MonoBehaviour {
    public GameObject Player;
   
    void Start () {
        Player = GameObject.FindWithTag("Player");
    }
    
    /*
     * 공격받은 피격물의 동작을 지정
     */ 
    void OnTriggerEnter(Collider col) {
        if(Player.GetComponent<Animator>().GetBool("IsAttacking")){ 
            if (col.tag == "Bush"){
                col.gameObject.GetComponent<BushControl>().hp--;
            } 

            if(col.tag == "Box"){
                col.gameObject.SendMessage("Open");
            }
            if(col.tag == "Switch"){
                col.gameObject.SendMessage("SwitchOn");
            }
            if (col.tag == "KingBox"){
                col.gameObject.SendMessage("Open");
            }
        }
    }
}
