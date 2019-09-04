using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbling : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerControl>().PlayerSound.PlayOneShot(animator.GetComponent<PlayerControl>().TreasureSound);
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.gameObject.GetComponent<PlayerControl>().Clear = true;
        animator.SetBool("GetGem", false);
	}

	
}
