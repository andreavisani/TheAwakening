using UnityEngine;
using UnityEngine.UIElements;
using System;

public class PlayerMovement : MonoBehaviour // Player movement class
{
    public float moveSpeed; // Movement speed of the player
    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    public LayerMask solidObjectsLayer; // Layer mask for solid objects
    public LayerMask Interactable; // Layer mask for interactable objects

    public Animator anim; // Reference to the Animator component
    private Vector2 moveDirection; // Direction of movement
    private Vector2 lastMoveDirection; // Last direction of movement

    public void HandleUpdate() // Handles input, movement, collisions, and animation
    {
        ProcessInputs(); // Processes input and sets moveDirection
        Move(); // Moves the player
        CheckCollisions(); // Checks for collisions
        Animate(); // Updates animation parameters

        if(Input.GetKeyDown(KeyCode.Z)){
            Interact(); // Interacts with objects
        }
    }

    void Interact() // Handles interaction with objects
    {
        var facingDir = new Vector3(anim.GetFloat("AnimLastMoveX"), anim.GetFloat("AnimLastMoveY"));
        var interactPos = transform.position + facingDir;
        // Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, Interactable);

        if(collider != null){
            var interactableComponent = collider.GetComponent<Interactable>();
            var jumpArtComponent = collider.GetComponent<JumpArt>();

            interactableComponent?.Interact();
            jumpArtComponent?.Interact(); // This will call performJumpscare in JumpArt
        }
    }

    void ProcessInputs() // Processes input and sets moveDirection
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && moveDirection.x!= 0 || moveDirection.y!= 0)
        {
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move() // Moves the player
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate() // Updates animation parameters
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);

        // Set the 2 variables for the last move
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }

    void CheckCollisions() // Checks for collisions
    {
        // Cast a ray in the direction of movement to check for collisions
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 0.2f, solidObjectsLayer | Interactable);

        // If the ray hits a solid object, stop the player
        if (hit.collider != null)
        {
            rb.velocity = Vector2.zero;
        }
    }


}