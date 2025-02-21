using UnityEngine;

public class OwlScript : MonoBehaviour
{
    public float OwlJumpspeed = 7;
    public float OwlSpeed = 4;
    bool HasGrounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !HasGrounded)
        {
            transform.GetComponent<Rigidbody2D>().linearVelocityX += OwlSpeed;
            transform.GetComponent<Rigidbody2D>().linearVelocityY += OwlJumpspeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HasGrounded = true;
    }
}
