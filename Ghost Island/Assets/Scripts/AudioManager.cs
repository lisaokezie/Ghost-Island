using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip EnergyAudio;
    AudioSource Energy;
    public AudioClip ItemAudio;
    AudioSource Item;
    public AudioClip ShootAudio;
    AudioSource Shoot;
    public AudioClip EnemyAudio;
    AudioSource Enemy;
    public AudioClip WeaponAudio;
    AudioSource Weapon;
    public AudioClip GameOverAudio;
    AudioSource GameOver;
    public AudioClip WinMusicAudio;
    AudioSource WinMusic;
    public AudioClip ReloadAudio;
    AudioSource Reload;
    public AudioClip DamageAudio;
    AudioSource Damage;

    void Start()
    {
        Energy = GetComponent<AudioSource>();
        Item = GetComponent<AudioSource>();
        Shoot = GetComponent<AudioSource>();
        Enemy = GetComponent<AudioSource>();
        Weapon = GetComponent<AudioSource>();
        GameOver = GetComponent<AudioSource>();
        WinMusic = GetComponent<AudioSource>();
        Reload = GetComponent<AudioSource>();
        Damage = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayEnergyAudio()
    {
        Energy.PlayOneShot(EnergyAudio);
    }

    public void PlayItemAudio()
    {
        Item.PlayOneShot(ItemAudio);
    }

    public void PlayShootAudio()
    {
        Shoot.PlayOneShot(ShootAudio);
    }

    public void PlayEnemyAudio()
    {
        Enemy.PlayOneShot(EnemyAudio);
    }

    public void PlayWeaponAudio()
    {
        Weapon.PlayOneShot(WeaponAudio);
    }

    public void PlayGameOverAudio()
    {
        GameOver.PlayOneShot(GameOverAudio);
    }

    public void PlayWinMusicAudio()
    {
        WinMusic.PlayOneShot(WinMusicAudio);
    }

    public void PlayReloadAudio()
    {
        Reload.PlayOneShot(ReloadAudio);
    }

    public void PlayDamageAudio()
    {
        Damage.PlayOneShot(DamageAudio);
    }
}
