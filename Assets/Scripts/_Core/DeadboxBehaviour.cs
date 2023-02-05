using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadboxBehaviour : MonoBehaviour
{
    [SerializeField] LevelObstacleBehaviour levelObstacleBehaviour;
    void OnEnable() {
        levelObstacleBehaviour.OnHit+=OnPlayerHit;
    }
    void OnDisable() {
        levelObstacleBehaviour.OnHit-=OnPlayerHit;
    }
    public void OnPlayerHit() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
