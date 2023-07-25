using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int EnemyCount;
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    public Transform SpawnPoint;
    private GameObject ChosenSpawn;
    private GameObject PickedEnemy;
    private float timer = 3f;


    void Update()
    {
        //if (EnemyCount < 5) { }
        
            if (timer < 0)
            {
                timer = 3f;
                SelectEnemy();
                EnemyCount++;
                Instantiate(ChosenSpawn, SpawnPoint.transform.position, Quaternion.identity);

            }
            else
            {
                timer -= Time.deltaTime;
            }
        
    }
    private void SelectEnemy()
    {
        int SelectedEnemy = Random.Range(1, 4);
        
        if (SelectedEnemy == 1)
        {
            PickedEnemy = Enemy1;
        }
        if (SelectedEnemy == 2)
        {
            PickedEnemy = Enemy2;
        }
        if (SelectedEnemy == 3)
        {
            PickedEnemy = Enemy3;
        }
        ChosenSpawn = PickedEnemy;
        //Vector2 myPos = new Vector2(SpawnPoint.position.x, SpawnPoint.transform.position.y);
        //GameObject Spawned = Instantiate(ChosenSpawn, myPos, Quaternion.identity);
    }
    void Awake()
    {

        EnemyCount = 0;
        timer = 3f;

    }

    // Update is called once per frame
    
}
