using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float _maxValue = 100;
    public RectTransform valueRectTransform;
    //public Slider Healthbar;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;

    public float _currentValue;

    void Start()
    {
        //В начале игры задаем текущее здоровье максимальным значением
        _currentValue = _maxValue;
        UpdateHealthbar();
    }

    public bool isAlive()
    {
        return _currentValue > 0;
    }

    public void TakeDamage(float Damage)
    {
        //отнять урон от текущего значения здоровья
        _currentValue -= Damage;

        //проверить, что здоровья не осталось
        if (_currentValue <= 0)
        {
            PlayerIsDead();
        }

        UpdateHealthbar();
    }

    public void AddHealth(float amount)
    {
        _currentValue += amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);
        UpdateHealthbar();
    }   

    void UpdateHealthbar()
    {
        //обновить Healthbar.value текущим значением здоровья (от 0 до 1)
        //Healthbar.value = _currentValue/MaxValue;
        valueRectTransform.anchorMax = new Vector2(_currentValue / _maxValue, 1);
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("death");

    }
}
