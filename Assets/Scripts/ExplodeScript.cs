using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    public int hitsuntildestruction;
    public float maxaccelerationx;
    public float maxaccelerationy;
    public GameObject ParticleEmitterObject;
    Vector2 lastvelocity;
    float accelerationY;
    float accelerationX;
    bool explode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = rb.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        accelerationX = (rb.linearVelocity.x - lastvelocity.x) / Time.deltaTime;
        accelerationY = (rb.linearVelocity.y - lastvelocity.y) / Time.deltaTime;
        lastvelocity = rb.linearVelocity;
        if (hitsuntildestruction == 0)
        {
            ParticleEmitterObject.GetComponent<ParticleEmitterScript>().HasExploded = true;
            ParticleEmitterObject.transform.position = transform.position;
            circleCollider.enabled = true;
        }
        if (Mathf.Abs(accelerationX) > maxaccelerationx || Mathf.Abs(accelerationY) > maxaccelerationy)
        {
            hitsuntildestruction--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Parrot" || collision.tag == "Element" || collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}