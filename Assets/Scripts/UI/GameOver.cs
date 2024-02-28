using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject gameOverUI;

    private void OnEnable()
    {
        EventBus.IsDead += ShowGameOver;
    }

    private void Update()
    {
        RestartScene();
    }

    private void OnDisable()
    {
        EventBus.IsDead -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameOverUI.activeInHierarchy)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
