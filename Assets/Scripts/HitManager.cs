using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    private Animator _anim;
    private HealthManager _hm;
    private GameManager _gameManager;
    public int damage = 10;

    private Hero _hero;


    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
        _hm = GetComponent<HealthManager>();
        _hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
    }

    void Update()
    {
    }
    private void OnMouseDown()
    {
        damage = _gameManager.damage;
        _anim.SetTrigger("Hit");
        _hm.GetHit(damage);
        _hero.Attack();
        Debug.Log("Damage frim hitManager"+ damage);


    }
}