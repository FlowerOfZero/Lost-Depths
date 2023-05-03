using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Reveal : MonoBehaviour
{
    public GameObject myExplosion;

    public ParticleSystem part;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        
        Debug.Log("Hit");
        
    }
}
