using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public Sound[] sounds;

	void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}
    //changing sound settings

    [Header("Sound Sliders")]
    [SerializeField]
    private Slider MasterLevel;

    [SerializeField]
    private Slider MusicLevel;

    [SerializeField]
    private Slider SFXLevel;

    private void Start()
    {
        //load previous audio settings
        LoadValues();
    }



    public void MasterVolumeSlider()
    {
        //save the currrent volume value
        float volume = MasterLevel.value;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        LoadValues();
    }

    public void MusicSlider()
    {
        //save the currrent volume value
        float music = MusicLevel.value;
        PlayerPrefs.SetFloat("Music", music);
        //get the level soundtrack
        AudioSource level = gameObject.GetComponent<AudioSource>();
        level.volume = music;//adjust the music level to the slider value
        LoadValues();
    }

    public void SFXSlider()
    {
        //save the currrent volume value
        float sfx = SFXLevel.value;
        foreach (Sound s in sounds)
        {   //change the volume level of each sound effect
            s.source.volume = SFXLevel.value;
        }
        PlayerPrefs.SetFloat("SFX", sfx);
        LoadValues();
    }

    void LoadValues()
    {

        float master = PlayerPrefs.GetFloat("MasterVolume");
        float sfx = PlayerPrefs.GetFloat("SFX");
        float music = PlayerPrefs.GetFloat("Music");
        MusicLevel.value = music;
        SFXLevel.value = sfx;
        MasterLevel.value = master;
        AudioListener.volume = master;//master volume
    }

}
