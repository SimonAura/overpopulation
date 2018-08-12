using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class PanelItem : ClicableElement
	{
		Size2 size;
		float rectSize;
		public bool isVisible;
		
		public PanelItem(SpriteFont pFont, string pText, Vector2 pPosition, string pAction, Color pColor,Size2 pSize, string pOrigin, bool pIsInteractable) : base(pFont,pText,pPosition,pAction,pColor, pOrigin, pIsInteractable)
		{
			size = pSize;
			rectSize = pSize.Width;
			isVisible = true;
			size.Width += pFont.MeasureString(pText).X;
			size.Height += pFont.MeasureString(pText).Y;
		}

		public void UpdateDisplay(string pText)
		{
			text = pText;
			size.Width = font.MeasureString(text).X + rectSize;
			size.Height = font.MeasureString(text).Y + rectSize;
		}

		public override void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.FillRectangle(new Vector2( (position.X - rectSize / 2) - origin.X, position.Y + rectSize/2), size, Color.Black);
			if (isVisible)
			{
				base.Draw(pSpriteBatch);
			}
			pSpriteBatch.DrawRectangle(new Vector2((position.X - rectSize / 2) - origin.X, position.Y + rectSize / 2), size, Color.Gray, 1);
			
		}
	}
}
