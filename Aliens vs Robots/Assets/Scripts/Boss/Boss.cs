using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float bulletForce = 8f;
    [SerializeField] private float lineOfSite = 8f;
    [SerializeField] private float shootingRange = 10f;

    [Header("References")]
    [SerializeField] GameObject firePoint;
    [SerializeField] Transform player;
    ObjectPooler pooler;

    [Header("Shooting Settings")]
    [SerializeField] float fireRate = 1f;
    [SerializeField] float nextFireRate;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        pooler = FindAnyObjectByType<ObjectPooler>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (distanceFromPlayer <= shootingRange && nextFireRate < Time.time)
        {
            GameObject enemyBullet = pooler.SpawnFromPools("BossBomb", firePoint.transform.position, Quaternion.identity);
            Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(-transform.right * bulletForce, ForceMode2D.Impulse);
            }
            nextFireRate = Time.time + fireRate;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}