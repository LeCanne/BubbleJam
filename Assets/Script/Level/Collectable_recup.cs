using Unity.VisualScripting;
using UnityEngine;

public class Collectable_recup : MonoBehaviour
{
    public bool collected;
    private GameObject player;
    AudioSource bubble_get;
    public bool sound_played;
    public Vector3 origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubble_get = GetComponent<AudioSource>();
        sound_played = true;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == true)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 2);
            
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, origin, Time.deltaTime * 10);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerTag")
        {
            if (sound_played == true)
            {
               bubble_get.Play();
            }
            sound_played = false;
            player = collision.gameObject;
            collected = true;  

            }
    }
}
