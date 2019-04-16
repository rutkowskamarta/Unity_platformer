using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSoundChanger : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private AudioSource musicTheme;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        musicTheme.volume = slider.value;
    }

    public void OnValueChanged()
    {
        musicTheme.volume = slider.value;
    }
}
