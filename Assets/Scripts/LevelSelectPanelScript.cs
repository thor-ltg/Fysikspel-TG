using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            NewButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Level {i}";
            if (Utility.LevelClearData.ContainsKey($"Level {i}") && Utility.LevelClearData[$"Level {i}"] == "Cleared")
            {
                NewButton.GetComponent<Image>().color = Color.green;
            }
            NewButton.GetComponent<ChangeSceneScript>().newLevel = $"Level {i}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
