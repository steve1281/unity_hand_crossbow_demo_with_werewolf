using System;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Animator animator;
    public AnimationState initialState = AnimationState.Idle;

    public GameObject pickAxe;
    public GameObject basket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetState(initialState);
    }

    public void SetState(AnimationState state)
    {
        if (animator == null)  return; 

        switch (state)
        {
            case AnimationState.Moving:
                animator.SetBool("isMoving", true);
                break;
            case AnimationState.Jumping:
                animator.SetBool("isJumping", true);
                break;
            case AnimationState.Mining: 
                if (pickAxe) pickAxe.SetActive(true);
                animator.SetBool("isMining", true);
                break;

            case AnimationState.SpellCast: 
                animator.SetBool("isSpellCast", true);
                break;
            case AnimationState.Gathering: 
                if (basket) basket.SetActive(true);
                animator.SetBool("isGathering", true);
                break;

            default:
                if (pickAxe) pickAxe.SetActive(false);
                if (basket) basket.SetActive(false);
                animator.SetBool("isMoving", false);
                animator.SetBool("isJumping", false);
                animator.SetBool("isMining", false); 
                animator.SetBool("isGathering", false); 
                break;
        }
    }
    public enum AnimationState
    {
        Moving, Jumping, Idle, Mining, SpellCast, Gathering,
        BlockingLoop, BowShot, Buff, CastingLoop,
        Death, GetHit, IdleCombat, MeleeAttack_OneHanded,
        MeleeAttack_TwoHanded, PunchLeft, PunchRight,
        StunnedLoop, MiningLoop, FallingLoop,
        Jumps, JumpWhileRunning, RollBackward, RollForward,
        RollLeft, RollRight, RunBackward, RunBackwardLeft,
        RunBackwardRight, RunForward, RunLeft, RunRight,
        Sprint, StrafeLeft, StrafeRight
    }
}
