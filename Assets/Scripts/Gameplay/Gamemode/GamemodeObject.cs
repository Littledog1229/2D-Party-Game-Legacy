using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyGame.Gamemode
{
    public class GamemodeObject : MonoBehaviour
    {
        [SerializeField] private GamemodeBase gamemode;

        public GamemodeBase Gamemode
        {
            get { return gamemode; }
        }
    }
}
