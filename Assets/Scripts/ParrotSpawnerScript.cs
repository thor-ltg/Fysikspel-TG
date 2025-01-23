using UnityEngine;

public class ParrotSpawnerScript : MonoBehaviour
{
    public GameObject parrot;
    public float throwStrength;
    bool IsDragging = false;
    public float maxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && IsDragging)
        {
            IsDragging = false;
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = 0;

            Vector2 ThrowVelocity = (transform.position - MousePos) * throwStrength;
            if (ThrowVelocity.magnitude > maxSpeed)
            {
                ThrowVelocity = ThrowVelocity.normalized * maxSpeed;
            }

            GameObject Newparrot = Instantiate(parrot, transform.position, Quaternion.identity);
            Rigidbody2D rb = Newparrot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = ThrowVelocity;
        }
        if (IsDragging)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = transform.position.z;
            Vector2 DistanceFromMouse = (transform.position - MousePos);
            GetComponent<SpriteRenderer>().color = new Color((DistanceFromMouse.sqrMagnitude*0.1f)+1, (DistanceFromMouse.sqrMagnitude*0.1f)+1, (DistanceFromMouse.sqrMagnitude*0.1f)+1, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        IsDragging = true;
    }
}
