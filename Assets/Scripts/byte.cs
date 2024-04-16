using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 45f;

    private bool isJumping = false;


    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.forward * Input.GetAxis("Vertical")* speed;
        transform.Translate(velocity * Time.deltaTime * 2);
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
        animator.SetFloat("Speed", velocity.z);

        // if(Input.GetKeyDown("space")){
        //     animator.SetBool("isJumping", false);
        // } else {

        // }
    }
}
