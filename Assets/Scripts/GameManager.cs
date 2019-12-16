using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour

{
    [SerializeField] private GameObject _endGame;
    [SerializeField] private Text _bestScoreText;
    private int _bestScore;
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _goldText, _damageText;
    [SerializeField] private GameObject _goldPrefab;
    [SerializeField] private Slider _healthBar;
    // public GameObject Hero;
    public int totalGold = 0;
    public int rubies = 0;
    private AudioSource _goldSound;
    [SerializeField]
    private GameObject[] monsters;

    private bool _needSpawn = false;
    public int damage = 10;
    [SerializeField] private Transform _spawnPos;
    private int _monsterCount = 0;
    public GameObject rubyPref;
    [SerializeField]
    private Text _rubyText;
    [SerializeField] private int _gameDuration = 60;
    private int _currentTime = 0;
    private void Start()
    {
        Time.timeScale = 1;
        _goldSound = GetComponent<AudioSource>();
        SpawnMonster();
        UpdateDamageText(damage);
        InvokeRepeating("Timer", 0, 1.0f);
        _timerText.text = _gameDuration.ToString();
    }
    void Timer()
    {
        _currentTime++;
        int timeForText = _gameDuration - _currentTime;
        _timerText.text = timeForText.ToString();
        if (_currentTime >= _gameDuration)
        {
            Time.timeScale = 0;
            GameOver();
        }
    }


    public void setGold(int gold)
    {
        totalGold += gold;
        GameObject goldObject = Instantiate(_goldPrefab, new Vector3(3.35f, -3.87f, 0), Quaternion.identity);
        StartCoroutine(UpdateGoldText());
        Destroy(goldObject, 1f);
    }
    public void setGold()
    {
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
        _monsterCount++;
        int randomMaxValue = _monsterCount / 2 + 1;

        if (randomMaxValue >= monsters.Length)
        {
            randomMaxValue = monsters.Length;
        }
        int monsterIndex = Random.Range(0, randomMaxValue);
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
    public void SpawnRuby()
    {
        GameObject ruby = Instantiate(rubyPref, _spawnPos.position, Quaternion.identity);
        rubies++;
        UpdateRubyText();
        Destroy(ruby, 1f);
    }
    public void UpdateRubyText()
    {
        _rubyText.text = rubies.ToString();
    }
    public void minusRuby()
    {
        rubies--;
        UpdateRubyText();
    }

    public void GameOver()
    {
        _endGame.SetActive(true);
        _totalScoreText.text = totalGold.ToString();
        _bestScoreText.text = _bestScore.ToString();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }


}
