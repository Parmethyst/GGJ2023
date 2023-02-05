using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBehaviour : MonoBehaviour
{
    [SerializeField] float windStrength=1.5f;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(RandomLeafWind());
    }
    void Update()
    {
        transform.position+=new Vector3(windStrength,windStrength/2f,0)*Time.deltaTime;
    }
    IEnumerator RandomLeafWind() {
        while(true) {
            windStrength=Random.Range(-7.5f,1f);
            yield return new WaitForSeconds(4f);
        }
    }
}
