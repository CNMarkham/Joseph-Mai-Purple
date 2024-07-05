using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehavior : StateMachineBehaviour
{

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
        animator.enabled = false;
        Rigidbody2D rb = animator.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * 4f;
  }

}
