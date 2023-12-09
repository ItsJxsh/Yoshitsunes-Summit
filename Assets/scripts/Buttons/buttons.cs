using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_control : MonoBehaviour
{
    public Slider soundSlider;
    public GameObject audioManager; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = audioManager.GetComponent<AudioSource>();

        soundSlider.value = audioSource.volume;

        soundSlider.onValueChanged.AddListener(OnSoundSliderChanged);
    }

  

    public void Retry()
    {
        SceneManager.LoadScene("TutorialStage");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void OnSoundSliderChanged(float volume)
    {
        audioSource.volume = volume;
    }

}
