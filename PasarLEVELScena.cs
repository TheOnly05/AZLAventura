using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace miJuego2D {

    public class PasarLEVELScena : MonoBehaviour
    {

        static public int nivelDesbloqueado;
        public int nivelActual;

        public Button[] botonesMENU;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == ("MENU"))
            {
                ActualizarBOTTONES();
            }
        }
        public void CambiarLevel(int nmrLevel)
        {
            if (nmrLevel == 0)
            {
                SceneManager.LoadScene("MENU");
            }
            else
            {
                SceneManager.LoadScene("NIVEL" + nmrLevel);

            }

        }

        public void DesbloquearNIVEL()
        {
            if (nivelDesbloqueado < nivelActual)
            {
                nivelDesbloqueado = nivelActual;
                nivelActual++;
            }
            NiveMenu();
        }
        public void NiveMenu()
        {
            CambiarLevel(0);
        }

        public void ActualizarBOTTONES()
        {
            for (int i = 0; i < nivelDesbloqueado + 1; i++)
            {
                botonesMENU[i].interactable = true;
            }
        }
    }
}
