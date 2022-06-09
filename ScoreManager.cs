using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace miJuego2D
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        public Text scoreText; public Text highscoreText; public Text coconudscoreText;

        int score = 0; int highscore = 0; int coconud = 0;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            scoreText.text = score.ToString()/* + "PUNTOS"*/;
            highscoreText.text = "HIGHSCORE" + highscore.ToString();
            
            coconudscoreText.text = coconud.ToString();

        }

        public void AddPoint()
        {
            score += 1;
            scoreText.text = score.ToString() /*+ "PUNTOS"*/;
        }
        public void AddCoconut()
        {
            coconud++;
            coconudscoreText.text = coconud.ToString();
        }
        
    }
}
