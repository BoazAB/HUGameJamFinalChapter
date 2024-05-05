using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public KeyCode moveLeft;
    [SerializeField] public KeyCode moveRight;
    [SerializeField] public KeyCode jumpKey;


    [SerializeField] private float moveSpeed;

    private void Start()
    {
    }
    void Update()
    {
        float horizontalInput = 0f;
        if (Input.GetKey(moveLeft))
        {
            horizontalInput = -1f;
            Debug.Log("Left key pressed");

        }
        if (Input.GetKey(moveRight))
        {
            horizontalInput = 1f;
            Debug.Log("RIght key pressed");

        }

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Move the player sprite
        gameObject.transform.Translate(movement);
    }

}
