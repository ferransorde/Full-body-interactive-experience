using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinnerPlayer : MonoBehaviour
{
    private int redpoints;
    private int bluepoints;
    public basket RedBasket;
    public basket2 BlueBasket;
    
    
    TextMesh Winner;
    // Start is called before the first frame update
    void Start()
    {
        int count1 = RedBasket.Count1;
        redpoints= count1;

        int count2 = BlueBasket.Count2;
        bluepoints= count2;
    
        Winner= GetComponent<TextMesh>();
    }

    void Update()
    {
        UpdateCount1();
        UpdateCount2();
        DisplayWinner();
    }
    void DisplayWinner(){
        if(redpoints> bluepoints){
            Winner.text= "Red Player";
        }else if(redpoints< bluepoints){
            Winner.text= "Blue Player";
        }else if(redpoints== bluepoints){
            Winner.text= "Tie!";
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
