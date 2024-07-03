using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PartyGame.Map.Management
{
    public class SpawnpointManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject[] spawnpoints;
        [SerializeField] private GameObject deathpoint;
        [SerializeField] private LayerMask playerMask;
        #endregion

        #region Main Methods
        private void Start()
        {
            Debug.Log("Initialized Map with: " + spawnpoints.Length + " spawnpoints");
        }

        private void Update()
        {

        }
        #endregion

        #region Public Methods
        public void SpawnPlayer(PlayerInput playerInput)
        {
            TeleportToSpawnpoint(playerInput.gameObject);
        }

        public void SpawnEntity(GameObject entity)
        {
            entity.transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position;
        }

        public void TeleportToSpawnpoint(GameObject player)
        {
            List<GameObject> spawnablePoints = new List<GameObject>();

            for (int i = 0; i < spawnpoints.Length; i++)
            {
                RaycastHit2D hit = Physics2D.BoxCast(spawnpoints[i].transform.position, new Vector2(3f, 3f), 0f, Vector2.up, 0.1f, playerMask);


                if (!hit) spawnablePoints.Add(spawnpoints[i]);
            }

            player.transform.position = spawnablePoints[Random.Range(0, spawnablePoints.Count)].transform.position;
        }

        public void TeleportToDeathpoint(GameObject player)
        {
            player.transform.position = deathpoint.transform.position;
        }
        #endregion
    }
}
