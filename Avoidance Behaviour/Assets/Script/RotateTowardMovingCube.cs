using UnityEngine;

public class RotateTowardMovingCube : MonoBehaviour
{
    public Transform targetCube;     // Assign your moving cube in the Inspector
    public float rotationSpeed = 10f;
    public LayerMask groundLayer;    // Assign your ground layer for raycast

    void Update()
    {
        // Create a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Draw the ray in the Scene view (for debugging)
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);

        // Check if the ray hits the ground
        if (Physics.Raycast(ray, out hit, 100f, groundLayer))
        {
            // Option 1: Rotate toward where the mouse hits the ground
            Vector3 lookPoint = hit.point;

            // Option 2: If you want to track a moving cube instead:
            if (targetCube != null)
                lookPoint = targetCube.position;

            // Get the direction (ignore vertical difference if desired)
            Vector3 direction = lookPoint - transform.position;
            direction.y = 0; // keep rotation level on Y axis

            // Rotate smoothly
            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // Optional: Draw line from object to target
            Debug.DrawLine(transform.position, lookPoint, Color.red);




        }
    }
}
