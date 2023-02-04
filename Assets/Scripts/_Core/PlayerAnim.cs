using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameInput input;
    [SerializeField] Animator animator;
    private bool isLastDirRight=true;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
