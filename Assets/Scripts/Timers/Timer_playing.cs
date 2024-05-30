using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_playing : MonoBehaviour {
    public float timeValue = 120; 
    TextMesh timerText;
    private string LevelToLoad;
    private int redpoints;
    private int bluepoints;
    public basket RedBasket;
    public basket2 BlueBasket;

    void Start () {
        timerText = GetComponent<TextMesh>();
        int count1 = RedBasket.Count1;
        redpoints= count1;

        int count2 = BlueBasket.Count2;
        bluepoints= count2;
    }

    void Update()
    {
        UpdateCount1();
        UpdateCount2();
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
        if(redpoints> bluepoints){
            LevelToLoad= "Winner1_RedPlayer";
            WinnerTrack.redWins+=1;
        }else if(redpoints< bluepoints){
            LevelToLoad= "Winner1_BluePlayer";
            WinnerTrack.blueWins+=1;
        }else if(redpoints== bluepoints){
            LevelToLoad= "Winner1_Tie";
            WinnerTrack.tieWins+=1;
        }
        
    }
    
    void UpdateCount1()
    {
        int updatedCount1 = RedBasket.Count1; // Get the latest value
        redpoints= updatedCount1;
    }

    void UpdateCount2()
    {
        int updatedCount2 = BlueBasket.Count2; // Get the latest value
        bluepoints= updatedCount2;
    }
}
