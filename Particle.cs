using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class Particle
	{
		public Vector2 position { get; set; }
		public Vector2 velocity { get; set; }
		public Vector2 acceleration { get; set; }
		public float curLifeTime { get; set; }
		public float maxLifeTime { get; set; }
		public float curSize { get; set; }
		public float startSize { get; set;}
		public bool toDestroy { get; set; }
		public float alpha { get; set;}
		public Texture2D texture { get; set;}

		public Particle(Vector2 pPosition, Texture2D pTexture, float pMaxTime, float pSize, float pAlpha)
		{
			position = pPosition;
			velocity = Vector2.Zero;
			acceleration = Vector2.Zero;
			curLifeTime = 0;
			curSize = pSize;
			startSize = pSize;
			maxLifeTime = pMaxTime;
			texture = pTexture;
			alpha = pAlpha;
		}

		public virtual void Update()
		{
			position += velocity;
			velocity += acceleration;
			acceleration *= 0;

			curLifeTime += 0.01f;
			if (curLifeTime > maxLifeTime)
			{
				toDestroy = true;
			}
		}

		public void ApplyForce(Vector2 pForce)
		{
			acceleration += pForce;
		}

		public virtual void Draw(SpriteBatch pSpriteBatch)
		{
			float cValue = (curLifeTime / maxLifeTime);
			Color particleColor = new Color(alpha,alpha,alpha,alpha) * cValue;
			curSize = startSize * cValue;
			pSpriteBatch.Draw(texture, position, null, null, new Vector2(texture.Width / 2, texture.Height/2), 0, new Vector2(curSize,curSize),particleColor,SpriteEffects.None,0);
		}
	
	}
}