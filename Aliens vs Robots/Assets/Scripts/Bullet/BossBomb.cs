using UnityEngine;

public class BossBomb : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();

            if(ph != null)
            {
                ph.TakeDamage(80);
            }
        }

        gameObject.SetActive(false);
    }
}
