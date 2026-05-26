using NUnit.Framework;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    
    public float parallaxFactor=0.5f;
    private Transform cameraTransform;
    private Vector3 lastPosition;
    private float spriteWidth;
    
    void Start()
    {
        cameraTransform=Camera.main.transform;
        lastPosition=cameraTransform.position;
        spriteWidth=GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    
    void LateUpdate()
    {
        Vector3 deltaMovement=cameraTransform.position - lastPosition;

        transform.position += new Vector3(

            deltaMovement.x * parallaxFactor,
            deltaMovement.y * parallaxFactor,
            0f

            );

        float camOffsetX = cameraTransform.position.x - transform.position.x;

        if (Mathf.Abs(camOffsetX) >= spriteWidth) {

            float offset = camOffsetX > 0 ? spriteWidth*2 : -spriteWidth*2;

            transform.position += new Vector3(offset,0f,0f);
        
        }

        lastPosition=cameraTransform.position;
        
    }
}
