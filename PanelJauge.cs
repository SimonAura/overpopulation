using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class PanelJauge
	{
		Vector2 position { get; set; }
		Vector2 fillPosition { get; set;}
		Vector2 origin { get; set; }
		float scale { get; set;}
		Texture2D texture { get; set; }
		Color color { get; set; }
		Size2 size { get; set;}
		float currentValue { get; set;}
		float jaugeHeight { get; set; }
		float jaugeWidth { get; set; }

		public PanelJauge(Vector2 pPosition, Texture2D pTexture, Color pColor, float pValue, string pOrigin, float pScale)
		{
			position = pPosition;
			currentValue = pValue;
			texture = pTexture;
			scale = pScale;
			color = pColor;
			jaugeHeight = texture.Height - 10;
			jaugeWidth = texture.Width - 12;
			fillPosition = new Vector2(position.X+2, position.Y - 2 + texture.Height*scale);
			if (pOrigin == "center")
			{
				origin = new Vector2(pTexture.Width/2, pTexture.Height/2);
			}
			else if (pOrigin == "default")
			{
				origin = Vector2.Zero;
			}
			UpdateDisplay(currentValue);
		}

		public void UpdateDisplay(float pValue)
		{
			if (pValue <= 1)
			{
				currentValue = pValue;
				size = new Size2(jaugeWidth * scale, (pValue * jaugeHeight) * scale);
				fillPosition = new Vector2(position.X+2, position.Y - 2 + (texture.Height*scale) - (pValue * jaugeHeight) * scale);
			}
		}

		public void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.FillRectangle(new Vector2(position.X+2,position.Y - 2 + (texture.Height*scale) - jaugeHeight * scale), new Size2(jaugeWidth*scale,jaugeHeight*scale), Color.White);
			pSpriteBatch.FillRectangle(fillPosition, size, color);
			pSpriteBatch.Draw(texture, position, null, null, origin, 0, new Vector2(scale, scale), Color.White, SpriteEffects.None, 0);
		}
	
	}
}