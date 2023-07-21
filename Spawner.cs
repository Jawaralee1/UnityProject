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
    private float timer = 10f;


    void Update()
    {
        
    }
    private void SelectEnemy()
    {
        int SelectedEnemy = Random.Range(1, 3);
        
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
        GameObject ChosenSpawn = PickedEnemy;
        Vector2 myPos = new Vector2(SpawnPoint.position.x, SpawnPoint.transform.position.y);
        GameObject Spawned = Instantiate(ChosenSpawn, myPos, Quaternion.identity);
    }
    void Start()
    {

        EnemyCount = 0;
        while (EnemyCount < 5)
        {
            if (timer  == 0)
            {
                timer = 10f;
                SelectEnemy();
                EnemyCount = EnemyCount + 1;
                
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

    }

    // Update is called once per frame
    
}
