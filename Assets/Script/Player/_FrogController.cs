using UnityEngine;
using UnityEngine.InputSystem;

public class _FrogController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool dead;

    public LevelMaster levelMaster; 

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
        if(dead) return;
        
        rb.linearVelocity += desiredVelocity * speed * Time.fixedDeltaTime;

        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }

    void Die()
    {
        dead = true;
        rb.linearVelocity = Vector2.zero;
        SceneManager.Instance.userInterfaceManager.Die();
        levelMaster.RestartLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dangerTag")
        {
            Die();
            
        }
    }

}
