using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumWins : MonoBehaviour
{
    public string winner;
    TextMesh winnerText;

    void Start () {
        winnerText = GetComponent<TextMesh>();
         
        if(winner== "Red"){
            winnerText.text= WinnerTrack.redWins.ToString();
        }

        if(winner== "Blue"){
            winnerText.text= WinnerTrack.blueWins.ToString();
        }

        if(winner== "Tie"){
            winnerText.text= WinnerTrack.tieWins.ToString();
        }
    }


}
