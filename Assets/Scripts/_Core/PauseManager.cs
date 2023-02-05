using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] CanvasGroup pauseCanvas;
    [SerializeField] GameInput input;
    private bool isPaused = false;

    void OnEnable()
    {
        input.OnPauseInput += OnPause;
    }
    void OnDisable()
    {
        input.OnPauseInput -= OnPause;
    }
    public void OnPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseCanvas.alpha = 1f;
            pauseCanvas.interactable = true;
            pauseCanvas.blocksRaycasts = true;
        }
        else
        {
            Time.timeScale = 1f;
            pauseCanvas.alpha = 0f;
            pauseCanvas.interactable = false;
            pauseCanvas.blocksRaycasts = false;
        }

    }
}
