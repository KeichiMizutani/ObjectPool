using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioUser : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private AudioClip seClip;

    private void Start()
    {
        AudioManager.Instance.Play(bgmClip);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlayOneShot(seClip);
        }
    }
}
