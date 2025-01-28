using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerScript : MonoBehaviour
{
    public float WinDelay = 2;
    bool HasAlreadyWon;
    List<GameObject> enemies = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
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
    }
    void ReturnToLevelSelect()
    {
        HasAlreadyWon = false;
        SceneManager.LoadScene("Level Select");
    }
}