using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerScript : MonoBehaviour
{
    public float WinDelay = 2;
    bool HasAlreadyWon;
    List<GameObject> enemies = new List<GameObject>();
    GameUIScript GameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        GameUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameUIScript>();
        GameUI.SetEnemiesLeft(enemies.Count());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in enemies)
        {
            if (item == null)
            {
                enemies.Remove(item);
            }
        }
        if (enemies.Count == 0 && !HasAlreadyWon)
        {
            Invoke("ReturnToLevelSelect", WinDelay);
            HasAlreadyWon = true;
        }
        GameUI.SetEnemiesLeft(enemies.Count());
    }
    void ReturnToLevelSelect()
    {
        HasAlreadyWon = false;
        Utility.LevelClearData[SceneManager.GetActiveScene().name] = "Cleared";
        SceneManager.LoadScene("Level Select");
    }
}