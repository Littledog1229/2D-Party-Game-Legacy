using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PartyGame.Player;

namespace PartyGame.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject owner;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TrailRenderer bulletTrail;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletDamage;
        [SerializeField] private float despawnTime;
        [SerializeField] private LayerMask hitLayer;

        [SerializeField] private Vector3 previousPosition;

        private float aliveTime = 0f;

        public PlayerUtility Owner
        {
            get { return owner.GetComponent<PlayerUtility>(); }
        }

        public void Setup(GameObject owner, Color trailColor, float bulletSpeed, float despawnTime)
        {
            this.despawnTime = despawnTime;
            this.bulletSpeed = bulletSpeed;

            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.right * bulletSpeed;
            this.owner = owner;
            spriteRenderer.color = trailColor;
            bulletTrail.startColor = trailColor;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            /*
            if (collision.gameObject.layer == 7)
            {
                Object.Destroy(gameObject);
            }
            else if (collision.gameObject.layer == 6 && collision.gameObject != owner)
            {
                PlayerUtility playerUtility = collision.gameObject.GetComponent<PlayerUtility>();
                playerUtility.PlayerManager.HitPlayer(playerUtility, this.gameObject);
                Object.Destroy(gameObject);
            }
            */
        }

        #region Main Methods
        private void Start()
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.right * bulletSpeed;
            previousPosition = transform.position;
        }

        private void Update()
        {
            aliveTime += Time.deltaTime;

            if (aliveTime > despawnTime) Object.Destroy(gameObject);

            RaycastHit2D hitCast = Physics2D.Linecast(previousPosition, transform.position, hitLayer);

            if (hitCast)
            {
                if (hitCast.collider.gameObject.layer == 7)
                {
                    Object.Destroy(gameObject);
                }
                else if (hitCast.collider.gameObject.layer == 6 && hitCast.collider.gameObject != owner)
                {
                    PlayerUtility playerUtility = hitCast.collider.gameObject.GetComponent<PlayerUtility>();
                    playerUtility.PlayerManager.HitPlayer(playerUtility, this.gameObject);
                    Object.Destroy(gameObject);
                }
            }

            previousPosition = transform.position;
        }
        #endregion
    }

}