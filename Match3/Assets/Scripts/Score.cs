using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Score : MonoBehaviour
{
    public Text scoreText,scoreMultipliersText;
    public int scorePoints;
    public float Displayscore;
    public int ScoreMultipliers = 0;
    public int Multipliers
    {
        get { return ScoreMultipliers; }
        set 
        {
            ScoreMultipliers = value;
            if(ScoreMultipliers > 1)
            {
                scoreMultipliersText.GetComponent<DOTweenAnimation>().DOPlayForwardById("0");
                scoreMultipliersText.text = "X"+ScoreMultipliers.ToString();
            }
            else
            {
                scoreMultipliersText.GetComponent<DOTweenAnimation>().DOPlayBackwardsById("0");
            }
        }
    }

    private void Update() {
        Displayscore = Mathf.Lerp(Displayscore , scorePoints , 5*Time.deltaTime);
        scoreText.text = Displayscore.ToString("0");
    }

    public void AddScore(int points)
    {
        if(Multipliers != 0)
        {
            scorePoints += points * Multipliers;
        }
        else
        {
            scorePoints += points;
        }
    }
}
