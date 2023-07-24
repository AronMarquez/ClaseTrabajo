using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;

    private float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    public float jumpHeight = 2;

    public bool isSprinting;

    public float sprintingSpeedMultiplier = 1.5f;

    public float sprintSpeed = 1;

    public float staminaUseAmount = 5;

    private StaminaBar staminaSlider;

    public Animator animator;

    private void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float X = Input.GetAxis("Horizontal");

        float Z = Input.GetAxis("Vertical");

        animator.SetFloat("VelX",X);
        animator.SetFloat("VelZ",Z);
        animator.SetBool("IsSprinting", isSprinting);

        Vector3 move = transform.right * X + transform.forward * Z;

        JumpCheck();

        RunCheck();

        characterController.Move(move * speed * Time.deltaTime*sprintSpeed);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);    

    }

    public void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            animator.SetBool("IsJumping", true);

        }
        if (!isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }


    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;

            if (isSprinting == true)
            {
                staminaSlider.UseStamina(staminaUseAmount);
            }
            else
            {
                staminaSlider.UseStamina(0);
            }
        }
        if (isSprinting == true)
        {
            sprintSpeed = sprintingSpeedMultiplier;           
        }
        else
        {
            sprintSpeed = 1;
        }
    }
}
