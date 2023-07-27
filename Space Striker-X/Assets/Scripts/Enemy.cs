using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Main enemy parameters")]
    [SerializeField] int EnemyHealth = 300;
    [SerializeField] int DestructionPoints = 15;
    [Header("Projectile configuration parameters")]

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots;
    [SerializeField] float maxTimeBetweenShots;
    [SerializeField] GameObject projectile;

    [SerializeField] float FiredLaserSpeed = 5f;
    [SerializeField] GameObject gun;

   [Header("Death VFX configuration parameters")]
    [SerializeField] GameObject VFXExplosion;
    [SerializeField] float explosionDelay = 2f;
    [Header("Sound SFX configuration parameters")]
    [SerializeField] AudioClip laserFireSFX;
    [SerializeField] AudioClip deathSFX;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    //Enemy hit processing code
    private void OnTriggerEnter(Collider otherObject)
    {
        
        if (otherObject.gameObject.GetComponent<DealDamage>() != null)
        {
            var DamagePoints = otherObject.gameObject.GetComponent<DealDamage>().getDamagePoints();
            EnemyHealth -= DamagePoints;
            Destroy(otherObject.gameObject);
            if (EnemyHealth <= 0)
            {
                if (gameSession != null) 
                {
                    gameSession.AddToScore(DestructionPoints);
                }
                
                DestructionState();
            }
        }
        else 
        {
            return;
        }
    }
    public void DestructionState(){
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        TriggerVFXExplosion();
        Destroy(gameObject);
    }
    private void TriggerVFXExplosion()
    {
        GameObject explosion = Instantiate(VFXExplosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, explosionDelay);
    }
    private void CountDownAndShoot()
    {
        //When shotCounter reaches zero, the Fire() method is trigerred
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
           Fire();            
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        //Code block for instantiating enemy laser
        GameObject firedLaser = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
         AudioSource.PlayClipAtPoint(laserFireSFX, Camera.main.transform.position);
        firedLaser.GetComponent<Rigidbody>().velocity += new Vector3(-FiredLaserSpeed, 0f);
        //AudioSource.PlayClipAtPoint(LaserEnemySound, Camera.main.transform.position, ProjectileVolume);

    }
    public int getEnemyHealth()
    {
        return EnemyHealth;
    }
}
