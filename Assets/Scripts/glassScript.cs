using UnityEngine;

public class glassScript : MonoBehaviour
{
    SpriteRenderer sr;
    public SpriteRenderer childsr;
    public int hitsuntildestruction;
    public int hitsuntilbreak;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitsuntildestruction == 0)
        {
            Destroy(gameObject);
        }
        if (hitsuntildestruction == hitsuntilbreak)
        {
            sr.sprite = childsr.sprite;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Parrot")
        {
            hitsuntildestruction--;
        }
    }
}
