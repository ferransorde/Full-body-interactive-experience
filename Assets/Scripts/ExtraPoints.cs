using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPoints : MonoBehaviour
{
    public GameObject player3;
    public GameObject player4;

    private bool isPlayer3OnCube = false;
    private bool isPlayer4OnCube = false;

    private int countply3=0;
    private int countply4=0;

    //quan player entra al cube si isplayeroncube es false 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player3)
        {
            if (!isPlayer3OnCube && countply3==0) //per contar quan trepitja el cubo, ja que "entra", despres surt per fer el moviment i torna a entrar
            {
                isPlayer3OnCube = true;
                countply3+=1;
            }
            else //torna a ser isPlayer3OnCube quan entra pero com que ja ha entrat una vegada l'elimina
            {
                Destroy(gameObject);
            }
        }
        else if (other.gameObject == player4)
        {
            if (!isPlayer4OnCube && countply4==0)
            {
                isPlayer4OnCube = true;
                countply4+=1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player3)
        {
            isPlayer3OnCube = false;
        }
        else if (other.gameObject == player4)
        {
            isPlayer4OnCube = false;
        }
    }
}
