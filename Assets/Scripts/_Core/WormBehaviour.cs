using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormBehaviour : MonoBehaviour
{
    [SerializeField] bool isGoingLeft=false;
    [SerializeField] float wormSpeed=2f;
    [SerializeField] float wallSensingDistance=0.8f;
    [SerializeField] float floorSensingDistance=0.3f;
    [SerializeField] LayerMask wallLayers;
    [SerializeField] LevelObstacleBehaviour levelObstacleBehaviour;
    // Update is called once per frame
    void OnEnable() {
        levelObstacleBehaviour.OnHit+=OnPlayerHit;
    }
    void OnDisable() {
        levelObstacleBehaviour.OnHit-=OnPlayerHit;

    }
    void Update()
    {
        if(IsSensingWall()) {
            isGoingLeft=!isGoingLeft;
        }
        if(!IsSensingGround()) {
            isGoingLeft=!isGoingLeft;
        }
        if(isGoingLeft) transform.position+=new Vector3(Vector2.left.x*wormSpeed*Time.deltaTime,0f,0f);
        else transform.position+=new Vector3(Vector2.right.x*wormSpeed*Time.deltaTime,0f,0f);
    }
    public void OnPlayerHit() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private bool IsSensingWall() {
        RaycastHit2D raycastHitWall;
        if(isGoingLeft) raycastHitWall=Physics2D.Raycast(transform.position, Vector2.left, wallSensingDistance,wallLayers);
        else raycastHitWall=Physics2D.Raycast(transform.position, Vector2.right, wallSensingDistance,wallLayers);
        Color rayColor;
        if (raycastHitWall.collider != null)
        {
            rayColor = Color.green;
        }
        else rayColor=Color.red;
        if(isGoingLeft)Debug.DrawRay(transform.position, Vector2.left*wallSensingDistance , rayColor);
        else Debug.DrawRay(transform.position, Vector2.right*wallSensingDistance,rayColor);

        return raycastHitWall.collider!=null;
    }
    private bool IsSensingGround() {
        RaycastHit2D raycastHitFloor;
        raycastHitFloor=Physics2D.Raycast(transform.position, Vector2.down, floorSensingDistance,wallLayers);
        Color rayColor;
        if (raycastHitFloor.collider != null)
        {
            rayColor = Color.green;
        }
        else rayColor=Color.red;
        Debug.DrawRay(transform.position, Vector2.down*floorSensingDistance , rayColor);

        return raycastHitFloor.collider!=null;
    }
}
