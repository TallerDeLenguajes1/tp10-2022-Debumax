// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Text.Json.Serialization;

public class Civilization
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("expansion")]
        public string? Expansion { get; set; }

        [JsonPropertyName("army_type")]
        public string? ArmyType { get; set; }

        [JsonPropertyName("unique_unit")]
        public List<string>? UniqueUnit { get; set; }

        [JsonPropertyName("unique_tech")]
        public List<string>? UniqueTech { get; set; }

        [JsonPropertyName("team_bonus")]
        public string? TeamBonus { get; set; }

        [JsonPropertyName("civilization_bonus")]
        public List<string>? CivilizationBonus { get; set; }
    }

    public class Civilizaciones
    {
        [JsonPropertyName("civilizations")]
        public List<Civilization> Civilizations { get; set; }
    }
