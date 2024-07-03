using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

using PartyGame;
using PartyGame.Player;
using PartyGame.UI;
using PartyGame.Gamemode;

namespace PartyGame.Map.Management
{
    public class PlayerManager : MonoBehaviour
    {
        public enum PlayState
        {
            PlayerSetup,
            ActiveGame,
            GameFinished
        }

        #region Variables
        [Header("Scene Managers")]
        [SerializeField] private PlayerInputManager playerInputManager;
        [SerializeField] private GameObject pregameLobby;
        [SerializeField] private GamemodeManager gamemodeManager;
        [SerializeField] private SpawnpointManager spawnpointManager;
        [SerializeField] private WeaponManager weaponManager;
        [SerializeField] private UIController uiController;
        [SerializeField] private PlayState gameState;

        [Space()]

        [SerializeField] private GamemodeBase selectedGamemode;

        [Space()]

        /*
        [Header("Player Variables")]
        [SerializeField] private float respawnTimer;
        private Dictionary<PlayerUtility, float> playersToRespawn = new Dictionary<PlayerUtility, float>();
        */

        [Header("Misc Variables")]
        [SerializeField] private Camera stageCamera;
        [SerializeField] private GameObject defaultWeapon;
        [SerializeField] private int[] playerWins;
        [SerializeField] private int[] playerKills;
        #endregion

        #region Getters and Setters
        public SpawnpointManager SpawnpointManager
        {
            get { return spawnpointManager; }
        }

        public WeaponManager WeaponManager
        {
            get { return weaponManager; }
        }

        public UIController UIController
        {
            get { return uiController; }
        }

        public PlayState GameState
        {
            get { return gameState; }
        }

        public Camera StageCamera
        {
            get { return stageCamera; }
        }
        #endregion

        #region Main Methods
        private void Start()
        {
            gameState = PlayState.PlayerSetup;
            playerInputManager.EnableJoining();

            playerWins = new int[4];
            playerKills = new int[4];

            for (int i = 0; i < 4; i++) { playerWins[i] = 0; playerKills[i] = 0; }
        }

        private void Update()
        {

        }
        #endregion

        #region Methods
        public void JoinPlayer(PlayerInput playerInput)
        {
            playerInput.gameObject.transform.parent = pregameLobby.transform;
            playerInput.gameObject.name = "Player_" + playerInput.playerIndex;

            PregamePlayerInformation playerInfo = playerInput.gameObject.GetComponent<PregamePlayerInformation>();
            playerInfo.PlayerManager = this;
            playerInfo.PlayerColor = new Color((float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f);

            uiController.JoinPlayer(playerInfo);
        }

        public void SetupGame(GameObject[] playerInputObjects)
        {
            GameObject gamemodeObject = Object.Instantiate<GameObject>(gamemodeManager.GetGamemodeByID(0));
            selectedGamemode = gamemodeObject.GetComponent<GamemodeObject>().Gamemode;
            selectedGamemode.PlayerManager = this;
            gamemodeObject.name = selectedGamemode.GamemodeName;
            gamemodeObject.transform.parent = gamemodeManager.transform;

            selectedGamemode.StartGame(playerInputObjects);

            gameState = PlayState.ActiveGame;
        }

        public void EndGame(GameObject[] playerInputObjects)
        {
            gameState = PlayState.PlayerSetup;

            foreach (GameObject playerInputObject in playerInputObjects)
            {
                playerInputObject.transform.position = Vector3.zero;
                playerInputObject.transform.rotation = Quaternion.identity;
                playerInputObject.transform.parent = pregameLobby.transform;

                //playerInputObject.GetComponent<PregamePlayerInformation>().enabled = true;
                //playerInputObject.GetComponent<PlayerInput>().enabled = true;
            }

            Object.Destroy(selectedGamemode.gameObject);

            UIController.EndGame(playerInputObjects);
        }

        public void AddWin(int playerIndex) { playerWins[playerIndex]++; }
        public int GetWins(int playerIndex) { return playerWins[playerIndex]; }
        public void AddKill(int playerIndex) { playerKills[playerIndex]++; }
        public int GetKills(int playerIndex) { return playerKills[playerIndex]; }

        public void HitPlayer(PlayerUtility player, GameObject hitter)
        {
            if (gameState == PlayState.ActiveGame)
            {
                selectedGamemode.HitPlayer(player, hitter);
            }
        }
        #endregion
    }
}