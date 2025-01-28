using TMPro;
using UnityEngine;

public class LevelSelectPanelScript : MonoBehaviour
{
    public GameObject Button;
    public int NumberOfButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 1; i <= NumberOfButtons; i++)
        {
            GameObject NewButton = Instantiate(Button, transform);
            NewButton.GetComponent<ChangeSceneScript>().newLevel = $"Level {i}";
            NewButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Level {i}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
