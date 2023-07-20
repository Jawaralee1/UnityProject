using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletIncreaseController : MonoBehaviour
{
    //make a new script that is called "item(itemname)Controller" with the itemname and then copy this script over for a template
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DungeonCrawlerMovement dcm = collision.gameObject.GetComponent<DungeonCrawlerMovement>();
            dcm.increaseBullets();


            Destroy(this.gameObject);
        }
    }
}
