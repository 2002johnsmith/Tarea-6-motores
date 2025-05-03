using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSettings[] audioSettings;

    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioClip AudioClipChange;
    public static AudioManager Instance { get; private set; }

    private float[] _savedVolumes;
    private int _dataLength;
    private void Awake()
    {
        if (Instance != null&& Instance!=this)
        {
            Destroy(this.gameObject);
        }
        Instance=this;
        DontDestroyOnLoad(this.gameObject);
        _dataLength = audioSettings.Length;

        _savedVolumes = new float[_dataLength];
    }
    private void OnEnable()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
        InteractableObject.OnEnterPlayer += AudioSourceStop;
        InteractableObject.OnExitPlayer += AudioSourcePlay;
        InteractableObject.OnEnterPlayer += PlayAudioChange;
        InteractableObject.OnExitPlayer += PlayAudioChange;
    }
    private void OnDisable()
    {
        InteractableObject.OnEnterPlayer -= AudioSourceStop;
        InteractableObject.OnExitPlayer -= AudioSourcePlay;
        InteractableObject.OnEnterPlayer -= PlayAudioChange;
        InteractableObject.OnExitPlayer -= PlayAudioChange;

    }
    public void RevertChanges()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].UpdateVolume(_savedVolumes[i]);
        }
    }
    public void ApplyChange()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].SaveDataFile();

            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
    }
    public void AudioSourceStop()
    {
        audioSourceMusic.Stop();
    }
    public void AudioSourcePlay()
    {
        audioSourceMusic.Play();
    }
    public void PlayAudioChange()
    {
        audioSourceSFX.PlayOneShot(AudioClipChange);
    }
}