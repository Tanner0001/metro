using UnityEngine;
public class CollectAble : MonoBehaviour 
{
    public int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) {
            FindObjectOfType<UIManager>().UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
}