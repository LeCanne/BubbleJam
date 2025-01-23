using UnityEngine;
using System.Collections;

public class LevelIntro : LevelMaster
{
    public GameObject quit;

    public override void Update()
    {
        if (finishedLevel == true)
        {
            frogController.transform.position = Vector2.Lerp(frogController.transform.position, quit.transform.position, Time.deltaTime * 3);
        }
    }
    
    public IEnumerator QuitLevel()
    {
        
        frogController.dead = true;
        finishedLevel = true;
        frogController.rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        SceneManager.Instance.userInterfaceManager.Win();
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
        Debug.Log("End");
        yield return null;
    }
}
