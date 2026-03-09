using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if(ph != null )
            {
                ph.TakeDamage(10);
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            
        }


        gameObject.SetActive(false);
    }
}