using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehaviour : MonoBehaviour
{
    [SerializeField] bool isGoingLeft=false;
    [SerializeField] float wormSpeed=2f;
    [SerializeField] float wallSensingDistance=0.8f;
    [SerializeField] LayerMask wallLayers;
    // Update is called once per frame
    void Update()
    {
        if(IsSensingWall()) {
            isGoingLeft=!isGoingLeft;
        }
        if(isGoingLeft) transform.position+=new Vector3(Vector2.left.x*wormSpeed*Time.deltaTime,0f,0f);
        else transform.position+=new Vector3(Vector2.right.x*wormSpeed*Time.deltaTime,0f,0f);
    }
    private bool IsSensingWall() {
        RaycastHit2D raycastHit;
        if(isGoingLeft) raycastHit=Physics2D.Raycast(transform.position, Vector2.left, wallSensingDistance,wallLayers);
        else raycastHit=Physics2D.Raycast(transform.position, Vector2.right, wallSensingDistance,wallLayers);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else rayColor=Color.red;
        if(isGoingLeft)Debug.DrawRay(transform.position, Vector2.left*wallSensingDistance , rayColor);
        else Debug.DrawRay(transform.position, Vector2.right*wallSensingDistance,rayColor);

        return raycastHit.collider!=null;
    }
}
