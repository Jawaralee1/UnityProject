using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPointShoot : MonoBehaviour
{
    public float speed;
    public float shootTime;
    private float timer;
    public GameObject projectile;
    private Vector2 lastV = Vector2.down;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(v.magnitude > 0)
        {
            lastV = v.normalized;
        }
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        v.Normalize();
        GetComponent<Rigidbody2D>().velocity = v * speed;
        
        
        if(Input.GetMouseButtonDown(0) && timer <= 0)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            
            var b = Instantiate(projectile, myPos, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().velocity = direction * speed;

            Destroy(b, 2);
        }
        else if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
