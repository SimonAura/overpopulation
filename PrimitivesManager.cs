using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Overpopulation
{
	public class PrimitivesManager
	{

		BasicEffect defaultEffect;

		public PrimitivesManager(GraphicsDevice pGraphicsDevice)
		{
			defaultEffect = new BasicEffect(pGraphicsDevice);
		}

		public void drawLine(Vector2 pPosition1, Vector2 pPosition2, GraphicsDevice pGraphicsDevice, Color pColor)
		{
			VertexPositionColor[] lineData = new VertexPositionColor[2];
			lineData[0].Position = new Vector3(pPosition1.X,0,pPosition1.Y);
			lineData[1].Position = new Vector3(pPosition2.X,0,pPosition2.Y);
			lineData[0].Color = pColor;
			lineData[1].Color = pColor;

			foreach (var passes in defaultEffect.CurrentTechnique.Passes)
			{
				passes.Apply();
				pGraphicsDevice.DrawUserPrimitives(
				PrimitiveType.LineList,
				lineData,
				0,
				1
			);
			}
		}	
	
	}
}