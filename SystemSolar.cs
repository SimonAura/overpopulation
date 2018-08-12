using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Overpopulation
{
	
	public class SystemSolar
	{
		List<Planet> list_planets { get; set; }
		Star principalStar { get; set; }
		public string name { get; set; }
		float distance { get; set;}
		bool focusOnPlanet { get; set; }

		public string GeneratePlanetName(Random pRandom)
		{
			String name = "";
			
			char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789".ToCharArray();
			int count_chars = pRandom.Next(8, 10);
			for (int i = 0; i < count_chars; i++)
			{
				name = name + chars[pRandom.Next(chars.Length)];
			}

			return name;
		}
		
		public SystemSolar(string pName, float pDistance,Random pRandom, GraphicsDevice pGraphicsDevice)
		{
			name = pName;
			distance = pDistance;
			list_planets = new List<Planet>();
			principalStar = new Star(new Vector2(pGraphicsDevice.Viewport.Width/2,pGraphicsDevice.Viewport.Height/2),pRandom.Next(50,80));
			
			int count_planets = pRandom.Next(3, 5);
			float planetDistance = (int)principalStar.radius;

			float minDistance = principalStar.radius * 2;
			float maxDistance = principalStar.radius * 2 + 100;
			for (int i = 0; i < count_planets; i++)
			{
				float angle = MathHelper.ToRadians(pRandom.Next(0, 360));
				float radius = pRandom.Next(5, 20);
				planetDistance += pRandom.Next((int)radius * 2, (int)radius * 3);
				if (distance > maxDistance)
				{
					break;
				}
				else
				{
					string planetName = GeneratePlanetName(pRandom);
					string planetHaveWater = "no";
					string planetType = "gas";
					float typeRNG = pRandom.Next(0, 100);
					if (typeRNG <= 50)
					{
						planetType = "solid";
					}
					float planetTemperature = pRandom.Next(600,800) - planetDistance * 4;
					float waterRNG = pRandom.Next(0, 100);
					if (i == 1)
					{
						planetHaveWater = "yes";
						planetTemperature = pRandom.Next(35, 150);
						planetType = "solid";
						waterRNG = 49;
					}
					Color color = Color.White;
					if (planetTemperature >= 35 && planetTemperature <= 150 && waterRNG <= 50 && planetType == "solid")
					{
						planetHaveWater = "yes";
						color = new Color(pRandom.Next(5,15), pRandom.Next(50,70), pRandom.Next(180,210));
					}
					else
					{
						if (planetTemperature < 35)
						{
							color = new Color(pRandom.Next(140,155),pRandom.Next(140,155),pRandom.Next(180,220));
						}
						else if (planetTemperature > 150)
						{
							color = new Color(pRandom.Next(230,255),pRandom.Next(90,120),0);
						}
					}
		
					Planet newPlanet = new Planet(principalStar.position, planetDistance, angle, radius, color, planetName, planetType, planetHaveWater, planetTemperature);
					list_planets.Add(newPlanet);
				}
			}
		}

		public string CheckInteraction(Vector2 pMousePosition, GameState pGameState)
		{
			foreach (Planet p in list_planets)
			{
				string result = p.CheckInteraction(pMousePosition, pGameState);
				if (result != null)
				{
					foreach (Planet p2 in list_planets)
					{
						if (p != p2)
						{
							p2.isClicked = false;
						}
					}
					focusOnPlanet = true;
					return result;
				}
			}
			return null;
		}

		public void Update()
		{
			foreach (Planet p in list_planets)
			{
				p.Update();
			}
		}

		public void Draw(SpriteBatch pSpriteBatch, SpriteFont pFont, InterfaceManager pInterfaceManager)
		{
			if (focusOnPlanet == false)
			{
				float spacing = 35;
				Vector2 positionUI = new Vector2(15, 35);
				pSpriteBatch.DrawString(pFont, "ID : " + name, positionUI, Color.White);
				positionUI += new Vector2(0, spacing);
				pSpriteBatch.DrawString(pFont, "DISTANCE : " + distance + " LY", positionUI, Color.White);
			}

			principalStar.DrawGlow(pSpriteBatch);
			principalStar.Draw(pSpriteBatch);
			foreach (Planet p in list_planets)
			{
				p.DrawGlow(pSpriteBatch);
			}
			foreach (Planet p in list_planets)
			{
				p.DrawOrbit(pSpriteBatch);
			}
			foreach (Planet p in list_planets)
			{
				p.Draw(pSpriteBatch, pFont, pInterfaceManager);
			}
		}
		
	}
}