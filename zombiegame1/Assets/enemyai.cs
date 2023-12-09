namespace Mechanics
{
    using UnityEngine;

    public class EnemyAI : MonoBehaviour
    {
        public float chaseRange = 10.0f; // The range at which the enemy starts chasing the player
        public float chaseDelay = 2.0f; // The delay before the enemy starts chasing the player again

        private GameObject player; // The player game object
        private EnemyAttack enemyAttack; // The enemy's attack script
        private float chaseDelayTimer; // Timer for the chase delay

        void Start()
        {
            // Find the player game object and get the enemy's attack script
            player = GameObject.FindGameObjectWithTag("Player");
            enemyAttack = GetComponent<EnemyAttack>();
            chaseDelayTimer = Time.time;
        }

        void Update()
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // If the player is within chase range and outside attack range, and the chase delay timer has finished
            if (distanceToPlayer <= chaseRange && distanceToPlayer > enemyAttack.attackRange && Time.time >= chaseDelayTimer)
            {
                // Move towards the player
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
            }
            // If the player is within attack range
            else if (distanceToPlayer <= enemyAttack.attackRange)
            {
                // Call the enemy's attack method
                enemyAttack.Attack();

                // Set the chase delay timer
                chaseDelayTimer = Time.time + chaseDelay;
            }
        }
    }
}
