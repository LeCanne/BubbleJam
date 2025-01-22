using Unity.VisualScripting;
using UnityEngine;

public class Collectable_recup : MonoBehaviour
{
    public bool collected;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == true)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 2);
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerTag")
        {
           
            player = collision.gameObject;
            collected = true;  

            }
    }
}
