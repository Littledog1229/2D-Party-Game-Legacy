using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using PartyGame.Player;
using PartyGame.Weapons;
using PartyGame.Bullets;

public class ShotGun : WeaponController
{
    [SerializeField] private PlayerUtility owner;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject fireSound;

    public override void SetupWeapon(PlayerUtility utility)
    {
        owner = utility;
    }

    public override void FireWeapon(WeaponProperties properties)
    {
        GameObject soundObject = Object.Instantiate<GameObject>(fireSound);
        soundObject.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 2f);
        Object.Destroy(soundObject, 0.2f);

        for (int i = 0; i < properties.weaponDamage; i++)
        {
            FireShot(properties);
        }
    }

    private void FireShot(WeaponProperties properties)
    {
        GameObject bulletObject = Object.Instantiate<GameObject>(bulletPrefab);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.eulerAngles.z + Random.Range(-25f, 25f));
        bullet.Setup(owner.gameObject, owner.PlayerColor, properties.fireVelocity + Random.Range(-5f, 5f), properties.bulletDespawn);
    }
}
