using UnityEngine;

public class ParticleEmitterScript : MonoBehaviour
{
    public bool HasExploded;
    ParticleSystem Particlesystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Particlesystem = GetComponent<ParticleSystem>();
        Particlesystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasExploded)
        {
            Particlesystem.Play();
            Invoke("EndParticles", 0.5f);
            HasExploded = false;
        }
    }
    void EndParticles()
    {
        Particlesystem.Stop();
        Invoke("DestroyEmitter", 0.5f);
    }
    void DestroyEmitter()
    {
        Destroy(gameObject);
    }
}
