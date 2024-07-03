using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PartyGame.Bullets;
using PartyGame.Player;

namespace PartyGame.Weapons
{
    public class BasicGun : WeaponController
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

            GameObject bulletObject = Object.Instantiate<GameObject>(bulletPrefab);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bulletObject.transform.position = gameObject.transform.position;
            bulletObject.transform.rotation = gameObject.transform.rotation;
            bullet.Setup(owner.gameObject, owner.PlayerColor, properties.fireVelocity, properties.bulletDespawn);
        }
    }
}
