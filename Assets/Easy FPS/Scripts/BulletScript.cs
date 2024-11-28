using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Tooltip("Furthest distance bullet will look for target")]
    public float maxDistance = 1000000;
    RaycastHit hit;
    [Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
    public GameObject decalHitWall;
    [Tooltip("Decal will need to be slightly in front of the wall to avoid rendering problems.")]
    public float floatInfrontOfWall;
    [Tooltip("Blood prefab particle this bullet will create upon hitting an enemy.")]
    public GameObject bloodEffect;
    [Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
    public LayerMask ignoreLayer;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
        {
            if (decalHitWall && hit.transform.CompareTag("LevelPart"))
            {
                Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
                Destroy(gameObject);
            }
            else if (bloodEffect && hit.transform.CompareTag("Tiger"))
            {
                // Cria o efeito de sangue
                Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));


                // Destrói o inimigo (Tigre)
                Destroy(hit.transform.gameObject);

                // Destroi a bala
                Destroy(gameObject);

                // Aumenta a pontuação
                FindObjectOfType<ScoreManager>().AddScore(10);  // Incrementa 10 pontos
            }
            else
            {
                // Destrói a bala caso não acerte nada relevante
                Destroy(gameObject);
            }
        }

        // Garante que a bala desapareça após 0.1 segundos
        Destroy(gameObject, 0.1f);
    }
}
