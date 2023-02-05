using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieSlideShow : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] private CanvasGroup[] pagesCanvasGroup;
    private int currentPage = 0;
    // Use this for initialization
    public void NextPage()
    {
        pagesCanvasGroup[currentPage].alpha = 0f;
        if (currentPage == pagesCanvasGroup.Length - 1)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else currentPage++;
        ShowCurrentPage();
    }

    public void PrevPage()
    {
        pagesCanvasGroup[currentPage].alpha = 0f;
        if (currentPage == 0)
        {
            currentPage = pagesCanvasGroup.Length - 1;
        }
        else currentPage--;
        ShowCurrentPage();
    }
    // public void ToggleInstruction()
    // {
    //     isInstructionVisible = !isInstructionVisible;
    //     CanvasGroupAlpha(isInstructionVisible);
    //     instructionCanvasGroup.interactable = isInstructionVisible;
    //     instructionCanvasGroup.blocksRaycasts = isInstructionVisible;
    //     ShowCurrentPage();
    // }
    // void CanvasGroupAlpha(bool visible)
    // {
    //     if (visible)
    //     {
    //         instructionCanvasGroup.alpha = 1f;
    //         currentPage = 0;
    //     }
    //     else
    //     {
    //         instructionCanvasGroup.alpha = 0f;
    //         pagesCanvasGroup[currentPage].alpha = 0f;
    //     }
    // }
    void ShowCurrentPage()
    {
        pagesCanvasGroup[currentPage].alpha = 1f;
    }
}
