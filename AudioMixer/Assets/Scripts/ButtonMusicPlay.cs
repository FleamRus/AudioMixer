using UnityEngine;

public class ButtonMusicPlay : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlayMusic(bool enable)
    {
        if (enable)
            audioSource.Play();
        else
            audioSource.Stop();
    }
}
