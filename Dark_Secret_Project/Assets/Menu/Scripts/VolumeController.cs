using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Volume setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    private void Start()
    {
        LoadValues();
    }
    public void SetVolume(float volume)
    {
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply() // Confirmar att volymkontrollen sparas i spelet
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("MasterValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

}
