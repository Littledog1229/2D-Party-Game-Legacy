using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartyGame.Player.Movement
{
    public abstract class PlayerMovementBase : MonoBehaviour
    {
        public abstract void Setup();
        public abstract void Reactivate();
        public abstract void Deactivate();
        public abstract void TeleportPlayer(Vector3 teleportPosition);
    }

}