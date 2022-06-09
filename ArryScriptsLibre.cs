
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


namespace miJuego2D
{
    public class ArryScriptsLibre : MonoBehaviour
    {
        public GameObject gOVER;
        //    int[] arayPrueba1 = { 2, 4, 0, 1, 5, 3 };
        //    string[] arayPrueba2 = { "a", "n", "t", "o", "n", "y" };

        //public int myHeard;
        //public int hearts;

        //public Image[] HEARDS;
        //public Sprite fullHEARD; public Sprite emptyHEARD;


        //void Update()
        //{
        //    SistemaVida();
        //    RestarVida();
        //}

        //public void SistemaVida()
        //{
        //    if(myHeard >= hearts)
        //    {
        //        myHeard = hearts;
        //    }
        //    if(myHeard <= 0)
        //    {
        //        myHeard = 0;
        //    }
        //    for(int i = 0; i>HEARDS.Length; i++)
        //    {
        //        if(i < myHeard)
        //        {
        //            HEARDS[i].sprite = fullHEARD;
        //        }
        //        else
        //        {
        //            HEARDS[i].sprite = emptyHEARD;

        //        }
        //        if(i< hearts)
        //        {
        //            HEARDS[i].enabled = true;
        //        }
        //        else
        //        {
        //            HEARDS[i].enabled = false;
        //        }
        //    }
        //}
        private void OnCollisionEnter2D(Collision2D cole)
        {
            if (cole.collider.tag == "Enemie")
            {
                HealtManager.Corazon--;

                if (HealtManager.Corazon <= 0)
                {
                    gOVER.SetActive(true);

                    

                }
                else
                {
                    StartCoroutine(RecibirDanho());
                    //StartCoroutine(GetHurt());
                    print("VOLVER AL MENU INICIAL");
                    Debug.Log(cole.collider.name);
                } 
            }
        } 
        IEnumerator RecibirDanho()
        {
            GetComponent<Animator>().SetLayerWeight(1, 1);
            yield return new WaitForSeconds(3.5f);
            GetComponent<Animator>().SetLayerWeight(1, 0);
        }
     }
}
