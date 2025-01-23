using UnityEngine;

public class ParrotSpawnerScript : MonoBehaviour
{
    public GameObject parrot;
    public Vector2 throwspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            GameObject Newparrot = Instantiate(parrot, newPosition, Quaternion.identity);
            Rigidbody2D rb = Newparrot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = throwspeed;
        }
    }
}
