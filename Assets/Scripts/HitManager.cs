using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    private Animator _anim;
    private HealthManager _hm;
    private GameManager _gameManager;
    public int damage = 10;
    private GameObject _hero;
    private Animator _heroAnim;

    private void Awake() {
// _hero = _gameManager.Hero;        
    }
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _anim = GetComponent<Animator>();
        _hm = GetComponent<HealthManager>();
        damage = _gameManager.damage; 
        _heroAnim = _heroAnim.GetComponent<Animator>();
    }

    void Update()
    {
    }
    private void OnMouseDown()
    {
        _anim.SetTrigger("Hit");
        _hm.GetHit(damage);
        // _heroAnim.SetTrigger("hit");
        
    }
}