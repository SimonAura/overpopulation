using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Overpopulation
{
	class ParticleFragment : Particle
	{
		public float rotation { get; set; }
		
		public ParticleFragment(Vector2 pPosition, Texture2D pTexture, float pMaxTime, float pSize, float pAlpha, float pRotation) : base(pPosition, pTexture, pMaxTime, pSize, pAlpha)
		{
			rotation = pRotation;
		}
		
		public override void Update()
		{
			base.Update();
			rotation += 0.01f;
		}

		public	override void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.Draw(texture, position, null, null, Vector2.Zero, rotation, new Vector2(curSize,curSize), Color.White, SpriteEffects.None, 0);
		}
		
	}
}