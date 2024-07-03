using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using PartyGame.Input;
using static UnityEngine.InputSystem.InputAction;
//using System;

namespace PartyGame.Player.Movement
{
    [RequireComponent(typeof(PlayerUtility))]
    public class PlayerSidescrollerMovement : PlayerMovementBase
    {
        #region Variables
        [Header("References")]
        [SerializeField] private PlayerUtility playerUtility; // Utility that stores overall information of the player
        [SerializeField] private SpriteRenderer playerRenderer; // Player sprite renderer
        [SerializeField] private Rigidbody2D playerBody; // Player Rigidbody
        //[SerializeField] private GameObject holderObject; // Player Weapon Holder GameObject
        [SerializeField] private TrailRenderer playerTrail; // Player trail renderer
        [SerializeField] private GameObject jumpSound;

        [Space()]

        [Header("Player Variables")]
        [SerializeField] private float walkspeed; // Player walkspeed
        [SerializeField] private float jumpspeed; // Player Jumpspeed/velocity
        [SerializeField] private float jumpCooldownTime; // Player Jump Cooldown timer
        [SerializeField] private int maxJumps;

        [Header("Temporary Expositions")]
        [SerializeField] private int jumpsLeft;
        //[SerializeField] private bool canJump = true;
        [SerializeField] private float currentJumpCooldown;
        #endregion

        #region Main Methods
        private void Start() { }

        private void Update()
        {
            // Player Input Handling
            if (playerUtility.PlayerActive)
            {
                HandleMovement(); // Handle the players movement
                HandleAim(); // Handle the players aiming

                //Debug.DrawRay(gameObject.transform.position, Vector3.down * 0.6f, Color.green, 1f);

                if (jumpsLeft < maxJumps) { 
                    //if (currentJumpCooldown - Time.deltaTime > 0f) currentJumpCooldown -= Time.deltaTime; else jumpsLeft = maxJumps;

                    RaycastHit2D jumpHit = Physics2D.Raycast(gameObject.transform.position, Vector3.down, 0.6f);
                    //Debug.DrawLine(gameObject.transform.position, jumpHit.point, playerUtility.PlayerColor, 1f);

                    if (jumpHit) jumpsLeft = maxJumps;
                }
            }
        }

        private void OnDestroy()
        {
            playerUtility.PlayerInput.actions.FindAction("Jump").started -= HandleJump;
        }
        #endregion

        #region Abstract Overrides
        public override void Setup()
        {
            playerUtility.PlayerInput.actions.FindAction("Jump").started += HandleJump;
            jumpsLeft = maxJumps;

            playerRenderer.color = playerUtility.PlayerColor;
            playerTrail.startColor = playerUtility.PlayerColor;
        }

        public override void Reactivate()
        {
            playerTrail.gameObject.SetActive(true);
        }

        public override void Deactivate()
        {
            playerTrail.gameObject.SetActive(false);
        }

        public override void TeleportPlayer(Vector3 teleportPosition)
        {
            gameObject.transform.position = teleportPosition;
            playerTrail.Clear();
        }
        #endregion

        #region Player Input
        public void HandleMovement()
        {
            // Input active check not required since this is changed in update
            playerBody.velocity = new Vector2(playerUtility.PlayerInput.actions.FindAction("XMovement").ReadValue<float>() * walkspeed, playerBody.velocity.y);
        }

        public void HandleJump(CallbackContext context)
        {
            // Input active check required since this is fired as an event
            if (playerUtility.PlayerActive && jumpsLeft > 0)
            {
                //canJump = false;
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpspeed);
                jumpsLeft -= 1;

                GameObject jumpObject = Object.Instantiate<GameObject>(jumpSound);
                jumpObject.GetComponent<AudioSource>().pitch += Random.Range(-0.5f, 0.5f);
                Object.Destroy(jumpObject, 0.25f);
                
            }
        }

        // Method for handling the players aim
        private void HandleAim()
        {
            // Input active check not required since this is changed in update
            Vector2 aimValue = playerUtility.PlayerInput.actions.FindAction("Aim").ReadValue<Vector2>();

            if (playerUtility.PlayerInput.currentControlScheme == "Gamepad")
            {
                // Get the aim angle based on the control stick values
                float angle = Mathf.Atan2(aimValue.y, aimValue.x) * Mathf.Rad2Deg;
                // Create the rotation
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                // Set the rotation
                playerUtility.WeaponHolderObject.transform.rotation = rotation;
            }

            if (playerUtility.PlayerInput.currentControlScheme == "Keyboard")
            {
                // Get the direction of aim
                Vector3 aimDirection = playerUtility.PlayerCamera.ScreenToWorldPoint(aimValue) - gameObject.transform.position;

                // Get the aim angle based on the aimDirection
                float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                // Create the rotation
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                // Set the rotation
                playerUtility.WeaponHolderObject.transform.rotation = rotation;
            }
        }
        #endregion
    }
}

