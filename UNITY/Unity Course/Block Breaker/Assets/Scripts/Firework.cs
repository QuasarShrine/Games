using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour {

    [Header("Firework options :")]
    [Tooltip("How many particle (Min and Max) should the firework have")]
    public short minParticlesToPitch = 10;
    public short maxParticlesToPitch = 300;

    [Tooltip("Shoot the firework every N seconds")]
    public float fireworksFrequency = 2;

    private ParticleSystem partSys;
    private AudioSource audioSource;

    private int nBburstedParticles;
    private ParticleSystem.EmissionModule emission;

    // Maximum and Minimum particles that can be set by the user (to calcul the pitch)
    //private int maxParticlesToPitch = 300;
    //private int minParticlesToPitch = 10;

    // max and min pitch. The bigger the firework is the lower the pitch should be
    // so for ex: 300 particles = 0.5f in pitch
    private float minPtich = 0.5f;
    private float maxPitch = 2f;

    void Awake() {
        partSys = GetComponent<ParticleSystem>();

        // setting user defined duration
        partSys.Stop();
        var main = partSys.main;
        main.duration = fireworksFrequency;
        partSys.Play();

        // init audio source
        audioSource = GetComponent<AudioSource>();

        // creation bursts emission on user defined values
        emission = partSys.emission;
        emission.enabled = true;
        emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0.0f, minParticlesToPitch, maxParticlesToPitch) });

        // Creating looping coll with user difend firework frequency
        InvokeRepeating("PlaySound", 0.001f, fireworksFrequency);
    }

    void PlaySound() {
        audioSource.pitch = TweakPitch();
        audioSource.Play();
    }

    float TweakPitch() {
        // tweak sound based on particles count so it's not too boring to hear

        nBburstedParticles = partSys.particleCount;

        // if maxParticlesToPitch -> 100% and minParticlesToPitch -> 0%
        // then to do the math minParticlesToPitch should be = 0.
        // so we decrease the two "max to pitch" variables like this to keep propotion :
        int intTo100PrctParticle = maxParticlesToPitch - minParticlesToPitch;

        // particle to percentage :
        float averageParticlesInPrct = 100 - (nBburstedParticles * 100 / intTo100PrctParticle);

        // percentage to pitch :
        float floatTo100PrctPitch = maxPitch - minPtich;

        float tweakPitch = (averageParticlesInPrct * floatTo100PrctPitch / 100) + minPtich;

        //print("for " + nBburstedParticles + " particles : ");
        //print("maxParticles = " + maxParticles);
        //print("minParticles = " + minParticles);
        //print("averageParticles = " + nBburstedParticles);
        //print("maxParticlesToPitch = " + maxParticlesToPitch);
        //print("minParticlesToPitch = " + minParticlesToPitch);
        //print("averageParticlesInPrct = " + averageParticlesInPrct);
        //print("maxPitch = " + maxPitch);
        //print("minPtich = " + minPtich);
        //print("floatTo100PrctPitch = " + floatTo100PrctPitch);
        //print("tweakPitch = " + tweakPitch);
        //print("===============================================");

        return tweakPitch;
    }
}
