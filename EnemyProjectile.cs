using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float speed = 10f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Attack()
    {
        GameManager.Instance.ReduceHealth(damage);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("Attack", 0, 1);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}

