using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public class SliderData
{
    public string volumeParameter;  
    public Slider slider;         
}

public class VolumeMixer : MonoBehaviour
{
    [Header("Mixer Settings")]
    [SerializeField] private AudioMixerGroup _mixerGroup;

    [Header("Volume Sliders")]
    [SerializeField] private SliderData[] _sliders;

    private const float MuteDB = -80f;
    private const float MinVolume = 0.0001f;
    private const float MaxVolume = 1f;
    private const float AmplitudeRatio = 20f;

    private void Awake()
    {
        foreach (var slider in _sliders)
        {
            if (slider.slider)
                slider.slider.onValueChanged.AddListener(value => ChangeVolume(slider.volumeParameter, value));
        }
    }

    private void OnDestroy()
    {
        foreach (var s in _sliders)
        {
            if (s.slider)
                s.slider.onValueChanged.RemoveAllListeners();
        }
    }

    private void ChangeVolume(string name, float volume)
    {
        volume = Mathf.Clamp(volume, MinVolume, MaxVolume);

        float dbValue = Mathf.Log10(volume) * AmplitudeRatio;
        if (volume <= MinVolume)
            dbValue = MuteDB;

        _mixerGroup.audioMixer.SetFloat(name, dbValue);
    }
}
