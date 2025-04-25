namespace test
{
    public class Stats
    {
        public float AttackDamage { get; set; } = 50f;
        public float AttackSpeed { get; set; } = 1.0f;
        public float MaxHP { get; set; } = 100f;
        public float CurrentHP { get; set; } = 100f;

        public float MovementSpeed { get; set; } = 100f;
        public float Armor { get; set; } = 0f;

        // You can add methods like ResetHP() or TakeDamage() here if you want
    }
}
