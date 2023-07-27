using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DitzeGames.MobileJoystick;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("Main Player ship configuration parameters")]
    [SerializeField] int Health = 400;
    [SerializeField] float speed = 2f;
    [SerializeField] float padding = 1f;    

    [Header("Player projectile configuration parameters")]
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] GameObject PlayerLaser;
    [SerializeField] float projectileFiringPeriod = 2f;
    [SerializeField] GameObject Gun;

    [Header("Player VFX configuration parameters")]

    [SerializeField] GameObject VFXExplosion;
    [SerializeField] float explosionDelay = 1f;

    [Header("Player SFX configuration parameters")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip laserFireSFX;
    [Header("Player game over scene configuration")]
    [SerializeField] float CountDownDelay = 3f;
     
    //Cached references
    Rigidbody rigidbody;
    
    float xMin, xMax, yMin, yMax;
    Coroutine firingCoroutine;

    //Cached mobile control references
    GameObject joyStickGUI;
    Joystick joystick;
    GameObject FireButton;
    ButtonState FireButtonState;
    int btnShootCounter = 1;
    
    LevelLoader level;
    private void Awake()
    {
        //Setuping joystick
        //joystick = FindObjectOfType<Joystick>();
        joyStickGUI = GameObject.FindGameObjectWithTag("joystick");
        joystick = joyStickGUI.GetComponent<Joystick>();
        FireButton = GameObject.FindGameObjectWithTag("FireBtn");
        FireButtonState = FireButton.GetComponent<ButtonState>();
    }
    private void Start()
    {
      rigidbody = GetComponent<Rigidbody>();
      level = FindObjectOfType<LevelLoader>();
    }
    void Update()
    {
        SetUpMoveBoundaries();
        playerMovement();
       // PlayerFire();
    }
    public int getHealth()
    {
        return Health;
    }
    private void OnTriggerEnter(Collider otherGameObject)
    {
        if (otherGameObject.gameObject.GetComponent<DealDamage>() != null)
        {
            HandleDamage(otherGameObject);
        }
        else if (otherGameObject.gameObject.tag == "Enemy")
        {
            otherGameObject.gameObject.GetComponent<Enemy>().DestructionState();
             DeathState();
             
        }
        else 
        {
            return;
        }
    }
    
    private void HandleDamage(Collider otherGameObject)
    {
        var DamagePoints = otherGameObject.gameObject.GetComponent<DealDamage>().getDamagePoints();
        Health -= DamagePoints;
        Destroy(otherGameObject.gameObject);
        if (Health <= 0)
        {
            DeathState();
             
        }
    }

    private void DeathState()
    {
        FireButton.SetActive(false);
        //joystick.enabled = false;
        joyStickGUI.SetActive(false);
        Health = 0;
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        TriggerVFXExplosion();
        Destroy(gameObject);
        level.LoadGameOverScene();
    }

    private void TriggerVFXExplosion()
    {
        GameObject explosion = Instantiate(VFXExplosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, explosionDelay);
    }

    public void PlayerFire()
    {
        StartCoroutine(Fire());
        /*Note: Firing is set in a diffrent setting
                When the player presses the button, ship fires */

       /* if (FireButtonState.Pressed())
        {
         firingCoroutine = StartCoroutine(Fire());
        }
         else if (!FireButtonState.Pressed())
         {
             if (firingCoroutine != null)
                StopCoroutine(firingCoroutine);
         }*/
       
        
        /* if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }*/
    }
     IEnumerator Fire()
    {
        //while(true)
       // { 
            GameObject laser = Instantiate(PlayerLaser, Gun.transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(laserFireSFX, Camera.main.transform.position);        
            laser.GetComponent<Rigidbody>().velocity +=  new Vector3(projectileSpeed, 0f, 0f);
            yield return new WaitForSeconds(projectileFiringPeriod);
       // }
    }
    private void playerMovement()
    {
        var posY = joystick.AxisNormalized.y * Time.deltaTime * speed;
        var posX = joystick.AxisNormalized.x * Time.deltaTime * speed;
        var newXPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
        rigidbody.velocity = new Vector3(posX, posY, 0f);

       
    }
     private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    
}
