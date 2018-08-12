using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Overpopulation
{
	public class Gameover
	{
		float alpha = 1;
		bool next = false;
		string reason;
		string errorString = "-ERROR: ";
		string continueString = "PRESS ENTER TO CONTINUE";
		string defaultErrorString;
		string defaultContinueString;
	
		public Gameover()
		{
			defaultErrorString = errorString;
			defaultContinueString = continueString;
		}

		public void Update(KeyboardState pKeyboardState, KeyboardState pOldKeyboardState, Random pRandom)
		{
			Keys key = Keys.Enter;

			if (pKeyboardState.IsKeyDown(key) && !pOldKeyboardState.IsKeyDown(key))
			{
				next = true;
			}
			if (next)
			{
				alpha -= 0.01f;
				errorString = alterateString(errorString, pRandom);
				continueString = alterateString(continueString, pRandom);
			}
		}

		public string alterateString(string pString, Random pRandom)
		{
			string newString = "";
			int rndChar = pRandom.Next(0, pString.Length-1);
			string listChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			for (int i = 0; i < pString.Length; i++)
			{
				if (i != rndChar)
				{
					newString += pString[i];
				}
				else
				{
					newString += listChars[pRandom.Next(0,listChars.Length-1)];
				}
			}
			return newString;
		}

		public void reset()
		{
			alpha = 1;
			next = false;
			errorString = defaultErrorString;
			continueString = defaultContinueString;
		}

		public void giveReason(string pReason)
		{
			reason = pReason;
			errorString = defaultErrorString + reason;
		}
		
		public string Draw(SpriteBatch pSpriteBatch, GraphicsDevice pGraphicsDevice,SpriteFont pFont)
		{
			float spacing = 50;
			string result = "";
			Vector2 errorPosition = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2)-spacing/2);
			Vector2 continuePosition = errorPosition + new Vector2(0, spacing*2);
			DrawStringCenter(pSpriteBatch, errorString, pFont, Color.Red * alpha, errorPosition);
			DrawStringCenter(pSpriteBatch, continueString, pFont, Color.Red * alpha, continuePosition);
			if (next && alpha <= 0)
			{
				reset();
				result = "menu";
			}

			return result;
		}

		public void DrawStringCenter(SpriteBatch pSpriteBatch,string pText, SpriteFont pFont, Color pColor, Vector2 pPosition)
		{
			pSpriteBatch.DrawString(pFont, pText, pPosition, Color.Red * alpha, 0, new Vector2(pFont.MeasureString(pText).X / 2, pFont.MeasureString(pText).Y/2), 1f, SpriteEffects.None,0);
		}
		
	}
}
