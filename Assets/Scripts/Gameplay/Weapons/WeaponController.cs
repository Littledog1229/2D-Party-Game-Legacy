using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PartyGame.Player;

namespace PartyGame.Weapons
{
    [System.Serializable]
    public abstract class WeaponController : MonoBehaviour
    {
        public abstract void SetupWeapon(PlayerUtility utility);
        public abstract void FireWeapon(WeaponProperties properties);
    }
}
