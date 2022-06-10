using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego2D {
    public class ThonyControles : MonoBehaviour
    {
        Rigidbody2D rb;
        Animator anim;

        public float fuerSalto = 5f;
        public float velCam = 5f;
        public Transform refPIE;

        public bool estaSuelo; public bool tieneArma;


        public Transform Arma; public Transform MIRA;
        public Transform refMANO; 

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }


        void Update()
        {
            float mvHor;
            mvHor = Input.GetAxis("Horizontal");
            anim.SetBool("isWalk", true);
            rb.velocity = new Vector2(mvHor * velCam, rb.velocity.y);

            estaSuelo = Physics2D.OverlapCircle(refPIE.position, 1f, 1 << 11);

            if (Input.GetKeyDown(KeyCode.Space) && estaSuelo)
            {
                Salto();
            }

            if (tieneArma)
            {
                MIRA.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                refMANO.transform.position = MIRA.transform.position;

            } 
            if (tieneArma)
            {
                if (MIRA.transform.position.x < transform.position.x) transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
                if (MIRA.transform.position.x > transform.position.x) transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else
            {
                if (mvHor < 0) transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
                if (mvHor > 0) transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            //Hacer un lookAT...  

            if (Input.GetButton("Fire1"))
            {
                RaycastHit2D higDis = Physics2D.Raycast(Arma.position, (MIRA.position - Arma.position), 100f);

                if (higDis.collider.gameObject.CompareTag("Enemie"))
                {
                    print("SU PUTA MADRE ASESINO");
                    Destroy(higDis.collider.gameObject); 
                }
            }
        } 
        public void Salto()
        {
            rb.AddForce(new Vector2(0, fuerSalto), ForceMode2D.Impulse);
        } 
         
        private void OnTriggerEnter2D(Collider2D arm)
        {
            if (arm.gameObject.CompareTag("arma"))
            {
                tieneArma = true;
                Destroy(arm.gameObject);
                Arma.gameObject.SetActive(true);
                print("COGER ARMA III");
            }
        }
    }
}
