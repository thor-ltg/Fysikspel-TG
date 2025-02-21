using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ParrotSpawnerScript : MonoBehaviour
{
    public GameObject[] shots;
    int NextShot = 0;
    public float throwStrength;
    bool IsDragging = false;
    public float maxSpeed;
    public GameObject Arrow;
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
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
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
        if (IsDragging && shots.Length >= NextShot)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = transform.position.z;
            Vector3 DistanceFromMouse = (transform.position - MousePos);
            GameObject NewArrow;
            spriteRenderer.color = new Color((DistanceFromMouse.sqrMagnitude * 0.015f), (DistanceFromMouse.sqrMagnitude * 0.015f), (DistanceFromMouse.sqrMagnitude * 0.015f), 0.5f) + shots[NextShot].GetComponent<SpriteRenderer>().color;
            if (GameObject.FindGameObjectWithTag("Arrow") == null && Utility.ShowArrow)
            {
                NewArrow = Instantiate(Arrow, new Vector3(transform.position.x, transform.position.y)+DistanceFromMouse.normalized, Quaternion.identity);
            }
            NewArrow = GameObject.FindGameObjectWithTag("Arrow");
            NewArrow.transform.transform.localScale = new Vector3(math.clamp(DistanceFromMouse.sqrMagnitude+5, 5, 20), math.clamp(DistanceFromMouse.sqrMagnitude+5, 5, 20))/10;
            NewArrow.transform.position = transform.position + DistanceFromMouse.normalized * NewArrow.transform.transform.localScale.x*2;
            NewArrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0,  Mathf.Atan2(DistanceFromMouse.y, DistanceFromMouse.x)*Mathf.Rad2Deg-90));
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
