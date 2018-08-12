using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class Star
	{
		public Vector2 position { get; set; }
		public float radius { get; set; }
		public Color color { get; set; }

		public Star(Vector2 pPosition, float pRadius)
		{
			position = pPosition;
			radius = pRadius;
			color = Color.Yellow;
		}

		public void DrawGlow(SpriteBatch pSpriteBatch)
		{
			int glowResolution = 5;
			int glowRadius = (int)radius / 2;
			for (int i = 0; i < glowResolution; i++)
			{
				float aValue = 0.07f - (i / glowResolution);
				pSpriteBatch.DrawCircle(position, radius+i*glowRadius, 300, color*aValue, radius+i*glowRadius);
			}
		}

		public void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.DrawCircle(position, radius, 50, color, radius);
		}
		
	}
}