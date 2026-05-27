using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{

    public int hitPoints = 3;

    Dictionary<WolfAnimationState, string> behaviors =  new()
    {
        {WolfAnimationState.Attack1,  "isAttack1"  },
        {WolfAnimationState.Attack2,  "isAttack2"  },
        {WolfAnimationState.Breathes, "isBreathes" },
        {WolfAnimationState.Damage,   "isDamage"   },
        {WolfAnimationState.Die,      "isDie"      },
        {WolfAnimationState.Digs,     "isDigs"     },
        {WolfAnimationState.Eating,   "isEating"   },
        {WolfAnimationState.Howl,     "isHowl"     },
        {WolfAnimationState.Run,      "isRun"      },
        {WolfAnimationState.Sit,      "isSit"      },
        {WolfAnimationState.Walk,     "isWalk"     }
    };

    public Animator animator;
    public WolfAnimationState initialState = WolfAnimationState.Sit;
    private WolfAnimationState currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = initialState;
        SetState(initialState);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetState(WolfAnimationState state)
    {
        if (animator == null) return;

        animator.SetBool(behaviors[currentState], false);
        animator.SetBool(behaviors[state], true);
        currentState = state;
    }
    public void Hit(int damage = 1)
    {
        SetState(WolfAnimationState.Damage);
        hitPoints = hitPoints - damage;
        if (hitPoints <= 0)
        {
            //Debug.Log($"NPCController:: Hit dead: {hitPoints}");
            animator.SetBool(behaviors[WolfAnimationState.Damage], false);
            animator.StopPlayback();
            animator.Play("die");
            UICanvasController.instance.SetScoreValue(1);
        }
    }
}
public enum WolfAnimationState
{
    Attack1,
    Attack2,
    Breathes,
    Damage,
    Die,
    Digs,
    Eating,
    Howl,
    Run,
    Sit,
    Walk
}



