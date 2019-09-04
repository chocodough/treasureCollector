using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Revive : StateMachineBehaviour {

    public GameObject Player;
   
    public float time = 0f;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Player.GetComponent<Transform>().position = Player.GetComponent<PlayerControl>().RevivePosition.GetComponent<Transform>().position;  
        Player.GetComponent<Transform>().rotation = Player.GetComponent<PlayerControl>().RevivePosition.GetComponent<Transform>().rotation;  // 부활지점으로 이동 및 속도를 0으로


        animator.SetBool("LifeIs0", false);
        animator.SetBool("Healed", true);
        animator.SetBool("IsReviving", true);
        
        Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Standard");
      
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

   
        time += Time.deltaTime;
        if (time > 0.1f)
        {
            time = 0f;
            if (Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader == Shader.Find("Standard"))
            {
                Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Toon/Lighted");
            }
            else if (Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader == Shader.Find("Toon/Lighted"))
            {
                Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Standard");
               
            }
        }

    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Toon/Lighted");
        //Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color = OriginColor;
        animator.SetBool("IsReviving", false);
    }

	
}
