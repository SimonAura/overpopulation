using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Overpopulation
{
	public class ClicableElement
	{
		public Vector2 position { get; set; }
		public Vector2 size { get; set; }
		public string text { get; set; }
		public SpriteFont font { get; set; }
		public Color color { get; set; }
		string action { get; set; }
		public Vector2 origin { get; set; }
		public bool isInteractable { get; set; } 

		public ClicableElement(SpriteFont pFont, string pText, Vector2 pPosition, string pAction,Color pColor, string pOrigin, bool pIsInteractable)
		{
			font = pFont;
			text = pText;
			position = pPosition;
			color = pColor;
			action = pAction;
			isInteractable = pIsInteractable;
			size = font.MeasureString(text);
			if (pOrigin == "center")
			{
				origin = new Vector2(font.MeasureString(text).X / 2, 0);
			}
			else if (pOrigin == "default")
			{
				origin = Vector2.Zero;
			}
		}

		public virtual string CheckInteraction(Vector2 pMousePosition, bool pHaveClicked, SoundEffect pSoundEffect1, SoundEffect pSoundEffect2)
		{
			if (pMousePosition.X > position.X && pMousePosition.X < position.X + size.X)
			{
				if (pMousePosition.Y > position.Y && pMousePosition.Y < position.Y + size.Y)
				{
					if (pHaveClicked && isInteractable)
					{
						return action;
					}
					else
					{
						return "over";
					}
				}
			}
			return null;
		}

		public virtual void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.DrawString(font, text, position, color, 0f, origin, 1f,SpriteEffects.None,0);
		}
	
	}
}