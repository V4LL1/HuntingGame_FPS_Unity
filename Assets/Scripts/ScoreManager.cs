using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Necessário para carregar cenas

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Referência ao texto de pontuação na UI
    private int score = 0;  // Variável para armazenar a pontuação
    public int pointsToWin = 30;  // Pontuação necessária para vencer
    public string nextSceneName;  // Nome da cena a ser carregada

    void Start()
    {
        UpdateScoreText();  // Atualiza o texto no início do jogo
    }

    // Método para adicionar pontos
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        // Verifica se o jogador atingiu a pontuação necessária
        if (score >= pointsToWin)
        {
            LoadNextScene();
        }
    }

    // Atualiza o texto de pontuação na tela
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Carrega a próxima cena
    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);  // Carrega a cena definida
        }
        else
        {
            Debug.LogError("O nome da próxima cena não foi definido!");
        }
    }
}
