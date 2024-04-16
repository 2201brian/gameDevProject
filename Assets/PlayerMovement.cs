using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

  
{

    public float speed = 1f;
    private Rigidbody phisics;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        phisics = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TeleportPlayer()
    {
        transform.position += new Vector3(0, 5f, 5f);
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(-horizontal, 0.0f, -vertical) * Time.deltaTime * speed);


        float rotationY = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3(0, rotationY, 0) * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            phisics.AddForce(new Vector3(0,jumpForce,0),ForceMode.Impulse);
        }


    }

}
