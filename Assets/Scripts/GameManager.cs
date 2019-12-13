using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _goldText;
    private int totalGold = 0;
    void Start()
    {
        // _goldText.text = totalGold.ToString();
    }

    void Update()
    {

    }
    public void setGoldText(int gold)
    {
        totalGold += gold;
        _goldText.text = totalGold.ToString();
    }

}
