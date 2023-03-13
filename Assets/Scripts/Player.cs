using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject groundCheck;
    public float moveSpeed = 7.0f;
    public float acceleration = 50.0f;
    private float moveX;
    public float jumpSpeed = 10.0f;
    Rigidbody Rigidbody;
    int moveDir;
    public bool grounded;
    [SerializeField] AudioClip JumpSound;
    [SerializeField] AudioClip LandSound;

    private void Awake()
    {
        Rigidbody= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Moving
        moveDir =(int)Input.GetAxisRaw("Horizontal"); //using Unity's inputs
       //smooth stopping
        if (moveDir != 0)
        {
            moveX = Mathf.MoveTowards(moveX, moveDir * moveSpeed, Time.deltaTime * acceleration);
        }
        
        else 
        {
            //smooth moving
            moveX = Mathf.MoveTowards(moveX, moveDir * moveSpeed, Time.deltaTime * acceleration * 2.0f);

            //Checking if anything in Ground Layer in Sphere area with radius of .2
            grounded = Physics.CheckSphere(groundCheck.transform.position, 0.2f, LayerMask.GetMask("Ground"));
        }
        //Jumping
        if (Input.GetButtonDown("Jump")&& grounded) //Jump only if on the ground
        {
            Jump();

        }
        
        //Jump Definition
        void Jump()
        {
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, jumpSpeed, 0);
            AudioBehavior.Instance.PlaySound(JumpSound, 1.0f);
        }
    }

    private void FixedUpdate()
    {
        if (Rigidbody.velocity.y < 0.75 * jumpSpeed || Input.GetButton("Jump"))
        {
            //jump snap for midjump and not pressing jump
            Rigidbody.velocity += Vector3.up * Physics.gravity.y * Time.fixedDeltaTime * 5.0f;
        }
            //moving
        Rigidbody.velocity = new Vector3(moveX, Rigidbody.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            
            AudioBehavior.Instance.PlaySound(LandSound, 1.0f);
        }
    }
}
