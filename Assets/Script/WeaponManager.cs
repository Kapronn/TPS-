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
    private AimStateManager _aim;

    [SerializeField] private AudioClip gunShot;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _aim = GetComponentInParent<AimStateManager>();
        _fireRateTimer = fireRate;
    }

    void Update()
    {
        if (ShouldFire())
        {
            Fire();
        }
    }

    bool ShouldFire()
    {
        _fireRateTimer += Time.deltaTime;
        if (_fireRateTimer < fireRate) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        else return false;
    }

    void Fire()
    {
        _fireRateTimer = 0;
        barrelPosition.LookAt(_aim.aimPos);
        _audioSource.PlayOneShot(gunShot);
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bulletPrefab, barrelPosition.position, barrelPosition.rotation);
            Rigidbody rigidbody = currentBullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(barrelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}