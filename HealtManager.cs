using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miJuego2D
{
    public class HealtManager : MonoBehaviour
    {
        public static int Corazon = 5;

        public Image[] corazones;

        public Sprite LLenocorazon;
        public Sprite Vaciocorazon;

        private void Awake()
        {
            Corazon = 5;
        }
        void Update()
        {
            foreach (Image img in corazones)
            {
                img.sprite = Vaciocorazon;
            }
            for (int i = 0; i < Corazon; i++)
            {
                corazones[i].sprite = LLenocorazon;
            }
        }

        
    }
 
}
