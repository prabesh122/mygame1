namespace Mechanics
{
    using UnityEngine;

    public class PlayerAttack : MonoBehaviour
    {
        public float attackRange = 5.0f; // The range at which the player can attack
        public int attackDamage = 10; // The amount of damage each attack does

        private Health enemyHealth; // The health component of the enemy

        void Update()
        {
            // Check if the left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // Cast a ray from the player's position in the direction they are facing
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
                {
                    // Check if the ray hit an enemy
                    enemyHealth = hit.transform.GetComponent<Health>();
                    if (enemyHealth != null)
                    {
                        // Call the TakeDamage method of the enemy's Health script
                        enemyHealth.TakeDamage(attackDamage);
                    }
                }
            }
        }
    }
}
