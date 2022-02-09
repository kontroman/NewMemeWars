using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public enum WeaponType { NONE = 0, ASSAULT = 1, PISTOL = 2 };

    [SerializeField] protected float weaponDamage;
    [SerializeField] protected float weaponFireRate;
    [SerializeField] protected float weaponReloadTime;
    [SerializeField] protected float weaponVelocity;
    [SerializeField] protected float weaponReloadTimer;

    [SerializeField] protected int weaponType;
    [SerializeField] protected int weaponClipSize;
    [SerializeField] protected int weaponMaxClipSize;
    [SerializeField] protected int weaponAmmoInClip;
    [SerializeField] protected int weaponMags;
    [SerializeField] protected int weaponMaxMags;

    [SerializeField] protected string weaponName;

    [SerializeField] protected AudioSource weaponAudioSource;
    //или воспроизводить звуки через менеджер?
    [SerializeField] protected AudioClip weaponAudioFireClip;
    [SerializeField] protected AudioClip weaponAudioReloadClip;

    [SerializeField] ParticleSystem muzzleFlash;

    public float timer;
    public bool weaponReloading;
    public bool weaponIsFiring;

    protected virtual void Awake()
    {
        weaponDamage = 10f;
        weaponFireRate = 0.1f;
        weaponReloadTime = 1.3f;
        weaponType = 1;
        weaponAmmoInClip = weaponMaxClipSize;
        weaponMags = weaponMaxMags;

        //Проинициализировать звуки
    }
    protected virtual void Update()
    {
        FireWeapon();
        ReloadWeapon();
    }

    protected virtual void ReloadWeapon()
    {
        if (weaponAmmoInClip <= 0)
        {
            if (weaponMags > 0)
            {
                if (!weaponReloading)
                    weaponAudioSource.PlayOneShot(weaponAudioReloadClip);

                weaponReloadTimer += Time.deltaTime;
                weaponReloading = true;

                if (weaponReloadTimer >= weaponReloadTime)
                {
                    weaponMags -= 1;
                    weaponAmmoInClip = weaponClipSize;
                    weaponReloading = !weaponReloading;
                    weaponReloadTimer = 0f;
                }
            }
        }
    }

    protected virtual void FireWeapon()
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;

            if (timer >= weaponFireRate && weaponAmmoInClip > 0)
            {
                weaponIsFiring = true;

                weaponAmmoInClip -= 1;

                Ray weaponRay = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit weaponRayHit;

                weaponAudioSource.PlayOneShot(weaponAudioFireClip);
                muzzleFlash.Play();

                Debug.DrawRay(weaponRay.origin, weaponRay.direction * 200, Color.red, 0.2f);

                if (Physics.Raycast(weaponRay, out weaponRayHit, 200))
                {
                    Debug.Log("Попали");
                }

                timer = 0f;
            }

            weaponIsFiring = false;
        }
    }
}
