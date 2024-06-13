using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

public class Option : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown resolutionDropD;
    [SerializeField] private Toggle fullScreen;
    [SerializeField] private AudioMixer audioMixer; 
    private Resolution[] resolutions;
    private int actuelResID;

    private void Awake()
    {
        resolutionDropD.ClearOptions();
        resolutions = Screen.resolutions;

        List<String> labelRes = new List<String>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            labelRes.Add(resolutions[i].ToString());
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {actuelResID = i;}
        } 

        resolutionDropD.AddOptions(labelRes);

        resolutionDropD.value = actuelResID;
        fullScreen.isOn = Screen.fullScreen;
        audioMixer.GetFloat("Master", out float volume);
        volumeSlider.value = Mathf.InverseLerp(-80, 5f, volume);

        volumeSlider.onValueChanged.AddListener(VolumeModif);
        resolutionDropD.onValueChanged.AddListener(ResolutionModif);
        fullScreen.onValueChanged.AddListener(FullScreenToggle);
    }

    private void VolumeModif( float value)
    {
        print("Audio Volume : " + value);
        audioMixer.SetFloat("Master", Mathf.Lerp(-80, 5, value));
    }

    private void ResolutionModif(int value)
    {
        print("Résolution : " + value);
        actuelResID = value;
        Screen.SetResolution(resolutions[actuelResID].width, resolutions[actuelResID].height, Screen.fullScreen);
    }

    private void FullScreenToggle(bool value)
    {
        print("FullScreen : " + value);
        Screen.fullScreen = value;
    }
}
