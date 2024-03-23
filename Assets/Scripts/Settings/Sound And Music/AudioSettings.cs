using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _soundMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;

    [SerializeField] private Toggle _soundMuteToggle;
    [SerializeField] private Toggle _musicMuteToggle;

    [SerializeField] private bool _soundMute;
    [SerializeField] private bool _musicMute;

    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    [SerializeField] private float _soundVolume;
    [SerializeField] private float _musicVolume;

    public void SoundMute(bool status)
    {
        if (status)
            _soundMixer.audioMixer.SetFloat("SoundVolume", -80f);
        else
            _soundMixer.audioMixer.SetFloat("SoundVolume", 0f);
        _soundMute = status;
        SaveSoundSettings();        
    }

    public void MusicMute(bool status) 
    {
        if (status)
            _musicMixer.audioMixer.SetFloat("MusiñVolume", -80f);
        else
            _musicMixer.audioMixer.SetFloat("MusiñVolume", 0f);
        _musicMute = status;
        SaveMusicSettings();        
    }

    public void SoundVolume(float volume)
    {
        _soundVolume = Mathf.Lerp(-80f, 0f, volume);
        if (!_soundMute)
            _soundMixer.audioMixer.SetFloat("SoundVolume", _soundVolume);
        SaveSoundSettings();
    }

    public void MusicVolume(float volume)
    {
        _musicVolume = Mathf.Lerp(-80f, 0f, volume);
        if (!_musicMute)
            _musicMixer.audioMixer.SetFloat("MusiñVolume", _musicVolume);
        SaveMusicSettings();
    }

    private void Start()
    {
        LoadMusicSettings();
        LoadSoundSettings();
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetInt("SoundMute", System.Convert.ToInt32(_soundMute));
        PlayerPrefs.SetFloat("SoundVolume", _soundVolume);
    }

    private void SaveMusicSettings()
    {        
        PlayerPrefs.SetInt("MusicMute", System.Convert.ToInt32(_musicMute));
        PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
    }    

    private void LoadSoundSettings()
    {
        if (PlayerPrefs.HasKey("SoundMute"))
        {
            _soundMute = System.Convert.ToBoolean(PlayerPrefs.GetInt("SoundMute"));
            SoundMute(_soundMute);
            _soundMuteToggle.isOn = _soundMute;
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            _soundVolume = PlayerPrefs.GetFloat("SoundVolume");
            _soundVolumeSlider.value = Mathf.Lerp(1f, 0f, _soundVolume);
            SoundVolume(Mathf.Lerp(1f, 0f, _soundVolume));
        }
    }

    private void LoadMusicSettings()
    {        
        if (PlayerPrefs.HasKey("MusicMute"))
        {
            _musicMute = System.Convert.ToBoolean(PlayerPrefs.GetInt("MusicMute"));
            MusicMute(_musicMute);
            _musicMuteToggle.isOn = _musicMute;            
        }
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            _musicVolume = PlayerPrefs.GetFloat("MusicVolume");            
            _musicVolumeSlider.value = Mathf.Lerp(1f, 0f, _musicVolume);
            MusicVolume(Mathf.Lerp(1f, 0f, _musicVolume));
        }
    }
}
