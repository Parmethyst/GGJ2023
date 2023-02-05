using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelObstacleBehaviour : MonoBehaviour
{
    public Action OnHit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerControl player))
        {
            OnHit?.Invoke();
        }
    }
}
