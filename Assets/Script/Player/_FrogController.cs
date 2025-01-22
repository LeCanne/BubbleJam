using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class _FrogController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public bool dead;
    public GameObject bubble;
    public GameObject blow;
    private Animator animator;

    public LevelMaster levelMaster; 

    public Rigidbody2D rb;
    Collider2D mainCollision;

    InputAction move;

    Vector2 desiredVelocity;

    AudioSource bubble_fall;

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        mainCollision = GetComponent<Collider2D>();
        bubble_fall = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        MovementInput();
        bubble.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if(desiredVelocity != Vector2.zero)
        {
            blow.SetActive(true);
            animator.SetBool("moving", true);
            
            float angle = Mathf.Atan2(desiredVelocity.y, desiredVelocity.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward );

        }
        else
        {
            blow.SetActive(false);
            animator.SetBool("moving", false);
        }


        rb.linearVelocity += desiredVelocity * speed * Time.fixedDeltaTime;

        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }

    void Die()
    {
        bubble_fall.Play();
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
        levelMaster.ResetCollectable();
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
