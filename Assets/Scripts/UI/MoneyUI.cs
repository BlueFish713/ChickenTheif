using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text activeRateText;
    void Update()
    {
        moneyText.text = string.Format("{0}", SingletonManager.Get<MoneyManager>().balance);
        activeRateText.text = string.Format("{0}", SingletonManager.Get<MoneyManager>().activeRate);

    }
}
