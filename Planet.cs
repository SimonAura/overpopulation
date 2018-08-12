using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class Planet
	{
		public float radius { get; set; }
		public Vector2 position { get; set; }
		float angle { get; set; }
		float distance { get; set; }
		Vector2 anchor { get; set; }
		Color color { get; set; }
		public bool isClicked { get; set; }
		bool beforeClicked { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string haveWater { get; set; }
		public float temperature { get; set; }
		public bool displayHUD { get; set; }
		public bool displayOrbit { get; set; }

		public Planet(Vector2 pAnchor, float pDistance, float pAngle, float pRadius, Color pColor, string pName, string pType, string pHaveWater, float pTemperature)
		{
			color = pColor;
			angle = pAngle;
			radius = pRadius;
			distance = pDistance;
			position = pAnchor;
			anchor = pAnchor;
			name = pName;
			type = pType;
			haveWater = pHaveWater;
			temperature = pTemperature;
			displayHUD = true;
			displayOrbit = true;
		}

		public void switchClicked(GameState pGameState)
		{
			isClicked = !isClicked;
			if (isClicked)
			{
				pGameState.currentPlanet = this;
			}
			else
			{
				pGameState.currentPlanet = null;
			}
		}

		public string CheckInteraction(Vector2 pMousePosition, GameState pGameState)
		{
			if (pMousePosition.X < position.X + radius && pMousePosition.X > position.X - radius)
			{
				if (pMousePosition.Y < pMousePosition.Y + radius && pMousePosition.Y > pMousePosition.Y - radius)
				{
					switchClicked(pGameState);
					return "selection";
				}
			}
			return null;
		}

		public void Update()
		{
			angle += 0.01f;
			float x = (float)Math.Cos(angle) * distance;
			float y = (float)Math.Sin(angle) * distance;

			position = anchor + new Vector2(x, y);
			
		}

		public void DrawOrbit(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.DrawCircle(anchor, distance, 100, Color.White);
		}

		public void DrawGlow(SpriteBatch pSpriteBatch)
		{
			int glowResolution = 5;
			int glowRadius = 3;
			for (int i = 0; i < glowResolution; i++)
			{
				float aValue = 0.07f - (i / glowResolution);
				pSpriteBatch.DrawCircle(position, radius+i*glowRadius, 100, color*aValue, radius+i*glowRadius);
			}
		}

		public void Draw(SpriteBatch pSpriteBatch, SpriteFont pFont, InterfaceManager pInterfaceManager)
		{
			pSpriteBatch.DrawCircle(position, radius, 100, color, radius);

			Vector2 positionUI = new Vector2(15, 35);
			float spacing = 35;
			
			if (isClicked && displayHUD)
			{
				pSpriteBatch.DrawCircle(position, radius + 2, 100, Color.Crimson, 2);
				pSpriteBatch.DrawString(pFont, "ID : " + name, positionUI, Color.White);
				positionUI += new Vector2(0, spacing);
				pSpriteBatch.DrawString(pFont, "TYPE : " + type, positionUI, Color.White);
				positionUI += new Vector2(0, spacing);
				pSpriteBatch.DrawString(pFont, "TEMPERATURE : " + temperature, positionUI, Color.White);
				positionUI += new Vector2(0, spacing);
				pSpriteBatch.DrawString(pFont, "WATER : " + haveWater, positionUI, Color.White);
				positionUI += new Vector2(0, spacing);
					if (beforeClicked != isClicked)
					{
						Color buttonColor;
						bool isInteractable;
						if (haveWater == "yes")
						{
							buttonColor = Color.Green;
							isInteractable = true;
						}
						else
						{
							buttonColor = Color.Red;
							isInteractable = false;
						}
						pInterfaceManager.createButton(pSpriteBatch, positionUI, "Launch", "launch", pFont, "default", buttonColor, isInteractable);
					}
			}
			beforeClicked = isClicked;
		}
		
	}
}
