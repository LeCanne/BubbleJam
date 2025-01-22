using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public LevelMaster levelParams;
    AudioSource bubble_yipee;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubble_yipee = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "playerTag")
        {
            bubble_yipee.Play();
            levelParams.FinishLevel();
        }
    }
}
