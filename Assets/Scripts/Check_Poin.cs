using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Poin : MonoBehaviour
{
       //Check_Pooint\\
    private Timer te;

    // Start is called before the first frame update
    void Start()
    {
        te = GameObject.FindGameObjectWithTag("Span").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("player"))
        {
            te.respawnpon = this.gameObject;
        }
    }
}
