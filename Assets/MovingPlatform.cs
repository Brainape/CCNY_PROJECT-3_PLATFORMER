using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Distance to move to the left from the starting position
    public float leftDistance = 5f;
    // Distance to move to the right from the starting position
    public float rightDistance = 5f;
    // Speed at which the object moves
    public float speed = 2f;

    private Vector3 leftPoint;
    private Vector3 rightPoint;
    private bool movingRight = true;

    void Start()
    {
        // Calculate the left and right target positions based on the starting position
        leftPoint = transform.position - new Vector3(leftDistance, 0, 0);
        rightPoint = transform.position + new Vector3(rightDistance, 0, 0);
    }

    void Update()
    {
        if (movingRight)
        {
            // Move towards the right point
            transform.position = Vector3.MoveTowards(transform.position, rightPoint, speed * Time.deltaTime);
            // Check if the object has reached the right point
            if (Vector3.Distance(transform.position, rightPoint) < 0.1f)
            {
                movingRight = false;
            }
        }
        else
        {
            // Move towards the left point
            transform.position = Vector3.MoveTowards(transform.position, leftPoint, speed * Time.deltaTime);
            // Check if the object has reached the left point
            if (Vector3.Distance(transform.position, leftPoint) < 0.1f)
            {
                movingRight = true;
            }
        }
    }
}
