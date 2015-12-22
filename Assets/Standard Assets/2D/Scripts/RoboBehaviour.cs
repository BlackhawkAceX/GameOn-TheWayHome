using UnityEngine;
using System.Collections;

public class RoboBehaviour : StateMachineBehaviour {

    private bool playOnceJump = true;
    private bool playOnceLand = true;
    private FMOD.Studio.EventInstance talkSound;
    private FMOD.Studio.EventInstance idleSound;
    private FMOD.Studio.EventInstance rollSound;
    private FMOD.Studio.EventInstance leavesSound;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (talkSound == null)
        {
            talkSound = FMODUnity.RuntimeManager.CreateInstance("event:/robo_talk");
            talkSound.start();
        }
        if (idleSound == null)
        {
            idleSound = FMODUnity.RuntimeManager.CreateInstance("event:/robo_idle");
            idleSound.start();
        }
        if (rollSound == null)
        {
            rollSound = FMODUnity.RuntimeManager.CreateInstance("event:/robo_rollScatter");
            rollSound.start();
        }
        if (leavesSound == null)
        {
            leavesSound = FMODUnity.RuntimeManager.CreateInstance("event:/robo_roll_leavesScatter");
            leavesSound.start();
        }
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        talkSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        idleSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        rollSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        leavesSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // play talk and idle sound
        talkSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(animator.gameObject.transform));
        idleSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(animator.gameObject.transform));
        if ((animator.GetFloat("Speed") != 1) && (animator.GetFloat("vSpeed") == 0))
        {
            talkSound.setVolume(1);
            idleSound.setVolume(1);
        }
        else
        {
            talkSound.setVolume(0);
            idleSound.setVolume(0);
        }
        
        // play roll sound according to speed parameter
        rollSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(animator.gameObject.transform));
        rollSound.setParameterValue("speed", animator.GetFloat("Speed"));
        // play leaves sound
        leavesSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(animator.gameObject.transform));
        leavesSound.setParameterValue("speed", animator.GetFloat("Speed"));
        
        // play jump sound (oneshot)
        if ((animator.GetFloat("vSpeed") > 11) && (playOnceJump == true))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/robo_jump", animator.gameObject.transform.position);
            playOnceJump = false;
            playOnceLand = true;
            leavesSound.setVolume(0);
        }
        
        // play land sound (oneshot)
        if ((animator.GetFloat("vSpeed") < -5) && (playOnceLand == true))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/robo_land", animator.gameObject.transform.position);
            playOnceLand = false;
            playOnceJump = true;
            leavesSound.setVolume(1);
        }
	}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
