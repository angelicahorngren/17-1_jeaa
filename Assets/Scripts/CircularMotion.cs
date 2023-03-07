using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float radius = 2f;
    [SerializeField] private Transform targetObject = null;

    private Vector3 center;
    private float angle = 150f;

    private void Start()
    {
        center = targetObject.position; // Set the center to be the position of the target object
        center.y = transform.position.y; // Keep the same y value as the starting position of this object
    }

    private void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Sin(angle) * radius;
        float y = transform.position.y;
        float z = Mathf.Cos(angle) * radius;

        transform.position = center + new Vector3(x, y, z);
        transform.rotation = Quaternion.LookRotation(center - transform.position);
    }
}
