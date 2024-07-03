using PartyGame.Map.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PartyGame.Player
{
    public class PregamePlayerInformation : MonoBehaviour
    {
        #region Variables
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Color playerColor;
        [SerializeField] private int selectedWeapon;
        #endregion

        private void Start()
        {
            playerInput.currentActionMap.FindAction("RandomColor").started += _ => RandomizeColor();
        }

        #region Getters and Setters
        public PlayerManager PlayerManager
        {
            get { return playerManager; }
            set { playerManager = value; }
        }
        public PlayerInput PlayerInput
        {
            get { return playerInput; }
            set { playerInput = value; }
        }
        public Color PlayerColor
        {
            get { return playerColor; }
            set { playerColor = value; }
        }
        public int SelectedWeapon
        {
            get { return selectedWeapon; }
            set { selectedWeapon = value; }
        }
        #endregion

        public void RandomizeColor()
        {
            if (playerManager.GameState == PlayerManager.PlayState.PlayerSetup)
            {
                playerColor = new Color((float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f);
                playerManager.UIController.UpdatePlayerInformation(this);
            }
        }
    }
}
