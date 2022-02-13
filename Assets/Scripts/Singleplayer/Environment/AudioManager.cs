using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Important: keep sort order!
public enum SoundType
{
    Shot,
    Equip
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource _as;

    [SerializeField]
    private List<AudioClip> sounds = new List<AudioClip>();

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;

        Init();
    }

    private void Init()
    {
        _as = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundType type)
    {
        _as.clip = sounds[(int)type];
        _as.PlayOneShot(_as.clip);
    }
}
