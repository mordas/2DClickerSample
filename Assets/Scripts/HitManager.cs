using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    private Animator _anim;
    private HealthManager _hm;
    public int damage = 10;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _hm = GetComponent<HealthManager>();
    }

    void Update()
    {
    }
    private void OnMouseDown()
    {
        _anim.SetTrigger("Hit");
        _hm.GetHit(damage);
    }
}