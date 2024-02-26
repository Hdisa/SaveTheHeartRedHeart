using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject gameOverUI;

    private void OnEnable()
    {
        Health.PlayerIsDead += ShowGameOver;
    }

    private void Update()
    {
        RestartScene();
    }

    private void OnDisable()
    {
        Health.PlayerIsDead -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
