using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CPlayerFlying : MonoBehaviour {


    Rigidbody2D rb;

    [SerializeField]
    float jumpForce;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Flying"))

            Jump();
        
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
