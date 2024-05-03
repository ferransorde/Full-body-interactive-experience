using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Quaternion q;
    public bool manual;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPosition(Vector3 pos)
    {
        //swith playerIndex
        Vector3 newPos;
        transform.position = pos;

        switch(name){
            case "Player1":
                newPos = new Vector3(Mathf.Clamp(pos.x, 0, 50), pos.y, pos.z);
                break;
            case "Player2":
                newPos = new Vector3(Mathf.Clamp(pos.x, 50, 100), pos.y, pos.z);
                break;
            default:
                newPos = pos;
                break;
        }

        transform.position = newPos;

        
    }

    public void setRotation(Quaternion quat)
    {
        Matrix4x4 mat = Matrix4x4.Rotate(quat);
        transform.localRotation = quat;
    }
}
