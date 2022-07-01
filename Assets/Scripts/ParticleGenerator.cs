using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ParticleGenerator : SingletonMonoBehaviour<ParticleGenerator>
{
    [SerializeField, TooltipAttribute("パーティクルのPrefab")]
    private GameObject particlePrefab;
    private ParticlePool particlePool;
    
    private void Start()
    {
        //オブジェクトプールを生成
        particlePool = new ParticlePool(transform, particlePrefab.GetComponent<ParticleObject>());
        
        //破棄されたときにPoolを解放する
        this.OnDestroyAsObservable().Subscribe(_ => particlePool.Dispose());
    }
    
    public void GenerateParticle(Vector3 position)
    { 
        //poolから1つ取得
        var effect = particlePool.Rent();
        
        //エフェクトを再生し、再生終了したらpoolに返却する
        effect.PlayEffect(position)
            .Subscribe(__ => { particlePool.Return(effect); });
    }
}
