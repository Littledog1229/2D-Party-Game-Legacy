using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PartyGame.UI.Elements
{
    public class PlayernameComponent : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<PlayernameComponent, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription m_playerName = new UxmlStringAttributeDescription { name = "player-name", defaultValue = "PlayerNameObject" };
            UxmlColorAttributeDescription m_playerColor = new UxmlColorAttributeDescription { name = "player-color", defaultValue = Color.white };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription { get { yield break; } }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var pnc = ve as PlayernameComponent;

                pnc.Clear();

                pnc.playerName = m_playerName.GetValueFromBag(bag, cc);
                pnc.playerNameLabel = new Label(pnc.playerName);
                pnc.playerNameLabel.name = "player-name";
                pnc.playerNameLabel.style.fontSize = 16;
                pnc.playerNameLabel.style.color = Color.white;
                pnc.playerNameLabel.style.paddingLeft = 6;
                pnc.Add(pnc.playerNameLabel);

                pnc.playerColor = m_playerColor.GetValueFromBag(bag, cc);
                pnc.playerColorElement = new VisualElement();
                pnc.playerColorElement.name = "player-color";
                pnc.playerColorElement.style.backgroundColor = pnc.playerColor;
                pnc.playerColorElement.style.width = 5;
                pnc.playerColorElement.style.height = 20;
                pnc.playerColorElement.style.position = Position.Absolute;
                pnc.Add(pnc.playerColorElement);
            }
        }

        private Label playerNameLabel;
        private VisualElement playerColorElement;

        public PlayernameComponent() { }
        public PlayernameComponent(string name, Color color)
        {
            playerName = name;
            playerColor = color;

            playerNameLabel = new Label(playerName);
            playerNameLabel.name = "player-name";
            playerNameLabel.style.fontSize = 16;
            playerNameLabel.style.color = Color.white;
            playerNameLabel.style.paddingLeft = 11;

            playerColorElement = new VisualElement();
            playerColorElement.name = "player-color";
            playerColorElement.style.backgroundColor = playerColor;
            playerColorElement.style.width = 10;
            playerColorElement.style.height = 20;
            playerColorElement.style.position = Position.Absolute;

            hierarchy.Add(playerNameLabel);
            hierarchy.Add(playerColorElement);
        }

        private string playerName { get; set; }
        private Color playerColor { get; set; }

        public Color PlayersColor { get { return playerColorElement.style.backgroundColor.value; } set { playerColorElement.style.backgroundColor = value; } }
    }
}
