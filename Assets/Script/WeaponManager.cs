using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] private float fireRate;
    [SerializeField] private bool semiAuto;
    private float _fireRateTimer;

    [Header("Bullet properies")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrelPosition;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int bulletsPerShot;
    public int damage = 20;
    private AimStateManager _aim;

    [Header("Ammo Mangement")]
    public int clipSize = 30;
    public int extraAmmo = 120;
    public int currentAmmo;

    [Header("Weapon SFX")]
    [SerializeField] private AudioClip gunShot;
    private AudioSource _audioSource;

    [Header("Reload SFX")]
    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlidSound;

    [Header("Fire VFX")] 
    private ParticleSystem _muzzleFlashParticles;

    private ActionStateManager _actions;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _aim = GetComponentInParent<AimStateManager>();
        _actions = GetComponentInParent<ActionStateManager>();
        _muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        _fireRateTimer = fireRate;
        currentAmmo = clipSize;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) Reload();
        if (ShouldFire())
        {
            Fire();
            Debug.Log(currentAmmo);
        }
    }
    

    bool ShouldFire()
    {
        _fireRateTimer += Time.deltaTime;
        if (_fireRateTimer < fireRate) return false;
        if (currentAmmo == 0) return false;
        if (_actions.CurrentState == _actions.ReloadState) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        else return false;
    }

    void Fire()
    {
        _fireRateTimer = 0;
        barrelPosition.LookAt(_aim.aimPos);
        currentAmmo--;
        _audioSource.PlayOneShot(gunShot);
        _muzzleFlashParticles.Play();
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bulletPrefab, barrelPosition.position, barrelPosition.rotation);
            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.weapon = this;
            
            Rigidbody rigidbody = currentBullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(barrelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }
    }

    public void Reload()
    {
        if (extraAmmo > clipSize)
        {
            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = clipSize;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
    }
}