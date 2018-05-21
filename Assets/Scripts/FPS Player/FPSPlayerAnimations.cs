using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSPlayerAnimations : NetworkBehaviour {

    private Animator anim;

    // Parameters
    private string MOVE = "Move";
    private string VELOCITY_Y = "VelocityY";
    private string CROUCH = "Crouch";
    private string CROUCH_WALK = "CrouchWalk";

    private string STAND_SHOOT = "StandShoot";
    private string CROUCH_SHOOT = "CrouchShoot";
    private string RELOAD = "Reload";

    public RuntimeAnimatorController animController_SingleHand, animController_DualHand;

    private NetworkAnimator networkAnim;

    void Awake () {
        anim = GetComponent<Animator> ();
        networkAnim = GetComponent<NetworkAnimator> ();
    }

    public void Movement (float magnitude) {
        anim.SetFloat (MOVE, magnitude);
    }

    public void PlayerJump (float velocity) {
        anim.SetFloat (VELOCITY_Y, velocity);
    }

    public void PlayerCrouch (bool is_Crouching) {
        anim.SetBool (CROUCH, is_Crouching);
    }

    public void PlayerCrouchWalk (float magnitude) {
        anim.SetFloat (CROUCH_WALK, magnitude);
    }

    public void Shoot (bool isStanding) {
        if (isStanding) {
            anim.SetTrigger (STAND_SHOOT);

            // TRIGGERS NEED TO BE SYNCED MANUALLY
            networkAnim.SetTrigger (STAND_SHOOT);
        } else {
            anim.SetTrigger (CROUCH_SHOOT);

            // TRIGGERS NEED TO BE SYNCED MANUALLY
            networkAnim.SetTrigger (CROUCH_SHOOT);
        }
    }

    public void Reload () {
        anim.SetTrigger (RELOAD);

        // TRIGGERS NEED TO BE SYNCED MANUALLY
        networkAnim.SetTrigger (RELOAD);
    }

    public void ChangeController (bool isSingleHand) {
        if (isSingleHand) {
            anim.runtimeAnimatorController = animController_SingleHand;
        } else {
            anim.runtimeAnimatorController = animController_DualHand;
        }
    }

} // FPSPlayerAnimations