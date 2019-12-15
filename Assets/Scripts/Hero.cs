using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private GameObject[] _attackPrefs;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attack()
    {
        _anim.SetTrigger("hit");
        int atackIndex = Random.Range(0, _attackPrefs.Length);
        GameObject atackSprite = Instantiate(_attackPrefs[atackIndex], new Vector3(-3.4f, -1.58f, -0.04f), Quaternion.identity);
        Destroy(atackSprite, 1f);
    }
}
