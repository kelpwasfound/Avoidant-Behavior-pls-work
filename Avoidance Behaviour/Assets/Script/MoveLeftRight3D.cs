using UnityEngine;

public class MoveLeftRight3D : MonoBehaviour
{
    public float moveSpeed = 5f; // Units per second
    public bool moveRelativeToObject = false; // Move based on the object's local direction

    void Update()
    {
        // Get horizontal input (A/D or Left/Right Arrow)
        float moveX = Input.GetAxis("Horizontal");

        // Build a movement vector
        Vector3 move;

        if (moveRelativeToObject)
        {
            // Move along the object's local right/left direction
            move = transform.right * moveX;
        }
        else
        {
            // Move along the world X-axis
            move = Vector3.right * moveX;
        }

        // Apply the movement
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
