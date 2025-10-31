using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolumeSwitch : MonoBehaviour
{
    private const int MinVolume = -80;
    private const string VolumeOfMaster = "MasterVolume";

    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Toggle _toggle;

    private float _previousVolume = 0f;

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(ToggleMasterMusic);

        SetCurrentVollume();
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMasterMusic);
    }

    public void ToggleMasterMusic(bool enable)
    {
        if (enable)
        {
            _mixerGroup.audioMixer.SetFloat(VolumeOfMaster, _previousVolume);
        }
        else
        {
            SetCurrentVollume();

            _mixerGroup.audioMixer.SetFloat(VolumeOfMaster, MinVolume);
        }
    }

    private void SetCurrentVollume()
    {
        if (_mixerGroup.audioMixer.GetFloat(VolumeOfMaster, out float currentVolume))
            _previousVolume = currentVolume;
    }
}

