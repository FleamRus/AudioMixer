using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    [Header("Mixer Settings")]
    [SerializeField] private AudioMixerGroup _mixerGroup;

    [Header("UI Sliders")]
    [SerializeField] private Slider _mainSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _buttonSlider;

    private void Awake()
    {
        if (_mainSlider)
            _mainSlider.onValueChanged.AddListener(value => ChangeVolume("MasterVolume", value));

        if (_musicSlider)
            _musicSlider.onValueChanged.AddListener(value => ChangeVolume("MusicVolume", value));

        if (_buttonSlider)
            _buttonSlider.onValueChanged.AddListener(value => ChangeVolume("ButtonVolume", value));
    }

    private void OnDestroy()
    {
        if (_mainSlider)
            _mainSlider.onValueChanged.RemoveAllListeners();

        if (_musicSlider)
            _musicSlider.onValueChanged.RemoveAllListeners();

        if (_buttonSlider)
            _buttonSlider.onValueChanged.RemoveAllListeners();
    }

    private void ChangeVolume(string name, float volume)
    {
        float minVolume = 0.0001f;
        float maxVolume =1f;
        int amplitudeRatio = 20;

        volume = Mathf.Clamp(volume, minVolume, maxVolume);
        _mixerGroup.audioMixer.SetFloat(name, Mathf.Log10(volume) * amplitudeRatio);
    }
}
