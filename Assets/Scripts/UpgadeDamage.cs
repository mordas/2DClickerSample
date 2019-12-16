using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgadeDamage : MonoBehaviour
{
    public Text UpgradeCost, UpgradeDamage;
    [SerializeField] private GameObject _heroPref;
    public bool isHero = false;
    public int Damage = 10;
    public int Price = 100;
    public Image icon;
    [SerializeField] private GameObject _damageUpgradeAnimPref;
    [SerializeField] private GameManager _gameManager;
    [SerializeField]
    private bool rubyPrice = false;
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (!rubyPrice)
        {
            UpgradeCost.text = Price.ToString();
        }
        else
        {
            UpgradeCost.text = 1.ToString();
        }

        UpgradeDamage.text = Damage.ToString();

    }

    void Update()
    {

    }

    public void UpgadeClick()
    {
        int currentGold = _gameManager.totalGold;
        int currentDamage = _gameManager.damage;
        if (Price <= currentGold && !rubyPrice || _gameManager.rubies >= 1 && rubyPrice)
        {
            if (!isHero)
            {
                PlusDamage(currentGold, currentDamage);
            }
            else
            {
                PlusAlie(currentGold);
            }
        }
        else
        {
            Debug.Log("Not enough money");
        }



    }
    public void PlusDamage(int currentGold, int currentDamage)
    {
        if (!rubyPrice)
        {
            currentGold -= Price;
        }
        else
        {
            _gameManager.minusRuby();
        }
        currentDamage += Damage;
        _gameManager.UpdateDamageText(currentDamage);
        _gameManager.damage = currentDamage;
        _gameManager.totalGold = currentGold;
        _gameManager.setGold();
        GameObject damagePref = Instantiate(_damageUpgradeAnimPref) as GameObject;
        damagePref.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        damagePref.GetComponent<Image>().sprite = icon.sprite;
        Destroy(damagePref, .5f);
        Destroy(gameObject, 1f);
    }
    public void PlusAlie(int currentGold)
    {
        if (!rubyPrice)
        {
            currentGold -= Price;
        }
        else
        {
            _gameManager.minusRuby();
        }
        _gameManager.totalGold = currentGold;
        _gameManager.setGold();
        GameObject newHero = Instantiate(_heroPref, new Vector3(Random.Range(5f, 8f), -2.12f, 0), Quaternion.identity);
        Price *= 5;
        UpgradeCost.text = Price.ToString();
    }
}
