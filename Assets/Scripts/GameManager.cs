using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _goldText, _damageText;
    [SerializeField] private GameObject _goldPrefab;
    [SerializeField] private Slider _healthBar;
    // public GameObject Hero;
    public int totalGold = 0;
    private AudioSource _goldSound;
    [SerializeField]
    private GameObject[] monsters;

    private bool _needSpawn = false;
    public int damage = 10;
    [SerializeField] private Transform _spawnPos;
    private void Start()
    {
        _goldSound = GetComponent<AudioSource>();
        SpawnMonster();
        UpdateDamageText(damage);
    }


    public void setGold(int gold)
    {
        totalGold += gold;
        GameObject goldObject = Instantiate(_goldPrefab, new Vector3(3.35f, -3.87f, 0), Quaternion.identity);
        StartCoroutine(UpdateGoldText());
        Destroy(goldObject, 1f);
    }
    public void setGold(){
        _goldText.text = totalGold.ToString();
    }
    IEnumerator UpdateGoldText()
    {
        yield return new WaitForSeconds(.7f);
        _goldText.text = totalGold.ToString();
        _goldSound.Play();
    }
    public void SpawnMonster()
    {
        int monsterIndex = Random.Range(0, monsters.Length);
        StartCoroutine(SpawnCorutine(monsters[monsterIndex]));
    }

    IEnumerator SpawnCorutine(GameObject monster)
    {
        yield return new WaitForSeconds(1);
        Instantiate(monster, _spawnPos.position, Quaternion.identity);

    }

    public void SetNeedSpawn()
    {
        _needSpawn = true;
    }

    public void InitializeHealthBar(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
    }

    public void ShowDamage(int d)
    {
        _healthBar.value -= d;
    }
    public void HealthBarTrigger(bool trigger)
    {
        _healthBar.gameObject.SetActive(trigger);
    }
    public void UpdateDamageText(int d)
    {
        _damageText.text = d.ToString();
    }

}
