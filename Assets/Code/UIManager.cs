using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameUI;
    public TMP_Text healthText;
    public TMP_Text scoreText;
    private int _health = 3;
    private int _score = 0;
    void Start()
    {

    }

    void Update()
    {

    }

    public void StartGame()
    {
        // gameUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void UpdateHealth(int value)
    {
        _health += value;
        healthText.text = "health " + _health;

    }

    public void UpdateScore(int value)
    {
        _health += value;
        healthText.text = "score " + _score;

    }
}
