using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Health = 100;
    public int tresure = 100;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _gameManager.InitializeHealthBar(MaxHealth);
        _gameManager.HealthBarTrigger(true);
    }

    void Update()
    {

    }
    public void GetHit(int damage)
    {
        int health = Health - damage;
        if (health <= 0)
        {
            Death();
        }
        Health = health;
        _gameManager.ShowDamage(damage);
    }
    public void Death()
    {
        Destroy(gameObject);
        _gameManager.setGold(tresure);
        _gameManager.SpawnMonster();
        _gameManager.HealthBarTrigger(false);
    }
}
