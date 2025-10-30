using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainVolumeSwitch : MonoBehaviour 
    {
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Toggle _toggle;

    private int _maxVolume = 0; 
    private int _minVolume = -80;
    private string _volumeOfMaster = "MasterVolume";
    private void Awake()
    {
        _toggle.onValueChanged.AddListener(ToggleMasterMusic);
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(ToggleMasterMusic);
    }

    public void ToggleMasterMusic(bool enable)
    {
        if (enable)
            _mixerGroup.audioMixer.SetFloat(_volumeOfMaster, _maxVolume);
        else
            _mixerGroup.audioMixer.SetFloat(_volumeOfMaster, _minVolume);
    }
}

