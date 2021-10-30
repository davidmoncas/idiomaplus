using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement of the player with the ASDW keys or the arrows
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float normalVelocity;
    public float initialStamina;

    [HideInInspector] public float stamina;
    [HideInInspector] public float velocity;

    [SerializeField] Transform cameraDirection;
    [SerializeField] Animator anim;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        velocity = normalVelocity;
        stamina = initialStamina;
    }


    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) { // get the orientation of the camera
            Vector3 directionForward = cameraDirection.forward;
            directionForward.y = 0;
            transform.forward = directionForward; 
        
        }


        
        if (Input.GetKey(KeyCode.Space) && rb.velocity.magnitude > 0.1f) Run(Time.deltaTime); // Press the spacebar to run
        else RegenerateStamina(Time.deltaTime);
       
        if (Input.GetKeyUp(KeyCode.Space) || stamina < 0) velocity = normalVelocity;    // stop pressing space or run out of stamina

        Vector3 movementVector = this.transform.forward * Input.GetAxis("Vertical") + this.transform.right * Input.GetAxis("Horizontal");
        Move(movementVector);

        anim.SetFloat("speed", rb.velocity.magnitude);
        anim.SetFloat("speedX", Input.GetAxis("Horizontal"));
        anim.SetFloat("speedY", Input.GetAxis("Vertical"));
    }

    void Run(float deltaTime) {
        if (stamina > 0) {
            velocity = normalVelocity * 4f;
            stamina -= Time.deltaTime * 4;
        }
    }

    void RegenerateStamina(float deltaTime) {
        stamina += deltaTime * 1;
        stamina = Mathf.Clamp(stamina, 0, initialStamina);
    }

    private void Move(Vector3 speed)
    {
        rb.velocity = speed * velocity;
    }
}
