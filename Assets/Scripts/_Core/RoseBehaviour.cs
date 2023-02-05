using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoseBehaviour : MonoBehaviour
{
    [SerializeField] GameObject gasObject;
    public LevelObstacleBehaviour levelObstacleBehaviour;
    [SerializeField] Animator roseAnimator;

    void OnEnable() {
        levelObstacleBehaviour.OnHit+=OnPlayerHit;
    }
    void OnDisable() {
        levelObstacleBehaviour.OnHit-=OnPlayerHit;
    }

    public void OnPlayerHit() {
        gasObject.SetActive(false);
        roseAnimator.enabled=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
