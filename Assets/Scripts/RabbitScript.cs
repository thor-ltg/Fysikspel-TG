using UnityEngine;

public class RabbitScript : MonoBehaviour
{
    bool rabbitshoot = false;
    public float rabbitshootspeed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !rabbitshoot)
        {
            transform.GetComponent<Rigidbody2D>().linearVelocityX = rabbitshootspeed;
            rabbitshoot = true;
        }
    }
}
