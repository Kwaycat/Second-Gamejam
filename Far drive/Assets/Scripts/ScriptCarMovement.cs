using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCarMovement : MonoBehaviour
{
    [Header("Car settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 20f;

    public float skidTollerance = 0.75f;

    //Local variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp = 0;

    //components
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthoginalVelocity();

        ApplySteeringForce();
    }

    void ApplyEngineForce() {
        //Calculate how much "forward" we are going in terms of the direction of out velocity
        velocityVsUp = Vector2.Dot(transform.up, rb.velocity);

        //Limit so we cannot go faster than the max speed in the "forward" direction
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
            return;

        //Limit so we cannot go faster than the 50% of max speed om tjhe "reverse" direction
        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
            return;

        //Limit so we cannot go faster in any direction while acceleration
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        //Apply drag if there is no accelerationInput so the car stops when the playter lets go of the accelerator
        if (accelerationInput == 0) 
            rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.fixedDeltaTime * 3);
        else rb.drag = 0;
        

        //Create a  force for the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply force and push the car forward
        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteeringForce() {
        //Flip turning if reversing
        if (accelerationInput != 1 && velocityVsUp < 0) {
            steeringInput = -steeringInput;
        }
        //Limit the cars ability to turn when moving slowly
        float minSpeedBeforeAllowTurningFactor = (rb.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        //Apply steering by rotating the car object
        rb.MoveRotation(rotationAngle);
    }

    void KillOrthoginalVelocity() {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    float GetLateralVelocity() {
        //Returns how fast the car is moving sideways
        return Vector2.Dot(transform.right, rb.velocity);
    }

    public bool IsTireScreeching(out float lateralVelocity, out bool isBreaking) {
        lateralVelocity = GetLateralVelocity();
        isBreaking = false;

        //Check if we are moving forward and if the player is hitting the brakes. In that case the tires should screech
        if (accelerationInput < 0 && velocityVsUp > 0) {
            isBreaking = true;
            return true;
        }

        //If we have a lot of side movement then the tires should be screeching
        if (Mathf.Abs(GetLateralVelocity()) > skidTollerance)
            return true;

        return false;
    }

    public void SetInputVector(Vector2 inputVector) {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
