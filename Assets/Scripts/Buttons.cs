using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private const int _mainMenuIndex = 0;
    private const int _settingsIndex = 1;
    private const int _instructionsIndex = 3;
    private const int _educate1Index = 4;
    private const int _learnMoreIndex = 37;
    private const int _firstQuestionIndex = 5;
    private const float _defaultGpa = 3.1f;
    private const float _defaultStress = 0.0f;


    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioManager>();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenuIndex);
        _audioManager.Selection();
    }

    public void LearnMore()
    {
        SceneManager.LoadScene(_learnMoreIndex);
        _audioManager.Selection();
    }

    public void Settings()
    {
        SceneManager.LoadScene(_settingsIndex);
        _audioManager.Selection();
    }

    public void Instructions()
    {
        SceneManager.LoadScene(_instructionsIndex);
        _audioManager.Selection();
    }

    public void MainEducation()
    {
        SceneManager.LoadScene(_educate1Index);
        _audioManager.Selection();
    }

    public void FirstQuestion()
    {
        SceneManager.LoadScene(_firstQuestionIndex);
        SetInitialValues();
        _audioManager.Selection();
    }

    private void SetInitialValues()
    {
        PlayerPrefs.SetFloat("Stress", _defaultStress);
        PlayerPrefs.SetFloat("GPA", _defaultGpa);
    }

    public void Advance(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
        _audioManager.Selection();
    }


}
