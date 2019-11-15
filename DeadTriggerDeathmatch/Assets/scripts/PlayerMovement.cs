using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject playerBody;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float DeadTime = .8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private float delay = .8f;
    private float DownTime;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        DownTime = delay;
        //StartCoroutine(KnockBack());
    }

    // Update is called once per frame
    void Update()
    {
        DownTime -= Time.deltaTime;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    //public IEnumerator KnockBack()
    //{
    //    playerBody.AddComponent<Rigidbody>();
    //    GetComponent<CharacterController>().enabled = false;
    //    yield return new WaitForSeconds(DeadTime);
    //    Destroy(GetComponent<Rigidbody>());
    //    GetComponent<CharacterController>().enabled = true;
    //}
}
