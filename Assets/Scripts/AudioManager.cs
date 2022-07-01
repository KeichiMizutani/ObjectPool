using System.Linq;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    private AudioSource audioSourceForBGM;
    private AudioSource[] audioSourceForSEList = new AudioSource[20];

    private GameObject bgmGameObject;
    private GameObject seGameObject;

    [SerializeField, Range(0, 1)] private float volumeBGM = 0.3f;
    [SerializeField, Range(0, 1)] private float volumeSE = 0.3f;

    
    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(this.gameObject);
        
        SetAudioSourceForBGM();
        SetAudioSourceForSE();
    }
    
    private void SetAudioSourceForBGM()
    {
        bgmGameObject = new GameObject("BGM");
        bgmGameObject.transform.SetParent(this.transform, false);
        audioSourceForBGM = bgmGameObject.AddComponent<AudioSource>();

        audioSourceForBGM.volume = volumeBGM;
        audioSourceForBGM.loop = true;
    }
    
    private void SetAudioSourceForSE()
    {
        seGameObject = new GameObject("SE");
        seGameObject.transform.SetParent(this.transform, false);
        for (var i = 0; i < audioSourceForSEList.Length; ++i)
        {
            audioSourceForSEList[i] = seGameObject.AddComponent<AudioSource>();
            audioSourceForSEList[i].volume = volumeSE;
        }
    }
    
    private AudioSource GetUnusedAudioSource() => audioSourceForSEList.FirstOrDefault(a => a.isPlaying == false);

    public void Play(AudioClip clip)
    {
        audioSourceForBGM.clip = clip;
        audioSourceForBGM.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        AudioSource audioSource = GetUnusedAudioSource();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSourceが不足したため、再生できませんでした。");
            return;
        }

        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}
