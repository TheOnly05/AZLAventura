using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace miJuego2D
{

    [RequireComponent(typeof(Rigidbody2D), (typeof(CapsuleCollider2D)))]
    public class SCVController : MonoBehaviour
    {
        Transform yo;
        CapsuleCollider2D caps;
        Rigidbody2D rb;
        Animator anim2;

        

        public float jumpForce = 120f; public float speed = 3.5f;

        public bool isGround;

        float Horiz;
        void Start()
        {
            yo = this.transform;
            rb = GetComponent<Rigidbody2D>();
            caps = GetComponent<CapsuleCollider2D>();
            anim2 = GetComponent<Animator>();

        }
        void Update()
        {
            Debug.DrawRay(yo.position, Vector2.down, Color.blue);

            if (Physics2D.Raycast(yo.position, Vector2.down, .5f))
            {
                isGround = true;
            }

            Horiz = Input.GetAxisRaw("Horizontal");

            if (Horiz < 0.0f) yo.localScale = new Vector3(-.05f, .05f, .05f);
            else if (Horiz > 0.0f) yo.localScale = new Vector3(.05f, .05f, .05f);

            anim2.SetBool("isWalk", Horiz != 0.0f);

            if (Input.GetKeyDown(KeyCode.W) && isGround)
            {
                Jump();
            }
        }

        private void Jump()
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(Horiz, rb.velocity.y);
        }
       
        
    }
}
