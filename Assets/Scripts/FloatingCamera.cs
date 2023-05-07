using UnityEngine;

public class FloatingCamera : MonoBehaviour
{
    public float speed = 1f; // Adjust this value to control the speed of the camera's movement
    public float amplitude = 1f; // Adjust this value to control the height of the camera's movement
    public float frequency = 1f; // Adjust this value to control the frequency of the camera's movement

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        float verticalOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = originalPosition + Vector3.up * verticalOffset;
        //transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}