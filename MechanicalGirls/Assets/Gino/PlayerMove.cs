using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float scalexLeft;
    public float scalexRight;
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
    public AnimationScript animationScript;
    public UnityEngine.UI.Image image;
    void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            horizontalInput = -1f;

        }
        else if (Input.GetKey(moveRight))
        {
            horizontalInput = 1f;
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
        StartCoroutine(waitForend());
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
    public IEnumerator<WaitForEndOfFrame> waitForend(){
        yield return new WaitForEndOfFrame();
        string animationtypename = (horizontalInput != 0 ? "Flying" : "Idle");
        if(animationtypename == "Flying"){
            if(horizontalInput == 1){
                transform.localScale = new Vector3(scalexRight, transform.localScale.y, transform.localScale.z);
            }
            else{
            transform.localScale = new Vector3(scalexLeft, transform.localScale.y, transform.localScale.z);
            }
        }
        animationScript.nextFrame(image ,animationtypename);
    }
}
