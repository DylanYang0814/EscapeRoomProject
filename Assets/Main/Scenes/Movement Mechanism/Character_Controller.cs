using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    Character_Input characterInput;
    Rigidbody mybody;

    public float speed;
    public float jumpForce;

    public Transform groundCheck;

    public bool isGrounded;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        characterInput = GetComponent<Character_Input>();
        mybody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(moveDirection);

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, 0.1f);

        if (Input.GetKeyDown (characterInput.jumpKey) && isGrounded)
        {
            canJump = !canJump;
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            mybody.AddForce(Vector3.up * jumpForce);
            canJump = !canJump;
        }
    }
} 