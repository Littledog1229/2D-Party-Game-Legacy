using PartyGame.Bullets;
using PartyGame.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace PartyGame.Gamemode.Gamemodes
{
    public class StockBattle : GamemodeBase
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private List<PlayerUtility> players = new List<PlayerUtility>();
        [SerializeField] private List<PlayerUtility> deadPlayers = new List<PlayerUtility>();
        [SerializeField] private VisualTreeAsset stocksDocs;
        [SerializeField] private GameObject killParticle;
        [SerializeField] private GameObject deathSound;
        [SerializeField] private int stocks;

        private float respawnTime = 2f;
        private Dictionary<PlayerUtility, float> playersToRespawn = new Dictionary<PlayerUtility, float>();
        private Dictionary<PlayerUtility, int> playerStocks = new Dictionary<PlayerUtility, int>();
        private Dictionary<PlayerUtility, int> playerKills = new Dictionary<PlayerUtility, int>();

        public StockBattle()
        {
            gamemodeName = "Stock Battle";
            
        }

        private void Update()
        {
            if (playersToRespawn.Keys.Count > 0)
            {
                foreach(PlayerUtility deadPlayer in playersToRespawn.Keys.ToList())
                {
                    if (playersToRespawn[deadPlayer] - Time.deltaTime <= 0)
                    {
                        deadPlayer.Reactivate();
                        playerManager.SpawnpointManager.TeleportToSpawnpoint(deadPlayer.gameObject);
                        playersToRespawn.Remove(deadPlayer);
                    }
                    else playersToRespawn[deadPlayer] -= Time.deltaTime;
                }
            }
        }

        public override void SetupPlayer(PlayerInput playerInput)
        {
            GameObject playerObject = Object.Instantiate<GameObject>(playerPrefab);

            // Get Player Utility
            PlayerUtility playerUtility = playerObject.GetComponent<PlayerUtility>(); // Self expanatory
            players.Add(playerUtility);
            playerObject.gameObject.transform.parent = playerObject.transform;

            // Setup Stocks
            playerStocks.Add(playerUtility, stocks);
            playerManager.UIController.SetElementVisibility("StockHolder", "Player" + (playerInput.playerIndex + 1).ToString() + "Holder", true);
            playerManager.UIController.UpdateStringValue("Player" + (playerInput.playerIndex + 1).ToString() + "Holder", "StocksText", "Stocks: " + playerStocks[playerUtility].ToString());

            // Set GameObject Values
            playerObject.transform.parent = gameObject.transform; // Neatly organize the player into a player storage
            playerObject.transform.name = "Player_ " + playerInput.playerIndex; // Set the player name based on their player index
            playerInput.gameObject.transform.parent = playerObject.transform; // Set the inputs owner to the player
            playerManager.SpawnpointManager.TeleportToSpawnpoint(playerObject.gameObject); // Teleport the player to a map spawnpoint

            playerInput.SwitchCurrentActionMap("Player");

            // Set Player Utility Values
            playerUtility.PlayerInput = playerInput;
            playerUtility.PlayerColor = playerInput.gameObject.GetComponent<PregamePlayerInformation>().PlayerColor;
            //playerUtility.PlayerColor = new Color((float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f); // Set the player color to a random color
            playerUtility.SetPlayerManager(PlayerManager); // Set the player manager of the player
            int weaponID = playerInput.gameObject.GetComponent<PregamePlayerInformation>().SelectedWeapon; // Weapon ID for player
            playerUtility.SetWeaponObject(Object.Instantiate(playerManager.WeaponManager.GetWeaponByID(weaponID)));
            playerUtility.Setup(playerManager.StageCamera);
        }

        public override void StartGame(GameObject[] playerInputObjects)
        {
            playerManager.UIController.SetTreeAsset(stocksDocs);

            foreach (GameObject inputObject in playerInputObjects)
            {
                SetupPlayer(inputObject.GetComponent<PlayerInput>());
            }
        }

        public override void EndGame()
        {
            List<GameObject> playerInputObjects = new List<GameObject>();

            foreach(PlayerUtility player in players)
            {
                GameObject inputObject = player.transform.GetComponentInChildren<PlayerInput>().gameObject;
                inputObject.transform.parent = playerManager.UIController.transform;
                player.PlayerInput.SwitchCurrentActionMap("Pre-game");
                playerManager.AddWin(player.PlayerInput.playerIndex);

                playerInputObjects.Add(inputObject);
                GameObject.Destroy(player.gameObject);
            }

            foreach(PlayerUtility player in deadPlayers)
            {
                GameObject inputObject = player.transform.GetComponentInChildren<PlayerInput>().gameObject;
                inputObject.transform.parent = playerManager.UIController.transform;
                player.PlayerInput.SwitchCurrentActionMap("Pre-game");

                playerInputObjects.Add(inputObject);
                GameObject.Destroy(player.gameObject);
            }

            playerManager.EndGame(playerInputObjects.ToArray());
        }

        public override void HitPlayer(PlayerUtility player, GameObject hitter)
        {
            if (playersToRespawn.Keys.Contains(player)) return;

            if (playerStocks[player] - 1 <= 0)
            {
                players.Remove(player);
                playerStocks.Remove(player);

                deadPlayers.Add(player);
                playerManager.UIController.SetElementVisibility("StockHolder", "Player" + (player.PlayerInput.playerIndex + 1).ToString() + "Holder", false);
            } else
            {
                playersToRespawn.Add(player, respawnTime);
                playerStocks[player] -= 1;
                playerManager.UIController.UpdateStringValue("Player" + (player.PlayerInput.playerIndex + 1).ToString() + "Holder", "StocksText", "Stocks: " + playerStocks[player].ToString());
            }

            //playerKills[hitter.GetComponent<Bullet>().Owner]++;

            playerManager.AddKill(hitter.GetComponent<Bullet>().Owner.PlayerInput.playerIndex);

            GameObject particleObject = Object.Instantiate(killParticle);
            ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();

            Gradient colorOverTime = new Gradient();

            GradientColorKey[] colorKeys = new GradientColorKey[2];
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];

            colorKeys[0].color = player.PlayerColor;
            colorKeys[0].time = 0f;
            colorKeys[1].color = Color.black;
            colorKeys[1].time = 1f;

            alphaKeys[0].alpha = 1f;
            alphaKeys[0].time = 0f;
            alphaKeys[1].alpha = 1f;
            alphaKeys[1].time = 1f;

            colorOverTime.SetKeys(colorKeys, alphaKeys);

            ParticleSystem.ColorOverLifetimeModule col = particleSystem.colorOverLifetime;

            col.color = colorOverTime;
            particleObject.transform.position = player.gameObject.transform.position;

            Object.Destroy(particleObject, 1f);

            GameObject deathSoundObject = Object.Instantiate(deathSound);
            deathSoundObject.transform.position = player.gameObject.transform.position;
            Object.Destroy(deathSoundObject, 5f);

            player.Deactivate();
            playerManager.SpawnpointManager.TeleportToDeathpoint(player.gameObject);

            if (players.Count <= 1) EndGame();
        }
    }
}
