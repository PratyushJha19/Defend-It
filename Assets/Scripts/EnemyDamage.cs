using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int enemyHealth = 10;
    [SerializeField] int damage = 1;
    [SerializeField] ParticleSystem enemyDeathParticle;
    [SerializeField] ParticleSystem enemyHitParticle;
    public AudioClip damageSFX;
    public AudioClip deathSFX;
    AudioSource myAudioSource;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyHitParticle.Play();
        enemyHealth = enemyHealth - damage;
        myAudioSource.PlayOneShot(damageSFX);
        if (enemyHealth < 1)
        {
            var vfx = Instantiate(enemyDeathParticle, transform.position, Quaternion.identity);
            vfx.Play();
            Destroy(vfx.gameObject, 2.5f);
            AudioSource.PlayClipAtPoint(deathSFX, camera.transform.position);
            Destroy(gameObject);
        }
    }
}