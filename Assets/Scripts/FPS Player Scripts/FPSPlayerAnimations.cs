using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerAnimations : MonoBehaviour {

    private Animator anim;

    // Parameters
    private string MOVE = "Move";
    private string VELOCITY_Y = "VelocityY";
    private string CROUCH = "Crouch";
    private string CROUCH_WALK = "CrouchWalk";

    void Awake () {
        anim = GetComponent<Animator> ();
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

} // FPSPlayerAnimations