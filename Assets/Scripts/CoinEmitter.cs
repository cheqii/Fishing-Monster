using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinEmitter : MonoBehaviour
{
    [SerializeField] private GameObject coinCollect;

    private ParticleSystem pfx;

    private List<ParticleSystem.Particle> exitPfx = new List<ParticleSystem.Particle>();
    public List<ParticleSystem.Particle> ExitPfx => exitPfx;
    // Start is called before the first frame update
    void Start()
    {
        pfx = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnParticleTrigger()
    {
        pfx.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exitPfx);
        foreach (ParticleSystem.Particle p in exitPfx)
        {
            GameObject spawnObj = Instantiate(coinCollect);
            spawnObj.transform.position = transform.TransformPoint(p.position);
        }
    }
}
