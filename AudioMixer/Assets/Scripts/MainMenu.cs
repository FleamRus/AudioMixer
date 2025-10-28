using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private AudioMixerGroup _mixerGroup;

    public void ToggleMasterMusic(bool enable)
    {
        if (enable)
            _mixerGroup.audioMixer.SetFloat("MasterVolume", 0);
        else
            _mixerGroup.audioMixer.SetFloat("MasterVolume", -80);
    }

    public void ChangeButtonVolume(float volume)
    {
        ChooseChannel("ButtonVolume", volume);
    }

    public void ChangeMainVolume(float volume)
    {
        ChooseChannel("MasterVolume", volume);
    }

    public void ChangeAmbientVolume(float volume)
    {
        ChooseChannel("MusicVolume", volume);
    }

    private void ChooseChannel(string name, float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        _mixerGroup.audioMixer.SetFloat(name, Mathf.Log10(volume) * 20);
    }
}
