using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementCharacter : MonoBehaviour
{   
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shootKey = KeyCode.Mouse1;
    public KeyCode attackKey = KeyCode.Mouse0;

    public KeyCode leftSlide = KeyCode.A;
    public KeyCode rightSlide = KeyCode.D;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisGround;

    bool grounded;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight *0.5f + 0.3f, whatisGround);
        MyInput();
        SpeedControl();

        //handel drag
        if(grounded)
        {
            rb.drag = groundDrag;
        } else
        {
            rb.drag = 0;
        }

        //Check if character fall down
        if(transform.position.y <= -7.5f)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate() 
    {
        MovePlayer();
        HandleRunAnimation();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);
        }

        if(Input.GetKey(attackKey))
        {
            HitAnimationTriggerHandler();
        }

        if(Input.GetKey(shootKey))
        {
            ShootAnimationTriggerHandler();
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else 
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity =  new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("isJumping"); 
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void HandleRunAnimation()
    {

        animator.SetFloat("Speed", rb.velocity.z);
    }

    private void HitAnimationTriggerHandler()
    {
        animator.SetTrigger("isHitting");
    }

    private void ShootAnimationTriggerHandler()
    {
        animator.SetTrigger("isShooting");
    }
}
