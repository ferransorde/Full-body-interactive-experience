using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_winner : MonoBehaviour {
    public float timeValue; 
    TextMesh timerText;
    private string LevelToLoad;
    private int redpoints;
    private int bluepoints;
    

    void Start () {
        timerText = GetComponent<TextMesh>();
        int count1 = WinnerTrack.redWins;
        redpoints= count1;

        int count2 = WinnerTrack.blueWins;
        bluepoints= count2;

        
    }

    void Update()
    {
        if (timeValue> 0){
            timeValue-= Time.deltaTime;

        }
        else{
            timeValue=0;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay< 0){
            timeToDisplay=0;

            DisplayWinner();
            Application.LoadLevel(LevelToLoad);
        }else if(timeToDisplay>0){
            timeToDisplay+=1;
        }
        float minutes= Mathf.FloorToInt(timeToDisplay /60);
        float seconds= Mathf.FloorToInt(timeToDisplay %60);

        timerText.text= string.Format("{0:00}: {1:00}", minutes, seconds);

    
    }

    void DisplayWinner(){
        if((redpoints> bluepoints)){
            LevelToLoad= "WinnerEnding_RedPlayer";
            
        }else if(redpoints< bluepoints){
            LevelToLoad= "WinnerEnding_BluePlayer";
            
        }else if(redpoints== bluepoints){
            LevelToLoad= "WinnerEnding_Tie";
            
        }
        
    }
    
  
}

