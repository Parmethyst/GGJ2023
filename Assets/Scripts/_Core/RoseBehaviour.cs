using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
