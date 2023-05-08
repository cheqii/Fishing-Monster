using UnityEngine;
using Random = UnityEngine.Random;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float bombTimer = 0.1f;
    [SerializeField] private bool explosion = false;
    
    // Update is called once per frame
    void Update()
    {
        bombTimer -= Time.deltaTime;

        if (bombTimer < 0)
        {
            ExplosionReady();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(explosion == false) return;
        
        var _fish = col.gameObject;
        if (_fish.CompareTag("Fish"))
        {
            var _blood = Instantiate(GameManager.Instance.blood,
                _fish.GetComponent<Fish>().getCenter(),
                Quaternion.identity);
            Destroy(_fish.gameObject);
            _blood.GetComponent<ParticleSystem>().loop = false;
            GameManager.Instance.DestroyGO(_blood,10);
            
            var coin = Instantiate(GameManager.Instance.coinBurst, 
                _fish.GetComponent<Fish>().getCenter(), Quaternion.identity);
            GameManager.Instance.DestroyGO(coin,1);

        }
    }

    public void ExplosionReady()
    {
        explosion = true;
        var explosionParticle = Instantiate(  GameManager.Instance.explosion,this.transform.position, Quaternion.identity);
        GameManager.Instance.DestroyGO(explosionParticle,10f);

        GameManager.Instance.DestroyGO(transform.parent.gameObject,0.1f);
    }
}
