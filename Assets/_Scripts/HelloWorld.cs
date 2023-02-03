using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement=new Vector3();
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            movement.x=1f;
        }
        else movement.x=0f;
        transform.position+=movement*Time.deltaTime*5f;
    }
}
