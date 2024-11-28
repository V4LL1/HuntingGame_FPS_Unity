using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnPosition : MonoBehaviour
{
    public Transform player;  // Referência ao Player
    public Vector3 targetPosition;  // Posição específica para reiniciar o jogo
    public float range = 1f;  // Tolerância para considerar o player na posição exata

    void Update()
    {
        if (player != null)
        {
            // Verifica se o Player está dentro do alcance da posição alvo
            if (Vector3.Distance(player.position, targetPosition) <= range)
            {
                // Reinicia o jogo carregando a cena inicial
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
