using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int gems = 0;
    private int savedGems = 0;
    [SerializeField] int health = 100;
    public int maxHealth = 100;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public int GetGems()
    {
        return gems;
    }

    public void AddGems(int amount)
    {
        gems += amount;
    }

    public int GetHealth()
    {
        return (int) (((double) health / maxHealth) * 100);
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        health += amount;
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            maxHealth = 100;
            health = 100;
            gems = savedGems;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void SaveGems()
    {
        savedGems = gems;
    }
}
