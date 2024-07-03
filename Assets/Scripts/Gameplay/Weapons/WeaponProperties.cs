using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyGame.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Properties", menuName = "Party Game/Content/Weapon Properties")]
    public class WeaponProperties : ScriptableObject
    {
        [Header("Weapon Specific Values")]
        public float weaponDamage;
        public Vector2 weaponKnockback;
        public float firerate;
        public float fireVelocity;
        public float bulletDespawn;
        public bool autofire;
        
    }
}