using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    [SerializeField] float moveRadius; // Set the radius within which the monster can move
    [SerializeField] float moveSpeed; // Set the fixed movement speed

    Rigidbody2D rb;
    Transform target;

    Vector2 moveDirection;
    [SerializeField] float timeBetweenMovements; // Set the time between random movements
    private Vector2 centerPoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Set the initial center point to the current position
        centerPoint = transform.position;

        // Start invoking the MoveToRandomPosition method repeatedly with the specified time interval
        InvokeRepeating("MoveToRandomPosition", 0f, timeBetweenMovements);
    }

    void MoveToRandomPosition()
    {
        // Generate a random position within the specified radius
        Vector2 randomOffset = Random.insideUnitCircle * moveRadius;
        Vector2 randomPosition = centerPoint + randomOffset;

        // Move the monster to the random position with a fixed speed
        StartCoroutine(MoveToPosition(transform.position, randomPosition, moveSpeed));
    }

    IEnumerator MoveToPosition(Vector2 currentPos, Vector2 targetPos, float speed)
    {
        float t = 0f;
        float distance = Vector2.Distance(currentPos, targetPos);
        
        while (t < 1f)
        {
            t += Time.deltaTime * (speed / distance); // Adjusted speed based on distance
            transform.position = Vector2.Lerp(currentPos, targetPos, t);
            yield return null;
        }
    }
}
