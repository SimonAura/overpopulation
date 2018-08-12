using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Overpopulation
{
	public class End
	{
		public ParticleManager myStarManager { get; set; }
		public float pTimerMilliseconds { get; set; }
		public float currentCinematicSpeed { get; set; }
		public float defaultCinematicSpeed { get; set; }
		public float titleScale { get; set; }
		public float maxTitleScale { get; set; }
		public float creditScale { get; set; }
		public float maxCreditScale { get; set;}
		public string choice { get; set; }
		string result;

		public End()
		{
			choice = "";
			defaultCinematicSpeed = 1;
			currentCinematicSpeed = defaultCinematicSpeed;
			maxTitleScale = 0.95f;
			maxCreditScale = 0.55f;
			myStarManager = new ParticleManager(new Vector2(0,0));
		}

		public bool CheckInput(KeyboardState pKeyboardState, KeyboardState pOldKeyboardState, Keys pKey)
		{
			if (pKeyboardState.IsKeyDown(pKey) && !pOldKeyboardState.IsKeyDown(pKey))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Update(KeyboardState pKeyboardState, KeyboardState pOldKeyboardState, GameTime pGameTime)
		{
			pTimerMilliseconds += pGameTime.ElapsedGameTime.Milliseconds * currentCinematicSpeed;
			myStarManager.Update();
		}

		public void reset()
		{
			titleScale = 0;
			creditScale = 0;
			pTimerMilliseconds = 0;
			myStarManager.clear();
		}

		public string Draw(SpriteBatch pSpriteBatch, Random pRandom, GraphicsDevice pGraphicsDevice, SpriteFont pFontTitle, SpriteFont pFont, SpriteFont pOtherFont, SpriteFont pSmallFont, KeyboardState pKeyboardState, KeyboardState pOldKeyboardState, Texture2D pTextureStar)
		{
			myStarManager.Draw(pSpriteBatch);
			if (pTimerMilliseconds > 0 && pTimerMilliseconds < 1000)
			{
				string endText1 = " You enter Mr. Stanford's office.";
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height / 2);

				pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 1000 && pTimerMilliseconds < 2000)
			{
				string endText1 = " You enter Mr. Stanford's office..";
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height / 2);

				pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 2000 && pTimerMilliseconds < 3000)
			{
				string endText1 = " You enter Mr. Stanford's office...";
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height / 2);

				pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 3000 && pTimerMilliseconds < 5000)
			{
				string endText1 = "He's waiting for you.";
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height / 2);

				pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 5000 && pTimerMilliseconds < 10000)
			{
				string endText1 = "Hello, Jack. I'm more than satisfied";
				string endText2 = "with your results you've established";
				string endText3 = "colonies on three planets.That's";
				string endText4 = "impressive, We will overcome";
				string endText5 = "overcrowding quickly.";
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) - 100);
				Vector2 spacing = new Vector2(0, 50);
				pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, endText2, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText2).X / 2, pOtherFont.MeasureString(endText2).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, endText3, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText3).X / 2, pOtherFont.MeasureString(endText3).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, endText4, startPos + spacing * 3, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText4).X / 2, pOtherFont.MeasureString(endText4).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, endText5, startPos + spacing * 4, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText5).X / 2, pOtherFont.MeasureString(endText5).Y / 2), 1f, SpriteEffects.None, 0);

			}
			else if (pTimerMilliseconds > 10000 && pTimerMilliseconds < 15000)
			{
				string endText1 = "I can trust you, can't I?";
				string endText2 = "PRESS Y TO SAY YES";
				string endText3 = "PRESS N TO SAY NO";
				currentCinematicSpeed = 0;
				if (CheckInput(pKeyboardState, pOldKeyboardState, Keys.Y))
				{
					currentCinematicSpeed = defaultCinematicSpeed;
					pTimerMilliseconds = 15000;
					choice = "yes";
				}
				else if (CheckInput(pKeyboardState, pOldKeyboardState, Keys.N))
				{
					currentCinematicSpeed = defaultCinematicSpeed;
					pTimerMilliseconds = 15000;
					choice = "no";
				}
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) - 50);
				Vector2 spacing = new Vector2(0, 50);
				pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pSmallFont, endText2, startPos + spacing * 2, Color.Green, 0, new Vector2(pSmallFont.MeasureString(endText2).X / 2, pSmallFont.MeasureString(endText2).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pSmallFont, endText3, startPos + spacing * 3, Color.Red, 0, new Vector2(pSmallFont.MeasureString(endText3).X / 2, pSmallFont.MeasureString(endText3).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 15000 && pTimerMilliseconds < 16000)
			{
				string endText1 = "Nice to have you.";
				string endText2 = "I have other things for you";
				string endText3 = "much more interesting..";
				string endText4 = "You don't know what you're";
				string endText5 = " missing. I will find someone";
				string endText6 = "more qualified for the next";
				string endText7 = "tasks that will change the world.";
				
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) - 50);
				Vector2 spacing = new Vector2(0, 50);
				if (choice == "yes")
				{
					pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText2, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText2).X / 2, pOtherFont.MeasureString(endText2).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText3, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText3).X / 2, pOtherFont.MeasureString(endText3).Y / 2), 1f, SpriteEffects.None, 0);
				}
				else
				{
					pSpriteBatch.DrawString(pOtherFont, endText4, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText4).X / 2, pOtherFont.MeasureString(endText4).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText5, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText5).X / 2, pOtherFont.MeasureString(endText5).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText6, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText6).X / 2, pOtherFont.MeasureString(endText6).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText7, startPos + spacing * 3, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText7).X / 2, pOtherFont.MeasureString(endText7).Y / 2), 1f, SpriteEffects.None, 0);
				}
			}
			else if (pTimerMilliseconds > 16000 && pTimerMilliseconds < 17000)
			{
				string endText1 = "Nice to have you.";
				string endText2 = "I have other things for you";
				string endText3 = "much more interesting..";
				string endText4 = "You don't know what you're";
				string endText5 = " missing. I will find someone";
				string endText6 = "more qualified for the next";
				string endText7 = "tasks that will change the world..";
				
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) - 50);
				Vector2 spacing = new Vector2(0, 50);
				if (choice == "yes")
				{
					pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText2, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText2).X / 2, pOtherFont.MeasureString(endText2).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText3, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText3).X / 2, pOtherFont.MeasureString(endText3).Y / 2), 1f, SpriteEffects.None, 0);
				}
				else
				{
					pSpriteBatch.DrawString(pOtherFont, endText4, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText4).X / 2, pOtherFont.MeasureString(endText4).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText5, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText5).X / 2, pOtherFont.MeasureString(endText5).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText6, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText6).X / 2, pOtherFont.MeasureString(endText6).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText7, startPos + spacing * 3, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText7).X / 2, pOtherFont.MeasureString(endText7).Y / 2), 1f, SpriteEffects.None, 0);
				}
			}
			else if (pTimerMilliseconds > 17000 && pTimerMilliseconds < 18000)
			{
				string endText1 = "Nice to have you.";
				string endText2 = "I have other things for you";
				string endText3 = "much more interesting...";
				
				string endText4 = "You don't know what you're";
				string endText5 = " missing. I will find someone";
				string endText6 = "more qualified for the next";
				string endText7 = "tasks that will change the world...";
				
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) - 50);
				Vector2 spacing = new Vector2(0, 50);
				if (choice == "yes")
				{
					pSpriteBatch.DrawString(pOtherFont, endText1, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText1).X / 2, pOtherFont.MeasureString(endText1).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText2, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText2).X / 2, pOtherFont.MeasureString(endText2).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText3, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText3).X / 2, pOtherFont.MeasureString(endText3).Y / 2), 1f, SpriteEffects.None, 0);
				}
				else
				{
					pSpriteBatch.DrawString(pOtherFont, endText4, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText4).X / 2, pOtherFont.MeasureString(endText4).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText5, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText5).X / 2, pOtherFont.MeasureString(endText5).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText6, startPos + spacing * 2, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText6).X / 2, pOtherFont.MeasureString(endText6).Y / 2), 1f, SpriteEffects.None, 0);
					pSpriteBatch.DrawString(pOtherFont, endText7, startPos + spacing * 3, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText7).X / 2, pOtherFont.MeasureString(endText7).Y / 2), 1f, SpriteEffects.None, 0);
				}
			}
			else if (pTimerMilliseconds > 18000 && pTimerMilliseconds < 25000)
			{
				string endText1 = "OVERPOPULATION";
				string endText2 = "MADE BY SIMON AURA--SCUSSEL";
				myStarManager.addParticleStar(pRandom, pTextureStar, pGraphicsDevice, 0.1f);
				if (titleScale < maxTitleScale)
				{
					titleScale += 0.01f;
				}
				else
				{
					if (creditScale < maxCreditScale)
					{
						creditScale += 0.01f;
					}
				}
				Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) - 30);
				Vector2 spacing = new Vector2(0, 80);
				pSpriteBatch.DrawString(pFontTitle, endText1, startPos, Color.White, 0, new Vector2(pFontTitle.MeasureString(endText1).X / 2, pFontTitle.MeasureString(endText1).Y / 2), titleScale, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, endText2, startPos + spacing, Color.White, 0, new Vector2(pOtherFont.MeasureString(endText2).X / 2, pOtherFont.MeasureString(endText2).Y / 2), creditScale, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 25000)
			{
				return "menu";
			}
			
			return result;
		}
		
	}
}