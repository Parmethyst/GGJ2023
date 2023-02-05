using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseGasHelper : MonoBehaviour
{

    public RoseBehaviour rose;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerControl player))
        {
            rose.levelObstacleBehaviour.OnHit.Invoke();
        }
    }
}
