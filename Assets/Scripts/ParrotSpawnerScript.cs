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
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
            spriteRenderer.sprite = shots[NextShot].GetComponent<SpriteRenderer>().sprite;
            spriteRenderer.color = shots[NextShot].GetComponent<SpriteRenderer>().color;
            GameUI.SetParrotsLeft(shots.Length - NextShot);
        }
        if (IsDragging)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = transform.position.z;
            Vector2 DistanceFromMouse = (transform.position - MousePos);
           spriteRenderer.color = new Color((DistanceFromMouse.sqrMagnitude*0.015f), (DistanceFromMouse.sqrMagnitude*0.015f), (DistanceFromMouse.sqrMagnitude*0.015f), 0.5f) + shots[NextShot].GetComponent<SpriteRenderer>().color;
        }
        if (NextShot == 0 && !IsDragging)
        {
            spriteRenderer.sprite = shots[NextShot].GetComponent<SpriteRenderer>().sprite;
            spriteRenderer.color = shots[NextShot].GetComponent<SpriteRenderer>().color;
            GameUI.SetParrotsLeft(shots.Length);
        }
        else if (!IsDragging && NextShot == shots.Length)
        {
            spriteRenderer.color = Color.white;
            GameUI.SetParrotsLeft(0);
        }
    }
    private void OnMouseDown()
    {
        IsDragging = true;
    }
}
