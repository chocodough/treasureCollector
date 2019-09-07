using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 아이템의 충돌박스와 중력을 활성화한다
 */
public class ItemEable : MonoBehaviour {
      void OnCollisionStay(Collision col)
      {
        if (GetComponent<Rigidbody>().velocity.y == 0)
            GetComponentInChildren<CapsuleCollider>().enabled = true;
      }
}
