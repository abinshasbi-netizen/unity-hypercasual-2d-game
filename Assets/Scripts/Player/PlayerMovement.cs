using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpforce;
    private Rigidbody2D rb;
    private  Vector2  moveinput;
    private Vector2 worldpos;
    private float boardX;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float smoothspeed;





    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       
    }
    void OnMove(InputValue value) {

        moveinput=value.Get<Vector2>();
    
    }
    void Update()
    {
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(
    new Vector3(moveinput.x, 0, 0));

        boardX = Mathf.Clamp(worldpos.x, minX, maxX);

        Vector3 targetpos = new Vector3(boardX, transform.position.y, 0);

        transform.position = Vector3.Lerp(
            transform.position,
            targetpos,
            smoothspeed*Time.deltaTime

            );

    }


    
}
