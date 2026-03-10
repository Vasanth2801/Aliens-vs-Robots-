using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            gameOver.SetActive(true);
        }
    }
}
