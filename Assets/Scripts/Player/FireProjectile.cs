using Unity.VisualScripting;
using UnityEngine;

public class FireProjectile : MonoBehaviour

{
    public GameObject projectilePrefab;
    public Transform spawnTransform;
    public float force = 500;

    public GameObject gun;
    public AudioSource gunSounds;
    public ParticleSystem gunParticles;


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            // Gun sounds + particles (by Elliot)
            gunSounds.pitch = Random.Range(0.9f, 1.1f);
            gunSounds.PlayOneShot(gunSounds.clip);
            gunParticles.Emit(1);
            gun.transform.Rotate(0, 0, 20, Space.Self);
            GameObject newProjectile = Instantiate(projectilePrefab, spawnTransform.position, spawnTransform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(newProjectile.transform.forward * force);
        }
    }
}

