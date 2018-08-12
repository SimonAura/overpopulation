using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	class ParticleSquare : Particle
	{
		Color color;

		public ParticleSquare(Vector2 pPosition, Color pColor, float pMaxTime, float pSize, float pAlpha) : base(pPosition,null,pMaxTime,pSize,pAlpha)
		{
			color = pColor;
		}

		public override void Update()
		{
			base.Update();
			alpha -= 0.001f;
			color = new Color(color.R * alpha, color.G * alpha, color.B * alpha, alpha);
		}

		public override void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.FillRectangle(position, new Size2(curSize,curSize), color);
		}
	}
}