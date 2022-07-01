using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestParticleUser : MonoBehaviour
{
    [SerializeField] private Vector3 randomPos = new Vector3(-4.0f, 3.0f, 4.0f);
    [SerializeField] private AudioClip clip;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            float rx = Random.Range(0.0f, 1.0f) * randomPos.x;
            float ry = Random.Range(0.0f, 1.0f) * randomPos.y;
            float rz = Random.Range(0.0f, 1.0f) * randomPos.z;

            ParticleGenerator.Instance.GenerateParticle(new Vector3(rx,ry,rz));
            
            AudioManager.Instance.PlayOneShot(clip);
        }
    }
}
