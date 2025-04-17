using UnityEngine;

public class EnemyPatrol : enemyAI
{
    public Transform[] patrolPoints;
    private int _currentPointIndex = 0;

    private void Start()
    {
        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[0].position;
        }
    }

    protected override void Move()
    {
        if (patrolPoints.Length == 0)
            return;

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[_currentPointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[_currentPointIndex].position) < 0.1f)
        {
            _currentPointIndex = (_currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
