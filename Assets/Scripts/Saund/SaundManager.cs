using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SaundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private AudioSource m_gamePlaySource;

    // Клипы 
    //[SerializeField] private AudioClip m_mainMenu;
    [SerializeField] private AudioClip m_gamePlay;
    [SerializeField] private AudioClip m_gameOver;

    // Короткие звуки 
    [SerializeField] private AudioClip m_stickHit;
    [SerializeField] private AudioClip m_buttonClick;
    [SerializeField] private AudioClip[] m_stoneFall;

    public void SoundPlay(Sound type)
    {
        switch (type)
        {
            //case Sound.mainMenu:
            //    Play(m_mainMenu, true);
            //    break;
            case Sound.gamePlay:
                m_gamePlaySource.clip = m_gamePlay;
                m_gamePlaySource.loop = true;
                m_gamePlaySource.Play();
                break;
            case Sound.gameOver:
                Play(m_gameOver, false);
                break;
            case Sound.stickHit:
                Play(m_stickHit, false);
                break;
            case Sound.buttonClick:
                Play(m_buttonClick, false);
                break;
            case Sound.stoneFall:
                Play(RandomAudio(m_stoneFall), false);
                break;
        }
    }
    public void SoundStop(Sound type)
    {
        switch (type)
        {
            //case Sound.mainMenu:
            //    Stop(m_mainMenu);
            //    break;
            case Sound.gamePlay:           
                m_gamePlaySource.Stop();
                break;
            case Sound.gameOver:
                Stop(m_gameOver);
                break;
            case Sound.stickHit:
                Stop(m_stickHit);
                break;
            case Sound.buttonClick:
                Stop(m_buttonClick);
                break;
            case Sound.stoneFall:
                Stop(RandomAudio(m_stoneFall));
                break;
        }
    }

    private void Play(AudioClip audioClip, bool loop)
    {
        m_audioSource.clip = audioClip;
        m_audioSource.loop = loop;
        m_audioSource.Play();
    }

    private void Stop (AudioClip audioClip)
    {
        m_audioSource.clip = audioClip;
        m_audioSource.Stop();
    }
    private AudioClip RandomAudio(AudioClip[] audioClip)
    {
        int random = Random.Range(0, audioClip.Length);
        return audioClip[random];
    }
    
}
public enum Sound
{
    mainMenu,
    gamePlay, 
    gameOver, 
    stickHit, 
    buttonClick,
    stoneFall
}