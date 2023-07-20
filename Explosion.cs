using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [SerializeField] float speed = 0;
    Rigidbody2D rb;
    public float timer = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            collision.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
