using System.Collections;
using UnityEngine;

public class glassScript : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public SpriteRenderer childsr;
    public int hitsuntildestruction;
    public int hitsuntilcrack;
    public float maxaccelerationx;
    public float maxaccelerationy;
    Vector2 lastvelocity;
    float accelerationY;
    float accelerationX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        accelerationX = (rb.linearVelocity.x - lastvelocity.x) / Time.deltaTime;
        accelerationY = (rb.linearVelocity.y - lastvelocity.y) / Time.deltaTime;
        lastvelocity = rb.linearVelocity;
        if (hitsuntildestruction == 0)
        {
            Destroy(gameObject);
        }
        if (hitsuntildestruction == hitsuntilcrack)
        {
            sr.sprite = childsr.sprite;
        }
        if (Mathf.Abs(accelerationX) > maxaccelerationx || Mathf.Abs(accelerationY) > maxaccelerationy)
        {
            hitsuntildestruction--;
        }
    }
}
