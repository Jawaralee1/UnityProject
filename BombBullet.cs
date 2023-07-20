using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject Explosion;
    Rigidbody2D rb;
    public float timer = 1f;

    GameObject explosionMade;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity * speed;
    }
    private void SpawnExplosion()
    {
        GameObject instance = Instantiate(Explosion, transform.position, Quaternion.identity);
        explosionMade = instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            collision.GetComponent<EnemyController>().TakeDamage(damage);
            SpawnExplosion();
            Destroy(explosionMade, 0.5f);
            explosionMade = null;
            Destroy(this.gameObject);


        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
