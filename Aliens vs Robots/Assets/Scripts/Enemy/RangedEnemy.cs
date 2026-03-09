using System.Runtime.InteropServices;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Chasing Settings")]
    [SerializeField] private float enemySpeed = 5f;
    [SerializeField] private Transform point;
    [SerializeField] private Transform player;
    [SerializeField] private float rotationSpeed = 0.025f;
    [SerializeField] private float bulletSpeed = 10f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    ObjectPooler pooler;

    [Header("Distance for the Enemy to Shoot")]
    [SerializeField] private float distanceToShoot = 5f;
    [SerializeField] private float distanceToStop = 2f;

    [Header("Firing Rate for the Enemy")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float timer = 0;

    [Header("References for the bullet and Enemy")]
    [SerializeField] private Transform firePoint;

    void Awake()
    {
        timer = fireRate;
        point = GameObject.FindGameObjectWithTag("Point").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pooler = FindAnyObjectByType<ObjectPooler>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(timer < Time.time)
        {
            GameObject enemyBullet = pooler.SpawnFromPools("EnemyBullet",firePoint.position,firePoint.rotation);
            Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);
            timer = Time.time + fireRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position,point.position) >= distanceToStop)
        {
            rb.linearVelocity =  -transform.right * enemySpeed * Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}