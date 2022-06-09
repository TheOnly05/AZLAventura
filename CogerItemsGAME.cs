using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace miJuego2D {
public class CogerItemsGAME : MonoBehaviour
{
         public  GameObject gOVER;

        PasarLEVELScena LEVEL;

        private void Awake()
        {
            LEVEL = GameObject.Find("ScenaCambiar").GetComponent<PasarLEVELScena>();
        }

        private void Start()
        {
            gOVER.gameObject.SetActive(false);
  
        }

        private void Update()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "coin")
            {
                Debug.Log(coll.gameObject.tag);
                Destroy(coll.gameObject);
                print("SUMAR MONEDAS");

                ScoreManager.instance.AddPoint();


            }

            if (coll.gameObject.tag == "coco")
            {
                Debug.Log(coll.gameObject.tag);
                Destroy(coll.gameObject);
                print("SUMAR COCO");

                ScoreManager.instance.AddCoconut();
            }
            if (coll.gameObject.tag == "foudGround")
            {
                print("VOLVER AL MENU INICIAL");
                gOVER.gameObject.SetActive(true);
                LEVEL.NiveMenu();
            }
          
            if (coll.gameObject.tag == "NextLevel")
            {
                print("SIGUIENTE NIVEL");

                //LEVEL.CambiarLevel(0);
                LEVEL.DesbloquearNIVEL();
            } 
            
        }

    }

}
