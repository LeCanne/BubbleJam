using System.Collections;
using UnityEngine;

public abstract class LevelMaster : MonoBehaviour
{
    protected _FrogController frogController;
    public LevelMaster nextLevel;
    protected bool StarCollected;
    protected bool finishedLevel;
    public Collectable_recup Bonus;
    public GameObject LevelCamera;
    public Transform LevelStart, LevelEnd;
    public string levelName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
       

        
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(finishedLevel == true)
        {
            LevelEndProcess();
        }
    }

    public virtual void LevelEndProcess()
    {
        frogController.transform.position = Vector2.Lerp(frogController.transform.position, LevelEnd.transform.position, Time.deltaTime * 3);
    }
    public virtual void FinishLevel()
    {
       
        
        if(nextLevel != null)
        {
            StartCoroutine(NextLevel());
            Bonus.collected = false;
            
        }
        
       
    }

    public virtual void StartLevel()
    {
        frogController = SceneManager.Instance.player;
        frogController.levelMaster = this;
        frogController.rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(true);
        frogController.transform.position = LevelStart.position;
        LevelCamera.SetActive(true);    
       
    }

    public virtual void RestartLevel()
    {
        frogController.transform.position = LevelStart.position;
       

    }

    public virtual void ResetCollectable()
    {
        Bonus.collected = false;
    }

    IEnumerator NextLevel()
    {
        frogController.dead = true;
        finishedLevel = true;
        frogController.rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        SceneManager.Instance.userInterfaceManager.Win();
        yield return new WaitForSeconds(0.5f);
        nextLevel.StartLevel();
        frogController.dead = false;
        finishedLevel = false;
        LevelCamera.SetActive(false);
        gameObject.SetActive(false);
        yield return null;
       
    }
}
