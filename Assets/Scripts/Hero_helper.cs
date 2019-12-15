using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_helper : MonoBehaviour
{
    public int Damage  = 10;
    public GameObject FireballPefab;
    public float AttackSpeed = 2.0f;
    private Animator _anim;
    void Start()
    {
       StartCoroutine(SpawnFirebals(AttackSpeed)); 
       _anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    IEnumerator SpawnFirebals (float time){
        while(true){
            yield return new WaitForSeconds(time);
            _anim.SetTrigger("hit");
           GameObject fb = Instantiate(FireballPefab);
           fb.GetComponent<Fireball>().Damage = Damage;
           fb.transform.position = transform.position;
        }
    }
}

