using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego2D
{
    public class VargaController : MonoBehaviour
    {
        Transform Varg;
        Animator anim;
        //Rigidbody2D rb2;
        
        bool movLeft;
        bool movRigth;

        public bool isGround; public bool isJump;

        public float velCam = 75f;public float jumForce = 3f;


        void Start()
        {
            Varg = this.transform;
            //rb2 = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        
        public void PointerDonwForward()
        {
            movLeft = true;
            anim.SetBool("isWalk", movLeft);
        }
        public void PointerUpForward()
        {
            movLeft = false;
            anim.SetBool("isWalk", false);
        }

        public void PointerDonwBackward()
        {
            movRigth = true;
        }
        public void PointerUpBackward()
        {
            movRigth = false;

        }
        public void PointerDonwJumping()
        {
            isJump = true;
            anim.SetBool("isJump", isJump);
        }
        public void PointerUpJumping()
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
        void FixedUpdate()
        {
            //RaycastHit2D sHit;
            //isGround = Physics2D.Raycast(Varg.position, Vector3.down, 0.5f);

            if (Physics2D.Raycast(Varg.position, Vector3.down, 0.5f))
            {
                isGround = true;
            }

            if (isGround)
            {
                if (isJump)
                {
                    Salto();
                }
            }

            if (movLeft)
            {
                CamDelante();
            }
            if (movRigth)
            {
                CamDetras();
            }
            if (isJump)
            {
                Salto();
            }
        }

        public void CamDelante()
        {
            Varg.transform.Translate(velCam, 0, 0);
            //rb2.velocity = new Vector2(velCam * Time.deltaTime,rb2.velocity.y);
        }
        public void CamDetras()
        {
           Varg.transform.Translate(-velCam, 0, 0);
             //rb2.velocity = new Vector2(-velCam * Time.deltaTime, rb2.velocity.y);
        }

        public void Salto()
        {
            Varg.transform.Translate(0, jumForce, 0);
            //rb2.AddForce(Vector2.up * jumForce);
        }

        
    }
}
