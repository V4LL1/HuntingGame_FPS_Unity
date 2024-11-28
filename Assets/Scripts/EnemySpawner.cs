using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab do inimigo
    public float spawnInterval = 3f;  // Tempo entre cada spawn (em segundos)

    void Start()
    {
        // Inicia o spawn automático com o tempo de 2 segundos
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    // Método para spawnar o inimigo
    void SpawnEnemy()
    {
        // Gera uma posição aleatória para X (0 a 30), Z (0 a 20), fixa para Y (0.56)
        float randomX = Random.Range(-15f, 30f);
        float randomZ = Random.Range(-10f, 40f); // Gera Z aleatório entre 0 e 20
        Vector3 spawnPosition = new Vector3(randomX, 0.56f, randomZ);

        // Instancia o inimigo na posição gerada
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
