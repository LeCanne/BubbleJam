using UnityEngine;
using UnityEngine.InputSystem;

public class _FrogController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool dead;

    Rigidbody2D rb;

    InputAction move;

    Vector2 desiredVelocity;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        MovementInput();
    }

    void MovementInput()
    {
        desiredVelocity = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Movement();


    }

    void Movement()
    {
        rb.linearVelocity += desiredVelocity * speed * Time.fixedDeltaTime;

        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }


}
