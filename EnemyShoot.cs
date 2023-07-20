using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float speed;
    public float shootTime;
    public float timer = 2f;
    public GameObject EnemyProjectile;
    private Vector2 lastV = Vector2.down;
    public Transform EnemyRanged;
    public Transform target;
    public GameObject Player;

    

    // Update is called once per frame
    void Update()
    {
 


        if (((EnemyRanged.transform.position - Player.transform.position).magnitude < 5.0f) && timer <= 0)        {
            timer = 2f;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = -(myPos - (Vector2)target.position);
            direction.Normalize();
            

            var b = Instantiate(EnemyProjectile, myPos, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = direction * speed;

            Destroy(b, 2);
        }
        else if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}