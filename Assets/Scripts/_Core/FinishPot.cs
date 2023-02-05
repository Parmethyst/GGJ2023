using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPot : MonoBehaviour
{
    [SerializeField] bool isFinalLevel;
    [SerializeField] string nextLevelScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerControl player))
        {
            if (isFinalLevel) SceneManager.LoadScene("_Ending");
            else SceneManager.LoadScene(nextLevelScene);
        }
    }
}
