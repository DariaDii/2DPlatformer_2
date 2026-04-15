using UnityEngine;
using UnityEngine.UI;

public class PlayerUserInterface : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;
    [SerializeField] private Text _textValueCoins;
    [SerializeField] private Image _screenOfDeath;

    private void OnEnable()
    {
        _wallet.ValueChanged += OnValueChanged;
        _health.PlayerDie += ShowDeathSceen;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= OnValueChanged;
        _health.PlayerDie -= ShowDeathSceen;
    }

    private void OnValueChanged(float currentCoinAmount)
    {
        _textValueCoins.text = currentCoinAmount.ToString();
    }

    private void ShowDeathSceen()
    {
        _screenOfDeath.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}