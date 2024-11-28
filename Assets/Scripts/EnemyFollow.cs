using UnityEngine;
using UnityEngine.SceneManagement;  // Para reiniciar a cena

public class EnemyFollow : MonoBehaviour
{
    public Transform player;  // Referência ao Transform do jogador
    public float speed = 5f;  // Velocidade do inimigo
    public float groundCheckDistance = 1f;  // Distância do Raycast para verificar o chão

    void Start()
    {
        // Encontra o jogador automaticamente pela tag "Player" se o campo não for configurado manualmente
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Direção para o jogador
            Vector3 direction = (player.position - transform.position).normalized;

            // Move em direção ao jogador
            transform.position += direction * speed * Time.deltaTime;

            // Rotaciona para olhar para o jogador
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            // Verifica a posição do tigre em relação ao chão
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
            {
                // Ajusta a posição vertical do tigre para garantir que ele não flutue
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o inimigo encostou no jogador
        if (other.CompareTag("Player"))
        {
            // Reinicia a cena atual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
