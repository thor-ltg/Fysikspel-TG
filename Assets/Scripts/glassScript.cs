using System.Collections;
using UnityEngine;

public class glassScript : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public SpriteRenderer childsr;
    public int hitsuntildestruction;
    public int hitsuntilcrack;
    public int timebetweenchecks = 3;
    public float maxacceleration;
    float lastvelocity;
    float acceleration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = (rb.linearVelocity.sqrMagnitude - lastvelocity) / Time.deltaTime;
        lastvelocity = rb.linearVelocity.sqrMagnitude;
        if (hitsuntildestruction == 0)
        {
            Destroy(gameObject);
        }
        if (hitsuntildestruction == hitsuntilcrack)
        {
            sr.sprite = childsr.sprite;
        }
        if (Mathf.Abs(acceleration) > maxacceleration)
        {
            hitsuntildestruction--;
        }
    }
}
