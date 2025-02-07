using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Camera cam;

    float currentZoom = 1;
    float targetZoom = 1;
    public float zoomFactor = 0.1f;

    public float zoomSpeed = 0.01f;

    public float minZoom = 1;
    public float maxZoom = 1.5f;

    float DefaultCamSize;
    void Start()
    {
        cam = GetComponent<Camera>();
        DefaultCamSize = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        targetZoom += Input.mouseScrollDelta.y * zoomFactor;

        if (targetZoom > maxZoom)
        {
            targetZoom = maxZoom;
        }
        if (targetZoom < minZoom)
        {
            targetZoom = minZoom;
        }

        currentZoom += (targetZoom - currentZoom) * zoomSpeed;

        cam.orthographicSize = DefaultCamSize * currentZoom;
    }
}
