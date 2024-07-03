using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using PartyGame.Gamemode;

namespace PartyGame.Map.Management
{
    public class GamemodeManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] knownGamemodes;

        public GameObject GetGamemodeByID(int id)
        {
            if (id >= knownGamemodes.Length)
            {
                if (knownGamemodes[0] != null)
                {
                    if (knownGamemodes[0].GetComponent<GamemodeObject>() != null) return knownGamemodes[0];
                    else
                    {
                        Debug.LogWarning("No valid GamemodeObject on object at id: 0");
                        return null;
                    }
                }
                else
                {
                    Debug.LogWarning("No valid gamemodes in manager.");
                    return null;

                }
            }
            else
            {
                if (knownGamemodes[id].GetComponent<GamemodeObject>() != null) return knownGamemodes[id];
                else
                {
                    Debug.LogWarning("No valid GamemodeObject on object at id: " + id);
                    return knownGamemodes[id];
                }
            }
        }
    }
}
