using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _monster;
    public int Damage { get; set; }
    void Start()
    {
        _monster = GameObject.FindObjectOfType<HealthManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_monster == null)
        {
            _monster = GameObject.FindObjectOfType<HealthManager>().gameObject;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _monster.transform.position, Time.deltaTime * 9.0f);
            if (Vector2.Distance(transform.position, _monster.transform.position) < 0.1f)
            {
                _monster.GetComponent<HealthManager>().GetHit(Damage);
                Destroy(gameObject);
            }
        }
    }
}