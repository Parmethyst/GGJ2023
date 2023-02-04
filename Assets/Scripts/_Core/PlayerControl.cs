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
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameInput input;
    [SerializeField] CapsuleCollider2D collider;


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

            rb.AddForce(-brakeVelocity, ForceMode2D.Force);  // apply opposing brake force
        }
    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Force);
    }
}
