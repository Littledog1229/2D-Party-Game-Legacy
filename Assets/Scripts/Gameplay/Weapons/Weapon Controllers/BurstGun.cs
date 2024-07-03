using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using PartyGame.Weapons;
using PartyGame.Player;
using PartyGame.Bullets;

public class BurstGun : WeaponController
{
    [SerializeField] private PlayerUtility owner;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject fireSound;

    public override void SetupWeapon(PlayerUtility utility) { owner = utility; }

    public override void FireWeapon(WeaponProperties properties)
    {
        StartCoroutine(FireHandler(properties));
    }

    IEnumerator FireHandler(WeaponProperties properties)
    {
        FireBullet(properties);
        yield return new WaitForSeconds(0.1f);
        FireBullet(properties);
        yield return new WaitForSeconds(0.1f);
        FireBullet(properties);
    }

    private void FireBullet(WeaponProperties properties)
    {
        GameObject soundObject = Object.Instantiate<GameObject>(fireSound);
        soundObject.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 2f);
        Object.Destroy(soundObject, 0.2f);

        GameObject bulletObject = Object.Instantiate<GameObject>(bulletPrefab);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = gameObject.transform.rotation;
        bullet.Setup(owner.gameObject, owner.PlayerColor, properties.fireVelocity, properties.bulletDespawn);
    }
}
