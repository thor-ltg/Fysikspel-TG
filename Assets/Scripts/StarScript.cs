using UnityEngine;

public class StarScript : MonoBehaviour
{
    GameUIScript GameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameUIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explode" || collision.tag == "Parrot")
        {
            Utility.StarsCollected++;
            GameUI.GetComponent<GameUIScript>().AddStar();
            Destroy(gameObject);
        }
    }
}
