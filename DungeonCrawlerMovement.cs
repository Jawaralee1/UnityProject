using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonCrawlerMovement : MonoBehaviour
{
    public float speed;
    public float hp = 100;
    public float shootTime;
    private float timer;

    private Vector2 lastV = Vector2.down;
    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       //var anim = GetComponent<Animator>();
       //anim.SetFloat("Horizontal", v.x);
       //anim.SetFloat("Vertical", v.y);
        if(v.magnitude > 0)
        {
            lastV = v.normalized;
        }
        v.Normalize();
        GetComponent<Rigidbody2D>().velocity = v * speed;

        if(hp == 0)
        {
           
        }
        
       
        else if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
