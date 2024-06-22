using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody physics;
    public float jumpForce = 5f;
    private Animator _animator;
    public bool isGrounded; // Variable para verificar si el jugador está en el suelo

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TeleportPlayer()
    {
        transform.position += new Vector3(0, 5f, 5f);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        movement = transform.TransformDirection(movement).normalized * speed * Time.deltaTime;

        physics.MovePosition(physics.position - movement);
        _animator.SetFloat("posX", Mathf.Abs(horizontal));
        _animator.SetFloat("posX", Mathf.Abs(vertical));

        float rotationY = Input.GetAxis("Mouse X") * 10f;
        transform.Rotate(0, rotationY, 0);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            physics.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            _animator.SetTrigger("Jump");
        }

        if (!isGrounded)
        {
            _animator.SetFloat("jump", physics.velocity.y);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        CheckIfGrounded(collision);
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckIfGrounded(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void CheckIfGrounded(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                _animator.SetFloat("jump", 0.0f);
                return;
            }
        }
        isGrounded = false;
    }
}
