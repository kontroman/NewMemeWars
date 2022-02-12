using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { NONE = 0, ASSAULT = 1, PISTOL = 2 };

    [SerializeField] private float weaponDamage;
    [SerializeField] private float weaponFireRate;
    [SerializeField] private float weaponReloadTime;
    [SerializeField] private float weaponVelocity;
    [SerializeField] private float weaponReloadTimer;

    [SerializeField] private int weaponType;
    [SerializeField] private int weaponClipSize;
    [SerializeField] private int weaponMaxClipSize;
    [SerializeField] private int weaponAmmoInClip;
    [SerializeField] private int weaponMags;
    [SerializeField] private int weaponMaxMags;

    [SerializeField] private string weaponName;

    [SerializeField] private AudioSource weaponAudioSource;
    //или воспроизводить звуки через менеджер?
    [SerializeField] private AudioClip weaponAudioFireClip;
    [SerializeField] private AudioClip weaponAudioReloadClip;

    [SerializeField] private ParticleSystem muzzleFlash;

    private bool firing;

    public float timer;
    public bool weaponReloading;
    public bool weaponIsFiring;

    private void Awake()
    {
        weaponDamage = 10f;
        weaponFireRate = 0.1f;
        weaponReloadTime = 1.3f;
        weaponType = 1;
        weaponAmmoInClip = weaponMaxClipSize;
        weaponMags = weaponMaxMags;

        weaponAudioSource = GetComponent<AudioSource>();
    }

    public void InvokeFire()
    {
        firing = !firing;
    }

    private void Update()
    {
        FireWeapon();
        ReloadWeapon();
    }

    private void ReloadWeapon()
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
                    GameObject.Find("Canvas").GetComponent<GameCanvas>().UpdateAmmoText(weaponAmmoInClip);
                }
            }
        }
    }

    private void FireWeapon()
    {
        if (firing)
        {
            timer += Time.deltaTime;

            if (timer >= weaponFireRate && weaponAmmoInClip > 0)
            {
                weaponIsFiring = true;

                //TODO: make -ammo event

                weaponAmmoInClip -= 1;

                GameObject.Find("Canvas").GetComponent<GameCanvas>().UpdateAmmoText(weaponAmmoInClip);

                Ray weaponRay = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit weaponRayHit;

                weaponAudioSource.PlayOneShot(weaponAudioFireClip);
                muzzleFlash.Play();

                Debug.DrawRay(weaponRay.origin, weaponRay.direction * 200, Color.red, 0.2f);

                if (Physics.Raycast(weaponRay, out weaponRayHit, 200))
                {
                    DamagePopupCreator.Instance.CreateText(new Vector3(
                        weaponRayHit.transform.position.x,
                        weaponRayHit.transform.position.y,
                        weaponRayHit.transform.position.z
                        ));
                    Debug.Log("Попали");
                }

                timer = 0f;
            }

            weaponIsFiring = false;
        }
    }
}
