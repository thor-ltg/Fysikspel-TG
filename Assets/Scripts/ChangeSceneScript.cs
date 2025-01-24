using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public string newLevel = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(string NewScene)
    {
        SceneManager.LoadScene(NewScene);
    }
    public void ChangeSceneToSavedLevel()
    {
        SceneManager.LoadScene(newLevel);
    }
}
