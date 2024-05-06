using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public BorderStop stop;
    [SerializeField] public KeyCode moveLeft;
    [SerializeField] public KeyCode moveRight;
    [SerializeField] public KeyCode jumpKey;
    private bool canMove = true;

    public RectTransform borderRectTransform;
    public RectTransform borderLeft;
    public RectTransform borderRight;

    [SerializeField] private float moveSpeed;
    [HideInInspector] public float horizontalInput = 0f;

    void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            horizontalInput = -1f;
            Debug.Log("Left key pressed");

        }
        else if (Input.GetKey(moveRight))
        {
            horizontalInput = 1f;
            Debug.Log("RIght key pressed");

        }
        else
        {
            horizontalInput = 0f;
        }
        stop.WaitPlease();
        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        if (CheckBorderCollision(movement))
        {
            // Stop player movement
            canMove = false;
            return;
        }
        // Move the player sprite
        gameObject.transform.Translate(movement);
    }

    private bool CheckBorderCollision(Vector3 movement)
    {
        // Get the current position of the player
        Vector3 newPosition = transform.position + movement;

        // Check if the new position of the player is outside the border
        if (RectTransformUtility.RectangleContainsScreenPoint(borderRectTransform, newPosition))
        {
            return true; // Collision detected
        }
        return false; // No collision
    }
}
