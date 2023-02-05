using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI kalimatWaktuTextMesh;
     public Game_Manager gameManager;
     public float Timek =  10;
     float time = 0f;

     //Spawaan\\
    public GameObject Player;
    public  GameObject respawnpon;

    // Pause\\
    public GameObject flay;
    public GameObject fause;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        time = Timek;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        kalimatWaktuTextMesh.text = time.ToString("00")  ;
        if (time < 0)
        {
            Time.timeScale = 0;
        }

        //pause\\
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Time.timeScale = 0;
                flay.SetActive(false);
                fause.SetActive(true);           
        }
        
        //play\\
        if (Input.GetButtonDown("space"))
        {
           Time.timeScale = 1;
                flay.SetActive(true);
                fause.SetActive(false); 
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        flay.SetActive(true);
        fause.SetActive(false); 
    }

    public void Pause()
    {
            Time.timeScale = 0;
            flay.SetActive(false);
            fause.SetActive(true);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {             
   
        if (collision.gameObject.CompareTag("player"))
        {
            Player.transform.position = respawnpon.transform.position;
        }

          if (collision.tag == "enmy")
          {
             gameManager.GameOver();
          } 
    }

    
}
