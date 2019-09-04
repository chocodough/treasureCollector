using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Heal : StateMachineBehaviour {

    public GameObject Player;
    public Color OriginColor;
    public Color TransParent;
    public float time = 0f;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<Transform>().position = Player.GetComponent<PlayerControl>().RevivePosition.GetComponent<Transform>().position;
        Player.GetComponent<Transform>().rotation = Player.GetComponent<PlayerControl>().RevivePosition.GetComponent<Transform>().rotation;
        animator.SetBool("LifeIs0", false);
        animator.SetBool("Healed", true);
        animator.SetBool("IsReviving", true);
        OriginColor = Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        TransParent = new Color(120f, 120f, 120f, 0f);
        Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Legacy Shaders/Transparent/Bumped Diffuse");
        Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color = TransParent;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        time += Time.deltaTime;
        if(time > 0.1f)
        {
            time = 0f;
            if (Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color == OriginColor)
                Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color = TransParent;
            else if (Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color == TransParent)
                Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color = OriginColor;
        }
        //Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = 
        //Debug.Log(Player.tag);
        //animator.avatar.
        //animator.GetCurrentAnimatorClipInfo(0).
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Player.GetComponentInChildren<SkinnedMeshRenderer>().material.shader = Shader.Find("Toon/Lighted");
        Player.GetComponentInChildren<SkinnedMeshRenderer>().material.color = OriginColor;
        
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
