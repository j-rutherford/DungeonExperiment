namespace CreatureLibrary
{
    public abstract class Creature
    {
        private int _currentHealth;

        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value <= MaxHealth ? value : MaxHealth;
        }

        public string Description { get; set; }

        public Creature()
        {

        }
        protected Creature(string name, int maxHealth, string description)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Description = description;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}