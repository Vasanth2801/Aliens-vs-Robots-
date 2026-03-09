using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int currentHealth;
    EnemySpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
        spawner = FindAnyObjectByType<EnemySpawner>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            currentHealth = 0;
            spawner.waves[spawner.currentWave].enemiesCount--;
            Destroy(gameObject);
        }
    }
}