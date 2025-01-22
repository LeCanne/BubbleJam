using UnityEngine;

public class GameStart : MonoBehaviour
{
    public LevelMaster levelToStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelToStart.StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
