using System;
using UnityEngine;
using UniRx;


/// <summary>
/// エフェクトを再生して一定時間後に通知する
/// </summary>
public class ParticleObject : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
    }

    public IObservable<Unit> PlayEffect(Vector3 position)
    {
        transform.position = position;
        _particle.Play();

        return Observable.Timer(TimeSpan.FromSeconds(_particle.main.startLifetimeMultiplier)).ForEachAsync(_ => _particle.Stop());
    }
}
