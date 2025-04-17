using UnityEngine;

public abstract class enemyAI : MonoBehaviour
{
    public float speed;
    public int health = 1;

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }

    protected abstract void Move();

    private void Update()
    {
        Move();
    }
}