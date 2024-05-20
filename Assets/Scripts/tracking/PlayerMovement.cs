using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Quaternion q;
    public bool manual;
    public bool with_ball = false;
    public string tagFilter;

    void Start()
    {
        with_ball = false;
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

        
        

        //transform.position = newPos;

        
    }

    private void OnTriggerEnter (Collider other) 
    {
        
    }

    public void setRotation(Quaternion quat)
    {
        Matrix4x4 mat = Matrix4x4.Rotate(quat);
        transform.localRotation = quat;
    }
}
