using UnityEngine;
using UniRx.Toolkit;

public class ParticlePool : ObjectPool<ParticleObject>
{
    private readonly ParticleObject _prefab;
    private readonly Transform _parentTransform;

    public ParticlePool(Transform transform, ParticleObject prefab)
    {
        _parentTransform = transform;
        _prefab = prefab;
    }

    /// <summary>
    /// オブジェクトの追加生成時に実行される
    /// </summary>
    /// <returns>DamageParticle</returns>
    protected override ParticleObject CreateInstance()
    {
        var e = Object.Instantiate(_prefab, _parentTransform, true);

        return e;
    }
}

