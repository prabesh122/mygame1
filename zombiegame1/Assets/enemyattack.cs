namespace Mechanics
{
    using UnityEngine;
    using System.Collections;

    public class EnemyAttack : MonoBehaviour
    {
        public float attackRange = 5.0f; // The range at which the enemy can attack
        public int attackDamage = 10; // The amount of damage each attack does
        public float damageDuration = 1.0f; // The duration of each damage in seconds
        public float attackSpeed = 0.5f; // The attack speed of the enemy

        private Health playerHealth; // The health component of the player
        private GameObject player; // The player game object
        private bool isAttacking = false; // Check if the enemy is already attacking

        void Start()
        {
            // Find the player game object
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void FixedUpdate()
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // If the player is not within attack range, stop the attack
            if (distanceToPlayer > attackRange)
            {
                if (isAttacking)
                {
                    StopCoroutine("Attack");
                    isAttacking = false;
                }
            }
            // If the player is within attack range and Attack is not being called, start calling Attack again
            else if (!isAttacking)
            {
                StartCoroutine("Attack");
                isAttacking = true;
            }
        }

        public IEnumerator Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(attackSpeed);

                // Get the player's health component
                playerHealth = player.GetComponent<Health>();

                // If the player has a health component
                if (playerHealth != null)
                {
                    // Call the TakeDamage method of the player's Health script
                    playerHealth.TakeDamage(attackDamage);
                }

                yield return new WaitForSeconds(damageDuration);
            }
        }
    }
}
