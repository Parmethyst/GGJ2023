using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI TextGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Tempat menaruh Object^2 yang dibutuhkan ketika gameOver\\
    public void GameOver()
    {
        TextGameOver.text = "GameOver";
        Time.timeScale = 0 ;
    }
}
