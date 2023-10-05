using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main_Economy_Script : MonoBehaviour
{
    public TextMeshProUGUI myMoneyScore;

    public int money;

    private void Update()
    {
        myMoneyScore.text = money.ToString();
        //Debug.Log(money + " my current Monney");
    }

    public void GainXAmountOfMoney(int GainMoney)
    {
        money += GainMoney;
    }
}
