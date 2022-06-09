using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego2D {

    public class ArmaMiraDisparo : MonoBehaviour
    {
        public Transform contenedorARMA;

        public Transform puntoMira;
        public Transform refManoArma;

        bool tieneArma;

        void Start()
        {

        }

         
        void Update()
        {
           puntoMira.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            refManoArma.transform.position = puntoMira.transform.position;

            if (Input.GetButtonDown("Fire1"))
            {
                Dispara();
            }
        }

        private void Dispara()
        {
            RaycastHit2D HitG = Physics2D.Raycast(contenedorARMA.position, (puntoMira.position - contenedorARMA.position), 100f);

            if (HitG.collider.gameObject.CompareTag("Enemie"))
            {
                Destroy(HitG.collider.gameObject);
                Debug.Log("DESTRUIR AL CABRON");
            }

        }

        private void OnTriggerEnter2D(Collider2D cv)
        {
            if (cv.gameObject.CompareTag("arma"))
            {
                tieneArma = true;
                print("COGER PISTOLA");
                Destroy(cv.gameObject);
                contenedorARMA.gameObject.SetActive(true);

            }
        }
    }
    
}
