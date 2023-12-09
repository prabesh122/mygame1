namespace Mechanics
{
    using UnityEngine;

    public class Health : MonoBehaviour
    {
        public int maxHealth = 100;
        public int currentHealth;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (currentHealth <= 0)
            {
                Debug.Log(gameObject.name + " is dead!");
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            // Check health after taking damage
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }

        public void Heal(int healAmount)
        {
            currentHealth += healAmount;

            // Check health after healing
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
