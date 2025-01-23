using UnityEngine;

public class QuitLevel : MonoBehaviour
{
    public LevelIntro levelParams;
    AudioSource bubble_yipee;
    public AudioSource theme;
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
        if (collision.tag == "playerTag")
        {
            theme.Stop();
            bubble_yipee.Play();
            levelParams.StartCoroutine(levelParams.QuitLevel());
        }
    }
}
