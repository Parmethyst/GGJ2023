using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float deccelerationMultiplier = 5f;
    [SerializeField] float velocityThreshold = 10f;
    [SerializeField] float brakePressure = 10f;
    [SerializeField] float jumpStrength = 10f;
    [SerializeField] float groundedColliderOffset=1f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameInput input;
    [SerializeField] CapsuleCollider2D playerCollider;
    [SerializeField] LayerMask groundLayer;


    void OnEnable()
    {
        input.OnJumpInput += Jump;
    }
    void OnDisable()
    {
        input.OnJumpInput -= Jump;
    }
    void FixedUpdate()
    {
        Vector3 moveDir = new Vector3(input.GetMovementVectorNormalized().x, 0, 0);
        if (moveDir != Vector3.zero) rb.AddForce(moveDir * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        else rb.AddForce(new Vector2(-rb.velocity.x / deccelerationMultiplier + rb.velocity.x, 0f) * Time.deltaTime, ForceMode2D.Force);
        float speed = Vector3.Magnitude(rb.velocity);  // test current object speed

        if (speed > velocityThreshold)

        {
            float brakeSpeed = speed - velocityThreshold;  // calculate the speed decrease

            Vector3 normalisedVelocity = rb.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed * brakePressure * Time.fixedDeltaTime;  // make the brake Vector3 value
            brakeVelocity = new Vector3(brakeVelocity.x,0f,0f);

            rb.AddForce(-brakeVelocity, ForceMode2D.Force);  // apply opposing brake force
        }
    }
    void Update() {
        IsGrounded();
    }
    public void Jump()
    {
        if(IsGrounded()) {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            
        }
    }
    public bool IsGrounded() {
        RaycastHit2D raycastHit=Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size*0.9f,0f,Vector2.down,groundedColliderOffset,groundLayer);
        Color rayColor;
        if(raycastHit.collider!=null) {
            rayColor=Color.green;
        }
        else rayColor=Color.red;
        Debug.DrawRay(playerCollider.bounds.center + new Vector3(playerCollider.bounds.extents.x,0), Vector2.down* (playerCollider.bounds.extents.y * groundedColliderOffset), rayColor);
        Debug.DrawRay(playerCollider.bounds.center - new Vector3(playerCollider.bounds.extents.x,0), Vector2.down* (playerCollider.bounds.extents.y * groundedColliderOffset), rayColor);
        Debug.DrawRay(playerCollider.bounds.center - new Vector3(playerCollider.bounds.extents.x, playerCollider.bounds.extents.y*groundedColliderOffset), Vector2.right* (playerCollider.bounds.extents.y), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider!=null;
    }
}
