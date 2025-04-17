using UnityEngine;

public class platformMoving : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    private int _currentPoint = 0;

    void Update()
    {

        if (points.Length == 0)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, points[_currentPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, points[_currentPoint].position) < 0.1f)
        {
            _currentPoint = (_currentPoint + 1) % points.Length;
        }

    }

}
