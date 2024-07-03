using PartyGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyGame.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [Header("Weapon Objects")]
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private WeaponProperties weaponProperties;
        [SerializeField] private SpriteRenderer weaponRenderer;

        [Header("Player Objects")]
        [SerializeField] private GameObject playerOwner;
        [SerializeField] private PlayerUtility playerUtility;

        private bool autofire;
        private float firedelay;

        public WeaponProperties WeaponProperties
        {
            get { return weaponProperties; }
        }

        public WeaponController WeaponController
        {
            get { return weaponController; }
        }

        private void Start()
        {
            playerOwner = gameObject;
            playerUtility = playerOwner.GetComponent<PlayerUtility>();
        }

        private void Update()
        {

        }

        private void Setup()
        {
            

            autofire = weaponProperties.autofire;
            firedelay = 1000f / (float) weaponProperties.firerate;
        }

        public void SetPlayerUtility(PlayerUtility playerUtility)
        {
            this.playerUtility = playerUtility;

            //weaponRenderer.color = playerUtility.PlayerColor;
        }

        public void FireWeapon()
        {
            weaponController.FireWeapon(weaponProperties);
        }
    }

}