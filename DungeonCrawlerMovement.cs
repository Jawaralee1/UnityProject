using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawlerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    public float projectileSpeed;
    public float shootTime;
    public float numBullets;
    private float timer;
    public List<GameObject> projectile;
    // Update is called once per frame
    void Update()
    {
        //movement
        rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movementSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -movementSpeed);
        }

        if (!(Input.GetKey(KeyCode.D)
        || Input.GetKey(KeyCode.A)
        || Input.GetKey(KeyCode.W)
        || Input.GetKey(KeyCode.S)))
        {
            rb.velocity = new Vector2(0, 0);
        }

        //camera tracking for shooting
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);

            for (int i = 0; i < numBullets; i++)
            {
                Vector2 direction = target - myPos + new Vector2(i, i);
                direction.Normalize();
                foreach (GameObject p in projectile)
                {
                    var b = Instantiate(p, myPos, Quaternion.identity);
                    b.GetComponent<Rigidbody2D>().velocity = (direction) * p.gameObject.GetComponent<ProjectileController>().getSpeed() * projectileSpeed;
                    Destroy(b, 2);
                }
            }
        }
        else if (timer > 0)
        {
            timer -= Time.deltaTime;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            GameManager.Instance.AddGems(1);
            Destroy(collision.gameObject);
        }
    }

    public void increaseBullets()
    {
        numBullets++;
    }
    public void increaseMovespeed()
    {
        movementSpeed += 2;
    }
    public void increaseBulletspeed()
    {
        projectileSpeed += .1f;
    }
    public void decreaseShootTime()
    {
        shootTime /= 1.05f;
    }
    public void addProjectile(GameObject p)
    {
        projectile.Add(p);
    }
}
