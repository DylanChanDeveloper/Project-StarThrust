using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//need namespace tp access tmp componenets
public class ScoreBoard : MonoBehaviour
{
    int score;//we create a int to store the score
    TMP_Text scoreText;//referencing/ storing the variable to use

     void Start()
    {
        scoreText = GetComponent<TMP_Text>();//gets the TMP component and stores it in the scoretext variable.
        scoreText.text = "start";//changes the text to start.
        
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score = score + amountToIncrease;// score is equal to the amountToIncrease + the current score, the parameter value passed in is in the enemy script.
                                         //can be also written as score += amountToIncrease
        scoreText.text = score.ToString();//getting the scoretext variable and aceesing the text, then equaling the text the the score but converting the score number to a string.

    }

}
