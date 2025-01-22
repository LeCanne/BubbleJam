using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    public Animator deathAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        deathAnim.Play("DeathTransition");
    }
}
