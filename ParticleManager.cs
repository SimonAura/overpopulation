using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Overpopulation
{
	public class ParticleManager
	{
		List<Particle> list_particles;
		int radius;
		public Vector2 anchor;
		
		public ParticleManager(Vector2 pAnchor)
		{
			list_particles = new List<Particle>();
			anchor = pAnchor;
			radius = 20;
		}

		public Particle addParticleSquare(Random pRandom, Color pColor, float pSize, float pAlpha)
		{
			Vector2 newParticlePosition = new Vector2(pRandom.Next(-radius,radius),pRandom.Next(-radius,radius));
			Particle newParticle = new ParticleSquare(newParticlePosition + anchor, pColor, 0.2f, pSize, pAlpha);
			list_particles.Add(newParticle);
			return newParticle;
		}

		public Particle addParticleFire(Random pRandom, Texture2D pTexture, float pSize, float pAlpha)
		{
			Vector2 newParticlePosition = new Vector2(pRandom.Next(-radius,radius),pRandom.Next(-radius,radius));
			Particle newParticle = new Particle(newParticlePosition + anchor, pTexture, 0.2f, pSize, pAlpha);
			list_particles.Add(newParticle);
			return newParticle;
		}
		public Particle addParticleFragment(Random pRandom, Texture2D pTexture, float pSize, float pAlpha)
		{
			Vector2 newParticlePosition = new Vector2(pRandom.Next(-radius,radius),pRandom.Next(-radius,radius));
			Particle newParticle = new ParticleFragment(newParticlePosition + anchor, pTexture, 1f, pSize, pAlpha, MathHelper.ToRadians(pRandom.Next(0,360)));
			list_particles.Add(newParticle);
			return newParticle;
		}
		
		public Particle addParticleStar(Random pRandom, Texture2D pTexture, GraphicsDevice pGraphicsDevice,float pSize)
		{
			Vector2 newParticlePosition = new Vector2(pRandom.Next(0,pGraphicsDevice.Viewport.Width),pRandom.Next(0,pGraphicsDevice.Viewport.Height));
			Particle newParticle = new Particle(newParticlePosition, pTexture, 2f, pSize,1);
			list_particles.Add(newParticle);
			return newParticle;
		}

		public void ApplyForce(Vector2 pForce)
		{
			foreach (Particle p in list_particles)
			{
				p.ApplyForce(pForce);
			}
		}

		public void clear()
		{
			list_particles = new List<Particle>();
		}

		public void Update()
		{
			for (int i = list_particles.Count-1; i >= 0 ; i--)
			{
				Particle p = list_particles[i];
				p.Update();
				if (p.toDestroy)
				{
					list_particles.Remove(p);
				}
			}
		}

		public void Draw(SpriteBatch pSpriteBatch)
		{
			foreach (Particle p in list_particles)
			{
				p.Draw(pSpriteBatch);
			}
		}
		
	}
}
