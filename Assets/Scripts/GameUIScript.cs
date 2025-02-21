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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ParrotsLeft = GameObject.FindGameObjectWithTag("ParrotText");       
        ParrotsLeftTMP = ParrotsLeft.GetComponent<TextMeshProUGUI>();
        EnemiesLeft = GameObject.FindGameObjectWithTag("EnemyText");
        EnemiesLeftTMP = EnemiesLeft.GetComponent<TextMeshProUGUI>();
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
}
