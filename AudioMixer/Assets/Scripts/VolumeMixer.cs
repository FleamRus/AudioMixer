using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public class SliderData
{
    public string VolumeParameter;
    public Slider Slider;

    [HideInInspector] public UnityEngine.Events.UnityAction<float> OnValueChangedAction;
}

public class VolumeMixer : MonoBehaviour
{
    private const float MuteDB = -80f;
    private const float MinVolume = 0.0001f;
    private const float MaxVolume = 1f;
    private const float AmplitudeRatio= 20f;

    [Header("Mixer Settings")]
    [SerializeField] private AudioMixerGroup _mixerGroup;

    [Header("Volume Sliders")]
    [SerializeField] private SliderData[] _sliders;

    private void Awake()
    {
        foreach (var slider in _sliders)
        {
            if (slider.Slider == null)
                continue;

            slider.OnValueChangedAction = (value) => ChangeVolume(slider.VolumeParameter, value);
            slider.Slider.onValueChanged.AddListener(slider.OnValueChangedAction);
        }
    }

    private void OnDestroy()
    {
        foreach (var slider in _sliders)
        {
            if (slider.Slider != null && slider.OnValueChangedAction != null)
                slider.Slider.onValueChanged.RemoveListener(slider.OnValueChangedAction);
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
