using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgadeDamage : MonoBehaviour
{
    public Text UpgradeCost, UpgradeDamage;
    public int Damage = 10;
    public int Price = 100;
    public Image icon;
    [SerializeField] private GameObject _damageUpgradeAnimPref;
    [SerializeField] private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        UpgradeCost.text = Price.ToString();
        UpgradeDamage.text = Damage.ToString();

    }

    void Update()
    {

    }

    public void UpgadeClick()
    {
        int currentGold = _gameManager.totalGold;
        int currentDamage = _gameManager.damage;
        if (Price <= currentGold)
        {
            currentGold -= Price;
            currentDamage += Damage;
            _gameManager.UpdateDamageText(currentDamage);
            _gameManager.damage = currentDamage;
            _gameManager.totalGold = currentGold;
            _gameManager.setGold();
            GameObject damagePref = Instantiate(_damageUpgradeAnimPref)as GameObject;
           damagePref.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
           damagePref.GetComponent<Image>().sprite = icon.sprite;
            Destroy(damagePref,.5f);

            Destroy(gameObject, 1f);
        }
        else
        {
            Debug.Log("Not enough money");
        }

    }
}
