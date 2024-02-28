namespace PokemonTeamBuilder.Server
{
    public class Pokemon
    {
        public string name { get; set; }
        public Sprite sprites { get; set; }
        public Stats[] stats { get; set; }
        public PokemonTypes[] types { get; set; }
        public Cries cries { get; set; }

        public class Sprite
        {
            public string front_default { get; set; }
        }

        public class Stats
        {
            public int base_stat { get; set; }
            public Stat stat { get; set; }

            public class Stat
            {
                public string name { get; set; }
            }
        }

        public class PokemonTypes
        {
            public int slot { get; set; }
            public PokemonType type { get; set; }

            public class PokemonType
            {
                public string name { get; set; }
            }
        }

        public class Cries
        {
            public string latest { get; set; }
        }
    }
}
