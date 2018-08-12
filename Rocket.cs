using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Overpopulation
{
	public class Rocket
	{
		public Vector2 position { get; set; }
		public Vector2 velocity;
		public Vector2 acceleration { get; set; }
		public ParticleManager reactor { get; set; }
		public float startY { get; set; }
		public float projectionSpeed { get; set; }
		public bool inSpace { get; set; }
		public bool engineOn { get; set; }
		public float health { get; set;}
		public bool isDestroyed { get; set;}
		public float defaultPositionX { get; set;}
		public float rotation { get; set; }
		public float maxVelocity { get; set; } = 10;
		Texture2D texture { get; set;}

		public Rocket(Vector2 pPosition,Texture2D pTexture)
		{
			health = 100;
			defaultPositionX = pPosition.X;
			position = pPosition;
			velocity = Vector2.Zero;
			acceleration = Vector2.Zero;
			startY = pPosition.Y;
			texture = pTexture;
			projectionSpeed = 0.5f;
			inSpace = false;
			engineOn = false;
			reactor = new ParticleManager(position);
		}

		public void Vibrate(Random pRandom)
		{
			int vibrateRange = 2;
			if (position.X < defaultPositionX - vibrateRange)
			{
				position = new Vector2(defaultPositionX - vibrateRange, position.Y);
			}
			else if (position.X > defaultPositionX + vibrateRange)
			{
				position = new Vector2(defaultPositionX + vibrateRange, position.Y);
			}
			position = new Vector2(position.X+pRandom.Next(-vibrateRange,vibrateRange), position.Y);
		}

		public void Destroy(Random pRandom, Texture2D[] pFragmentArray)
		{
			int fragmentsCount = pFragmentArray.Length;
			for (int i = 0; i < fragmentsCount; i++)
			{
				Vector2 tamp = reactor.anchor;
				reactor.anchor = new Vector2(reactor.anchor.Y, position.Y - (texture.Height * 0.22f));
				Particle p = reactor.addParticleFragment(pRandom, pFragmentArray[i], 0.22f, 1f);
				float angle = MathHelper.ToRadians((360 / fragmentsCount)*i);
				Vector2 gravity = new Vector2(0, 0.5f);
				Vector2 projection = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				projection.Normalize();
				projection *= 7;
				p.ApplyForce(gravity);
				p.ApplyForce(projection);
				reactor.anchor = tamp;
			}
		}
		
		public void Explode(Random pRandom, Texture2D pTexture)
		{
			for (int i = 0; i < 360; i+= 2)
			{
				Vector2 tamp = reactor.anchor;
				reactor.anchor = new Vector2(reactor.anchor.Y, position.Y - (texture.Height * 0.22f)/2);
				Particle p = reactor.addParticleFire(pRandom, pTexture, 3f, 0.3f);
				float angle = MathHelper.ToRadians(i);
				Vector2 gravity = new Vector2(0, 0.05f);
				Vector2 projection = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				projection.Normalize();
				projection *= (float)pRandom.Next(40, 50) / 100;
				p.ApplyForce(gravity);
				p.ApplyForce(projection);
				reactor.anchor = tamp;
			}
			for (int i = 0; i < 360; i+= 2)
			{
				Vector2 tamp = reactor.anchor;
				reactor.anchor = new Vector2(reactor.anchor.Y, position.Y - (texture.Height * 0.22f)/2);
				Particle p = reactor.addParticleSquare(pRandom, Color.Red, 3f, 0.3f);
				float angle = MathHelper.ToRadians(i);
				Vector2 gravity = new Vector2(0, 0.05f);
				Vector2 projection = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				projection.Normalize();
				projection *= 15;
				p.ApplyForce(gravity);
				p.ApplyForce(projection);
				reactor.anchor = tamp;
			}
		}

		public void Burn(Random pRandom, Texture2D pTexture)
		{
			Vector2 tamp = reactor.anchor;
			reactor.anchor = new Vector2(reactor.anchor.Y, position.Y - (texture.Height * 0.22f)/2);
			reactor.addParticleFire(pRandom, pTexture, 1.5f, 0.3f);
			float angle = MathHelper.ToRadians(pRandom.Next(0, 360));
			Vector2 gravity = new Vector2(0, 0.1f);
			Vector2 projection = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
			projection.Normalize();
			projection *= projectionSpeed;
			reactor.ApplyForce(gravity);
			reactor.ApplyForce(projection);
			reactor.anchor = tamp;
		}

		public string checkStabilization(Random pRandom,string pIsStabilized)
		{
			if (pIsStabilized == "NOT STABILIZED")
			{
				rotation += 0.005f;
				if (rotation > 0.4f)
				{
					return "gameover";
				}
 
			}
			else
			{
				if (rotation > 0)
				{
					rotation -= 0.005f;
				}
			}
			return null;
		}

		public void Update(Random pRandom, Texture2D pTexture)
		{
			velocity += acceleration;
			if (velocity.Length() > maxVelocity)
			{
				velocity.Normalize();
				velocity *= maxVelocity;
			}
			if (inSpace == false)
			{
				acceleration *= 0;
				if (engineOn && isDestroyed == false)
				{
					reactor.addParticleFire(pRandom, pTexture, 2, 0.8f);
					float angle = MathHelper.ToRadians(pRandom.Next(0, 180));
					Vector2 gravity = new Vector2(0, 0.1f);
					Vector2 projection = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
					projection.Normalize();
					projection *= projectionSpeed;
					reactor.ApplyForce(gravity);
					reactor.ApplyForce(projection);
				}
			}
			else
			{
				reactor.clear();
			}

			//-- REACTOR PARTICLES 
			reactor.anchor = position;
			reactor.Update();
			
		}

		public void applyForce(Vector2 pForce)
		{
			acceleration += pForce;
		}

		public void Draw(SpriteBatch pSpriteBatch)
		{
			if (isDestroyed == false)
			{
				pSpriteBatch.Draw(texture, position, null, null, new Vector2(texture.Width / 2, texture.Height), rotation, new Vector2(0.22f, 0.22f), Color.White, SpriteEffects.None, 0);
			}
			reactor.Draw(pSpriteBatch);
		}
	
	}
}