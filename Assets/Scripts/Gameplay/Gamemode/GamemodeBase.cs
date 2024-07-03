using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using PartyGame.Player;
using PartyGame.Map.Management;
using UnityEngine.InputSystem;

public abstract class GamemodeBase : MonoBehaviour
{
    #region Variables
    protected string gamemodeName;
    
    protected PlayerManager playerManager;
    #endregion

    #region Getters and Setters
    public string GamemodeName
    {
        get { return gamemodeName; }
    }

    public PlayerManager PlayerManager
    {
        get { return playerManager; }
        set { playerManager = value; }
    }
    #endregion

    #region Abstract Methods
    public abstract void SetupPlayer(PlayerInput playerInput);
    public abstract void StartGame(GameObject[] playerInputObjects);
    public abstract void EndGame();
    public abstract void HitPlayer(PlayerUtility player, GameObject hitter);
    #endregion
}
