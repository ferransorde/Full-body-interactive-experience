using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeValue = 120; 
    TextMesh timerText;

    void Start () {
        timerText = GetComponent<TextMesh>();
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
            Destroy(gameObject);
        }else if(timeToDisplay>0){
            timeToDisplay+=1;
        }
        float minutes= Mathf.FloorToInt(timeToDisplay /60);
        float seconds= Mathf.FloorToInt(timeToDisplay %60);

        timerText.text= string.Format("{0:00}: {1:00}", minutes, seconds);

    
    }

}



