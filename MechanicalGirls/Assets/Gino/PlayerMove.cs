using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    [SerializeField] public KeyCode moveLeft;
    [SerializeField] public KeyCode moveRight;
    [SerializeField] public KeyCode jumpKey;


    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(moveLeft))
        {
            movement.x = (transform.right * Time.deltaTime * -moveSpeed).x;
        }
        if (Input.GetKey(moveRight))
        {
            movement.x = (transform.right * Time.deltaTime * moveSpeed).x;

        }

        movement = movement + (Vector2)(transform.position);

        rb.MovePosition(movement);
    }

}
