using UnityEngine;

public abstract class LevelMaster : MonoBehaviour
{
    protected _FrogController frogController;
    public LevelMaster nextLevel;
    protected bool StarCollected;
    public GameObject Bonus;
    public GameObject LevelCamera;
    public Transform LevelStart, LevelEnd;
    public string levelName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
       

        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void FinishLevel()
    {
        LevelCamera.SetActive(false);
        if(nextLevel != null)
        {
            nextLevel.StartLevel();
            
        }
        
        gameObject.SetActive(false);
    }

    public virtual void StartLevel()
    {
        frogController = SceneManager.Instance.player;
        frogController.levelMaster = this;
        gameObject.SetActive(true);
        frogController.transform.position = LevelStart.position;
        LevelCamera.SetActive(true);    
       
    }

    public virtual void RestartLevel()
    {
        frogController.transform.position = LevelStart.position;
    }
}
