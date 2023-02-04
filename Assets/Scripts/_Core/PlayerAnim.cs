using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";
    private const string IS_START_JUMPING ="isStartJumping";
    private const string IS_JUMPING="isJumping";
    private const string IS_FINISHED_JUMPING="isFinishedJumping";
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameInput input;
    [SerializeField] Animator animator;
    [SerializeField] PlayerControl player;
    private bool isLastDirRight=true;
    private bool isStartJumping=false;
    private bool isJumping=false;
    private bool isFinishedJumping=false;
    // Start is called before the first frame update
    void OnEnable() {
        input.OnJumpInput += StartJump;
    }
    void OnDisable() {
        input.OnJumpInput -= StartJump;
    }

    // Update is called once per frame
    void Update() {
        if(!isLastDirRight) spriteRenderer.flipX=true;
        else spriteRenderer.flipX=false;
        Vector3 moveDir = new Vector3(input.GetMovementVectorNormalized().x, 0, 0);
        if(moveDir.x>0) isLastDirRight=true;
        else if(moveDir.x<0) isLastDirRight= false;
        if(moveDir!=Vector3.zero) {
            animator.SetBool(IS_WALKING, true);
        }
        else animator.SetBool(IS_WALKING, false);
        if(animator.GetBool(IS_JUMPING) && player.IsGrounded()) {
            animator.SetTrigger(IS_FINISHED_JUMPING);
            animator.SetBool(IS_JUMPING,false);
            animator.SetBool(IS_START_JUMPING,false);
        }
    }
    public void StartJump() {
        if(player.IsGrounded() && !animator.GetBool(IS_START_JUMPING)) {
            animator.SetBool(IS_START_JUMPING,true);
            
        }
        animator.SetBool(IS_JUMPING,true);
    }
}
