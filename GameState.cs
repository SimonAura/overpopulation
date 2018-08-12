using System;
namespace Overpopulation
{
	public class GameState
	{

		public long count_humans { get; set; }
		public long count_maxHumans { get; set; }
		public Planet currentPlanet { get; set; }
		public SystemSolar currentSystem { get; set;}
		public float currentFuel { get; set; }
		public float currentTemperature { get; set; }
		public float rocketMinHealth { get; set; }
		public string isStabilized { get; set; }
		public float explosionTemperature { get; set;}
		public float destabilizationChance { get; set;}
		public float currentOxygene { get; set; }
		public float currentAltitude { get; set; }
		public float defaultAltitude { get; set;}
		public float targetAltitude { get; set; }
		public float maxAltitude { get; set;}
		public float rocketHumansCapacity { get; set; }
		public float rocketArrived { get; set; }
		public float targetRocketArrived { get; set;}
		public bool musicEnabled { get; set; } = true;
		public bool soundEnabled { get; set; } = true;
		public bool EngineOn { get; set; }

		public void init(string pDifficulty)
		{
			isStabilized = "NOT STABILIZED";
			currentFuel = 0;
			currentOxygene = 0;
			currentTemperature = 1;
			rocketHumansCapacity = 50000;
			targetRocketArrived = 3;
			explosionTemperature = 0.85f;
			rocketMinHealth = 10f;
			defaultAltitude = 0.5f;
			targetAltitude = 18000;
			currentAltitude = defaultAltitude;
			destabilizationChance = 1;
			maxAltitude = 10000;
		
			switch (pDifficulty)
			{
				case "normal":
					count_humans = 9271280257;
					count_maxHumans = 15000000000;
					break;
				default:
					count_humans = 9271280257;
					count_maxHumans = 15000000000;
					break;
			}
		}
	}
}
