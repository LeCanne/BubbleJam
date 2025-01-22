using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class _FrogController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool dead;
    public GameObject bubble;

    public LevelMaster levelMaster; 

    public Rigidbody2D rb;
    Collider2D mainCollision;

    InputAction move;

    Vector2 desiredVelocity;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        mainCollision = GetComponent<Collider2D>();
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
        rb.gravityScale = 10;
        bubble.SetActive(false);
        mainCollision.enabled = false;
        StartCoroutine(DieAnim());

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dangerTag")
        {
            Die();
            
        }
    }


    IEnumerator DieAnim()
    {
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.Instance.userInterfaceManager.Die();
        yield return new WaitForSeconds(0.5f);
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        bubble.SetActive(true);
        levelMaster.RestartLevel();
        mainCollision.enabled = true;
        dead = false;
        yield return null;
    }
}
