using PartyGame.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private BoxCollider2D enterBox;
    [SerializeField] private GameObject exitLocation;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            float xOffset = collision.gameObject.transform.position.x - enterBox.transform.position.x;

            collision.gameObject.GetComponent<PlayerUtility>().TeleportPlayer(exitLocation.transform.position + new Vector3(0f, 0f, xOffset));
        }
    }
}
