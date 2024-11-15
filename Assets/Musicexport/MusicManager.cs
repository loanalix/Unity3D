using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource; // R�f�rence � l'AudioSource

    void Start()
    {
        // Joue la musique au d�marrage
        musicSource.Play();
    }

    // M�thode pour changer le volume
    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // M�thode pour arr�ter la musique
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // M�thode pour d�marrer la musique
    public void PlayMusic()
    {
        musicSource.Play();
    }
}
