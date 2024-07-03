using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

using PartyGame.Weapons;
using PartyGame.Map.Management;
using PartyGame.Player.Movement;
using static UnityEngine.InputSystem.InputAction;

namespace PartyGame.Player
{
    //[RequireComponent(typeof(UnityEngine.InputSystem.PlayerInput))]
    public class PlayerUtility : MonoBehaviour
    {
        #region Variables
        [Header("Main Variables")]
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private PlayerMovementBase playerMovement;
        [SerializeField] private UnityEngine.InputSystem.PlayerInput playerInput;
        [SerializeField] private Camera playerCamera;

        [Space()]

        [Header("GameObject References")]
        [SerializeField] private GameObject weaponHolder;
        [SerializeField] private GameObject weaponObject;
        [SerializeField] private Weapon weapon;

        [Space()]

        [Header("Player Properties")]
        [SerializeField] private Color playerColor = Color.white;
        [SerializeField] private bool playerActive = false;
        [SerializeField] private bool fireHeld = false;

        [Space()]

        [Header("Weapon Properties")]
        [SerializeField] private float weaponSetCooldown = 0f;
        [SerializeField] private float weaponCooldown = 0f;

        #endregion

        #region Getters and Setters
        public PlayerManager PlayerManager
        {
            get { return playerManager; }
        }

        public PlayerMovementBase PlayerMovement
        {
            get { return playerMovement; }
        }

        public PlayerInput PlayerInput
        {
            get { return playerInput; }
            set { playerInput = value; }
        }

        public bool PlayerActive
        {
            get { return playerActive; }
            set { playerActive = value; }
        }

        public Color PlayerColor
        {
            get { return playerColor; }
            set { playerColor = value; }
        }

        public Camera PlayerCamera
        {
            get { return playerCamera; }
        }

        public GameObject WeaponHolderObject
        {
            get { return weaponHolder; }
        }
        #endregion

        #region Main Methods
        private void OnDestroy()
        {
            playerInput.actions.FindAction("FireWeapon").started -= StartFire;
            playerInput.actions.FindAction("FireWeapon").canceled -= EndFire;
            playerInput.actions.FindAction("RandomColor").started -= RandomizeColor;
        }

        private void Update()
        {
            if (playerActive)
            {
                //Debug.Log("Should Fire");

                if (weaponCooldown > 0) weaponCooldown -= Time.deltaTime;

                if (fireHeld) FireWeapon();
            }
        }
        #endregion

        #region Public Methods
        public void SetPlayerManager(PlayerManager playerManager)
        {
            this.playerManager = playerManager;
        }

        public void Setup(Camera stageCamera)
        {
            // Set Transforms
            weaponHolder.transform.rotation = Quaternion.identity;

            // Set Player
            playerCamera = stageCamera;

            // Bind Actions
            playerInput.actions.FindAction("FireWeapon").started += StartFire;
            playerInput.actions.FindAction("FireWeapon").canceled += EndFire;
            playerInput.actions.FindAction("RandomColor").started += RandomizeColor;

            // Setup playerMovement
            playerMovement.Setup();

            // Finalize by setting the player to be active
            playerActive = true;
        }

        public void Deactivate()
        {
            playerActive = false;
            playerMovement.Deactivate();
        }
        public void Reactivate()
        {
            playerActive = true;
            gameObject.transform.rotation = Quaternion.identity;
            //RandomizeColor();
            playerMovement.Reactivate();
        }
        #endregion

        #region Methods
        private void StartFire(CallbackContext context) { if (playerActive) fireHeld = true; }
        private void EndFire(CallbackContext context) { if (playerActive) fireHeld = false; }

        public void SetWeaponObject(GameObject weaponObject)
        {
            this.weaponObject = weaponObject;
            weaponObject.transform.parent = weaponHolder.transform;
            weaponObject.transform.localPosition = Vector3.zero;

            Weapon weapon = weaponObject.GetComponent<Weapon>();
            weapon.SetPlayerUtility(this);
            weapon.WeaponController.SetupWeapon(this);
            this.weapon = weapon;

            this.weaponSetCooldown = 1f / (float) weapon.WeaponProperties.firerate;
        }

        private void FireWeapon()
        {
            if (playerActive)
            {
                if (weaponObject != null)
                {
                    if (weaponCooldown <= 0f)
                    {
                        weaponCooldown = weaponSetCooldown;
                        weapon.FireWeapon();
                    }
                }
                else Debug.Log("Weapon is null.");
            }
        }

        private void RandomizeColor(CallbackContext context)
        {
            if (playerActive)
            {
                playerColor = new Color((float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f);

                playerMovement.Setup();
            }
        }

        public void TeleportPlayer(Vector3 teleportPosition)
        {
            playerMovement.TeleportPlayer(teleportPosition);
        }
        #endregion
    }
}
