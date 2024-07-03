using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PartyGame.Weapons;

namespace PartyGame.Map.Management
{
    public class WeaponManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject[] weaponObjects;
        #endregion

        #region Getters and Setters
        public int WeaponCount { get { return weaponObjects.Length; } }
        #endregion

        #region Public Methods
        public GameObject GetWeaponByID(int weaponID)
        {
            if (weaponID >= weaponObjects.Length) return weaponObjects[0]; else return weaponObjects[weaponID];
        }
        #endregion
    }
}
