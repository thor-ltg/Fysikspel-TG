using System.Linq;
using UnityEngine;

public class ParrotSpawnerScript : MonoBehaviour
{
    public GameObject[] shots;
    int NextShot = 0;
    public float throwStrength;
    bool IsDragging = false;
    public float maxSpeed;
    GameUIScript GameUI;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameUIScript>();
        GameUI.SetParrotsLeft(shots.Length);
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shots[NextShot].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && IsDragging && NextShot <= shots.Length)
        {
            IsDragging = false;
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = 0;

            Vector2 ThrowVelocity = (transform.position - MousePos) * throwStrength;
            if (ThrowVelocity.magnitude > maxSpeed)
            {
                ThrowVelocity = ThrowVelocity.normalized * maxSpeed;
            }

            GameObject Newparrot = Instantiate(shots[NextShot], transform.position, Quaternion.identity);
            NextShot++;
            Rigidbody2D rb = Newparrot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = ThrowVelocity;
            GameUI.SetParrotsLeft(shots.Length - NextShot);
            spriteRenderer.sprite = shots[NextShot].GetComponent<SpriteRenderer>().sprite;
        }
        if (IsDragging)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = transform.position.z;
            Vector2 DistanceFromMouse = (transform.position - MousePos);
            spriteRenderer.color = new Color((DistanceFromMouse.sqrMagnitude*0.1f)+1, (DistanceFromMouse.sqrMagnitude*0.1f)+1, (DistanceFromMouse.sqrMagnitude*0.1f)+1, 0.5f);
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        IsDragging = true;
    }
}
