using UnityEngine;
using UnityEngine.UI;

public class ButtonMusicPlay : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(PlayMusic); 
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(PlayMusic);
    }

    public void PlayMusic(bool enable)
    {
        if (enable)
            audioSource.Play();
        else
            audioSource.Stop();
    }
}
