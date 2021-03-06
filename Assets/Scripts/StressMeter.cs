using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StressMeter : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private Slider _stressMeter;

    private const float _stressIncrement = 1.0f;
    private const int _youLoseIndex = 2;

    private void Awake()
    {
        _stressMeter = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("Stress"))
        {
            _stressMeter.value = PlayerPrefs.GetFloat("Stress");
        }
        else
        {
            _stressMeter.value = 0;
        }

        _fill.color =_gradient.Evaluate(_stressMeter.normalizedValue);
    }

    public void SetMeterValue(int value)
    {
        _stressMeter.value = value;
        PlayerPrefs.SetFloat("Stress", _stressMeter.value);
    }

    public void AddStress(float stress)
    {
        _stressMeter.value += stress;
        PlayerPrefs.SetFloat("Stress", _stressMeter.value);
        _fill.color = _gradient.Evaluate(_stressMeter.normalizedValue);

        if (_stressMeter.value == _stressMeter.maxValue)
        {
            Debug.Log("Player stress is at maximum");
            SceneManager.LoadScene(_youLoseIndex);
        }
    }

    public void AddStress()
    {
        _stressMeter.value += _stressIncrement;
        PlayerPrefs.SetFloat("Stress", _stressMeter.value);
        _fill.color = _gradient.Evaluate(_stressMeter.normalizedValue);

        if (_stressMeter.value == _stressMeter.maxValue)
        {
            Debug.Log("Player stress is at maximum");
            SceneManager.LoadScene(_youLoseIndex);
        }
    }

    public void SubtractStress()
    {
        _stressMeter.value -= _stressIncrement;
        PlayerPrefs.SetFloat("Stress", _stressMeter.value);
        _fill.color = _gradient.Evaluate(_stressMeter.normalizedValue);
    }
}
