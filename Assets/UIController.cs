using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using PartyGame.Player;
using PartyGame.UI.Elements;
using PartyGame.Map.Management;
using System.Linq;

namespace PartyGame.UI
{
    public class UIController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private VisualTreeAsset playerSetupDocument;
        [SerializeField] private VisualTreeAsset playerInformation;
        [SerializeField] private UIDocument uiDisplay;
        [SerializeField] private PlayerManager playerManager;
        

        private VisualElement rootElement;
        private VisualElement playerContainer;
        private Button startButton;
        private Dictionary<PregamePlayerInformation, VisualElement> pregamePlayerBoxes = new Dictionary<PregamePlayerInformation, VisualElement>();
        #endregion

        #region Main Methods
        private void Start()
        {
            uiDisplay.visualTreeAsset = playerSetupDocument;
            rootElement = uiDisplay.rootVisualElement;

            SetWeaponSlider();

            startButton = rootElement.Q<Button>("StartButton");
            startButton.clicked += StartGame;
            //playerContainer = root.Q<VisualElement>("PlayerContainer");
        }
        #endregion

        public void JoinPlayer(PregamePlayerInformation playerInfo)
        {
            string pElem = "Player" + (playerInfo.PlayerInput.playerIndex + 1).ToString();
            VisualElement playerElement = rootElement.Q<VisualElement>(pElem);
            Label playerInformationLabel = playerElement.Q<Label>("PlayerInformation");

            playerInformationLabel.text = CreatePlayerInformationText(playerInfo);

            playerElement.Q<VisualElement>("PlayerColor").style.backgroundColor = playerInfo.PlayerColor;
            playerElement.style.display = DisplayStyle.Flex;

            pregamePlayerBoxes.Add(playerInfo, playerElement);
        }

        public void UpdatePlayerInformation(PregamePlayerInformation playerInfo)
        {
            if (pregamePlayerBoxes[playerInfo] != null)
            {
                pregamePlayerBoxes[playerInfo].Q<VisualElement>("PlayerColor").style.backgroundColor = playerInfo.PlayerColor;

                Label playerInformationLabel = pregamePlayerBoxes[playerInfo].Q<Label>("PlayerInformation");
                playerInformationLabel.text = CreatePlayerInformationText(playerInfo);
            }
        }

        private string CreatePlayerInformationText(PregamePlayerInformation playerInfo)
        {
            string informationText = "Input Device: " + playerInfo.PlayerInput.devices[0].displayName.ToString() +
                "\nControl Scheme: " + playerInfo.PlayerInput.currentControlScheme.ToString() +
                "\nPlayer Color: " + (playerInfo.PlayerColor.r * 255).ToString() + ", " + (playerInfo.PlayerColor.g * 255).ToString() + ", " + (playerInfo.PlayerColor.b * 255).ToString() +
                "\nStock Battle Wins: " + playerManager.GetWins(playerInfo.PlayerInput.playerIndex).ToString() +
                "\nStock Battle Kills: " + playerManager.GetKills(playerInfo.PlayerInput.playerIndex).ToString();

            return informationText;
        }

        private void StartGame()
        {
            GameObject[] players = new GameObject[pregamePlayerBoxes.Keys.Count];

            if (players.Length < 2) return;

            List<PregamePlayerInformation> playerInfo = pregamePlayerBoxes.Keys.ToList();

            for (int i = 0; i < playerInfo.Count; i++)
            {
                playerInfo[i].SelectedWeapon = pregamePlayerBoxes[playerInfo[i]].Q<SliderInt>("SelectedWeapon").value;
                players[i] = playerInfo[i].gameObject;
            }

            pregamePlayerBoxes.Clear();

            uiDisplay.visualTreeAsset = null;
            playerManager.SetupGame(players);
        }

        public void EndGame(GameObject[] playerInputObjects)
        {
            uiDisplay.visualTreeAsset = playerSetupDocument;
            rootElement = uiDisplay.rootVisualElement;

            SetWeaponSlider();

            startButton = rootElement.Q<Button>("StartButton");
            startButton.clicked += StartGame;

            foreach (GameObject player in playerInputObjects)
            {
                JoinPlayer(player.GetComponent<PregamePlayerInformation>());
            }
        }

        public void UpdateStringValue(string parentName, string objectName, string value)
        {
            rootElement.Q<VisualElement>(parentName).Q<Label>(objectName).text = value;
        }

        public void SetTreeAsset(VisualTreeAsset visualAsset)
        {
            uiDisplay.visualTreeAsset = visualAsset;
            rootElement = uiDisplay.rootVisualElement;
        }

        public void SetElementVisibility(string parentName, string objectName, bool value)
        {
            if (value) rootElement.Q<VisualElement>(parentName).Q<VisualElement>(objectName).style.display = DisplayStyle.Flex;
            else rootElement.Q<VisualElement>(parentName).Q<VisualElement>(objectName).style.display = DisplayStyle.None;
        }

        private void SetWeaponSlider()
        {
            for (int i = 0; i < 4; i++)
            {
                rootElement.Q<VisualElement>("Players").Q<VisualElement>("Player" + (i + 1).ToString()).Q<SliderInt>("SelectedWeapon").highValue = playerManager.WeaponManager.WeaponCount - 1;
            }
        }
    }
}