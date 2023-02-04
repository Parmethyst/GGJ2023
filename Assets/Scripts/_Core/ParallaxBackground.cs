using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float repositionOffset=10f;
    [SerializeField] Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform=Camera.main.transform;
        lastCameraPosition=cameraTransform.position;   
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture=sprite.texture;
        textureUnitSizeX=texture.width/sprite.pixelsPerUnit;     
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement=cameraTransform.position-lastCameraPosition;
        transform.position+=new Vector3(deltaMovement.x*parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y,0f);
        lastCameraPosition=cameraTransform.position;
        if(cameraTransform.position.x - transform.position.x >= textureUnitSizeX - repositionOffset) {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position=new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        else if(cameraTransform.position.x - transform.position.x <= -textureUnitSizeX + repositionOffset) {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position=new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
