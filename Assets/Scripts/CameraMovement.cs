using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (target != null) return;

        Vector3 desiredPosition = new Vector3(
            target.position.x + offset.x,
            transform.position.y,
            offset.z

            );
        Vector3 smoothedPosition = Vector3.Lerp(

            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime

            );
        transform.position = smoothedPosition;

    }
}
