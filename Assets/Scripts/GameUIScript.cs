using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIScript : MonoBehaviour
{
    GameObject ParrotsLeft;
    TextMeshProUGUI ParrotsLeftTMP;
    GameObject EnemiesLeft;
    TextMeshProUGUI EnemiesLeftTMP;
    GameObject StarContainer;
    GameObject EndScreenPanel;
    GameObject StarCollectedText;
    TextMeshProUGUI StarCollectedTextTMP;
    public GameObject StarImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ParrotsLeft = GameObject.FindGameObjectWithTag("ParrotText");       
        ParrotsLeftTMP = ParrotsLeft.GetComponent<TextMeshProUGUI>();
        EnemiesLeft = GameObject.FindGameObjectWithTag("EnemyText");
        EnemiesLeftTMP = EnemiesLeft.GetComponent<TextMeshProUGUI>();
        StarContainer = GameObject.FindGameObjectWithTag("StarContainer");
        EndScreenPanel = GameObject.FindGameObjectWithTag("EndScreenPanel");
        StarCollectedText = GameObject.FindGameObjectWithTag("StarsCollectedText");
        StarCollectedTextTMP = StarCollectedText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetParrotsLeft(int NumberOfParrots)
    {
        ParrotsLeftTMP.text = $"Parrots Left: {NumberOfParrots}";
    }
    public void SetEnemiesLeft(int NumberOfEnemies)
    {
        EnemiesLeftTMP.text = $"Enemies Left: {NumberOfEnemies}";
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToggleArrow()
    {
        Utility.ShowArrow = !Utility.ShowArrow;
    }
    public void AddStar()
    {
        GameObject Star = Instantiate(StarImage);
        Star.transform.parent = StarContainer.transform;
    }
    public void ShowEndScreen()
    {
        EndScreenPanel.transform.localScale = new Vector2(1, 1);
        StarCollectedTextTMP.text = $"Stars Collected: {Utility.StarsCollected}/{Utility.StarsTotal}";
    }
}
