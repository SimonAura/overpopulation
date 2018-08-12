using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;

namespace Overpopulation
{
	public class Introduction
	{
		public float pTimerMilliseconds { get; set; }
		public float defaultCinematicSpeed { get; set; } = 1;
		public float cinematicSpeed { get; set;}
		public float alpha { get; set; }
	
		public Introduction()
		{
			alpha = 1f;
			cinematicSpeed = defaultCinematicSpeed;
		}

		public void reset()
		{
			alpha = 1f;
			cinematicSpeed = defaultCinematicSpeed;
			pTimerMilliseconds = 0;
		}

		public void PrintMirrored(SpriteBatch pSpriteBatch, GraphicsDevice pGraphicsDevice, SpriteFont pFont, string pText, Vector2 pPosition, Color pColor)
		{
			pSpriteBatch.DrawString(pFont, pText, new Vector2(pGraphicsDevice.Viewport.Width/2, pGraphicsDevice.Viewport.Height / 2), pColor*alpha, 0, new Vector2(pFont.MeasureString(pText).X / 2, pFont.MeasureString(pText).Y/2), 1f,SpriteEffects.None,0);
			pSpriteBatch.DrawString(pFont, pText, new Vector2(pGraphicsDevice.Viewport.Width / 2, (pGraphicsDevice.Viewport.Height / 2) + pFont.MeasureString(pText).Y / 2 - 3), pColor * (alpha/2), 0, new Vector2(pFont.MeasureString(pText).X / 2, 0), 1f, SpriteEffects.FlipVertically,0);
			
		}

		public bool CheckInput(KeyboardState pKeyboardState, KeyboardState pOldKeyBoardState, Keys pKeys, SoundEffect pSoundEffect)
		{
			if (pKeyboardState.IsKeyDown(pKeys) && !pOldKeyBoardState.IsKeyDown(pKeys))
			{
				pSoundEffect.Play();
				return true;
			}
			else
			{
				return false;
			}
		}

		public string Draw(SpriteBatch pSpriteBatch, GameState pGameState, KeyboardState pKeyboardState, KeyboardState pOldKeyBoardState, GraphicsDevice pGraphicsDevice, SpriteFont pFont, SpriteFont pOtherFont, SpriteFont pSmallFont, SoundEffect pKeySound, SoundEffectInstance pAlarmSound)
		{
			float space = 50;

			if (CheckInput(pKeyboardState, pOldKeyBoardState, Keys.Escape, pKeySound) && pTimerMilliseconds < 33500)
			{
				pTimerMilliseconds = 33500;
				cinematicSpeed = defaultCinematicSpeed;
			}


			Vector2 center = new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height / 2);
			if (pTimerMilliseconds < 5000)
			{
				alpha = 1 - (pTimerMilliseconds / 5000);
				string yearText = "YEAR 2458";
				string skipText = "Press escape to skip the cinematic";
				PrintMirrored(pSpriteBatch, pGraphicsDevice, pFont, yearText, new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height / 2), Color.White);
				pSpriteBatch.DrawString(pSmallFont, skipText, new Vector2(30, pGraphicsDevice.Viewport.Height - space), Color.White, 0, new Vector2(0, pSmallFont.MeasureString(skipText).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 5000 && pTimerMilliseconds < 8000)
			{
				string introText1 = "The human race faces major risks.";
				pSpriteBatch.DrawString(pOtherFont, introText1, center, Color.White, 0, new Vector2(pOtherFont.MeasureString(introText1).X / 2, pOtherFont.MeasureString(introText1).Y / 2), 1f, SpriteEffects.None, 0);

			}
			else if (pTimerMilliseconds > 8000 && pTimerMilliseconds < 12000)
			{
				string introText2 = "Each year the population increases";
				string introText3 = "Food is scarce, violence explodes.";
				pSpriteBatch.DrawString(pOtherFont, introText2, center - new Vector2(0, 25), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText2).X / 2, pOtherFont.MeasureString(introText2).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText3, center + new Vector2(0, 25), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText3).X / 2, pOtherFont.MeasureString(introText2).Y / 2), 1f, SpriteEffects.None, 0);

			}
			else if (pTimerMilliseconds > 12000 && pTimerMilliseconds < 20000)
			{
				string introText4 = "The Earth cannot support more";
				string introText5 = "people. Aerospace forces have";
				string introText6 = "designed rockets capable of";
				string introText7 = "travelling at the speed of light";
				string introText8 = "giving the Earth a chance.";
				string introText9 = "Find a habitable planet.";
				string introText10 = "send a colony, save humanity...";
				Vector2 startPos = center - new Vector2(0, 150);
				pSpriteBatch.DrawString(pOtherFont, introText4, startPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(introText4).X / 2, pOtherFont.MeasureString(introText4).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText5, startPos + new Vector2(0, space), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText5).X / 2, pOtherFont.MeasureString(introText5).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText6, startPos + new Vector2(0, space * 2), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText6).X / 2, pOtherFont.MeasureString(introText6).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText7, startPos + new Vector2(0, space * 3), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText7).X / 2, pOtherFont.MeasureString(introText7).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText8, startPos + new Vector2(0, space * 4), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText8).X / 2, pOtherFont.MeasureString(introText8).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText9, startPos + new Vector2(0, space * 5), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText9).X / 2, pOtherFont.MeasureString(introText9).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText10, startPos + new Vector2(0, space * 6), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText10).X / 2, pOtherFont.MeasureString(introText10).Y / 2), 1f, SpriteEffects.None, 0);

			}
			else if (pTimerMilliseconds > 20000 && pTimerMilliseconds < 22000)
			{
				string text = "7:59 a.m.";
				pSpriteBatch.DrawString(pFont, text, center, Color.Red, 0, new Vector2(pFont.MeasureString(text).X / 2, pFont.MeasureString(text).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 22000 && pTimerMilliseconds < 24000)
			{
				string text = "8:00 a.m.";
				pAlarmSound.Play();
				pSpriteBatch.DrawString(pFont, text, center, Color.Red, 0, new Vector2(pFont.MeasureString(text).X / 2, pFont.MeasureString(text).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 24000 && pTimerMilliseconds < 27000)
			{
				pAlarmSound.Stop();
				string introText9 = "Good morning Jack.";
				string introText10 = "There are currently 9 billion people";
				string introText11 = "on Earth. Mr. Stanford is waiting";
				string introText12 = "for you in his office. Don't keep him";
				string introText13 = "waiting, it's important.";
				string introText14 = "PRESS ENTER TO CONTINUE";
				cinematicSpeed = 0;
				if (CheckInput(pKeyboardState, pOldKeyBoardState, Keys.Enter, pKeySound))
				{
					pTimerMilliseconds = 27000;
					cinematicSpeed = defaultCinematicSpeed;
				}
				Vector2 starPos = center - new Vector2(0, 100);
				pSpriteBatch.DrawString(pOtherFont, introText9, starPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(introText9).X / 2, pOtherFont.MeasureString(introText9).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText10, starPos + new Vector2(0, space), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText10).X / 2, pOtherFont.MeasureString(introText10).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText11, starPos + new Vector2(0, space * 2), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText11).X / 2, pOtherFont.MeasureString(introText11).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText12, starPos + new Vector2(0, space * 3), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText12).X / 2, pOtherFont.MeasureString(introText12).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText13, starPos + new Vector2(0, space * 4), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText13).X / 2, pOtherFont.MeasureString(introText13).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText14, starPos + new Vector2(0, space * 6), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText14).X / 2, pOtherFont.MeasureString(introText14).Y / 2), 1f, SpriteEffects.None, 0);

			}
			else if (pTimerMilliseconds > 27000 && pTimerMilliseconds < 30000)
			{
				string introText14 = "Good morning, Jack.";
				string introText15 = "Today is a very big day, we have";
				string introText16 = "identified a colonizable system";
				string introText17 = "with water, and oxygen, in short";
				string introText18 = "enough to disgorge our planet.";
				string introText19 = "Isn't that great ? Get to";
				string introText20 = "work. Mankind will not";
				string introText21 = "wait any longer...";
				string introText22 = "PRESS ENTER TO CONTINUE";


				cinematicSpeed = 0;
				if (CheckInput(pKeyboardState, pOldKeyBoardState, Keys.Enter, pKeySound))
				{
					pTimerMilliseconds = 30000;
					cinematicSpeed = defaultCinematicSpeed;
				}

				Vector2 starPos = center - new Vector2(0, 200);
				pSpriteBatch.DrawString(pOtherFont, introText14, starPos, Color.White, 0, new Vector2(pOtherFont.MeasureString(introText14).X / 2, pOtherFont.MeasureString(introText14).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText15, starPos + new Vector2(0, space), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText15).X / 2, pOtherFont.MeasureString(introText15).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText16, starPos + new Vector2(0, space * 2), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText16).X / 2, pOtherFont.MeasureString(introText16).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText17, starPos + new Vector2(0, space * 3), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText17).X / 2, pOtherFont.MeasureString(introText17).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText18, starPos + new Vector2(0, space * 4), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText18).X / 2, pOtherFont.MeasureString(introText18).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText19, starPos + new Vector2(0, space * 5), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText19).X / 2, pOtherFont.MeasureString(introText19).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText20, starPos + new Vector2(0, space * 6), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText20).X / 2, pOtherFont.MeasureString(introText20).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText21, starPos + new Vector2(0, space * 7), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText21).X / 2, pOtherFont.MeasureString(introText21).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, introText22, starPos + new Vector2(0, space * 9), Color.White, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);

			}
			else if (pTimerMilliseconds > 30000 && pTimerMilliseconds < 30500)
			{
				string introText22 = "System scanner initialized.";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 30500 && pTimerMilliseconds < 31000)
			{
				string introText22 = "System scanner initialized..";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 31000 && pTimerMilliseconds < 31500)
			{
				string introText22 = "System scanner initialized...";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 31500 && pTimerMilliseconds < 32000)
			{
				string introText22 = "System scanner initialized.";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 32000 && pTimerMilliseconds < 32500)
			{
				string introText22 = "System scanner initialized..";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 32500 && pTimerMilliseconds < 33000)
			{
				string introText22 = "System scanner initialized...";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 33000 && pTimerMilliseconds < 33500)
			{
				string introText22 = "System scanner initialized";
				pSpriteBatch.DrawString(pOtherFont, introText22, center, Color.Green, 0, new Vector2(pOtherFont.MeasureString(introText22).X / 2, pOtherFont.MeasureString(introText22).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 33500 && pTimerMilliseconds < 35000)
			{
				string introText23 = "IDENTIFIED SYSTEM : " + pGameState.currentSystem.name;
				pSpriteBatch.DrawString(pOtherFont, introText23, center, Color.Green, 0, new Vector2(pOtherFont.MeasureString(introText23).X / 2, pOtherFont.MeasureString(introText23).Y / 2), 1f, SpriteEffects.None, 0);
			}
			else if (pTimerMilliseconds > 35000 && pTimerMilliseconds < 37000)
			{
				string tutoText1 = "PILOTAGE MANUAL";
				string tutoText2 = "[1] TURN ON ELECTRICITY";
				string tutoText3 = "[2] FUEL";
				string tutoText4 = "[3] OXYGENE";
				string tutoText5 = "[4] COOL THE ROCKET";
				string tutoText6 = "[5] STABILIZE";
				string tutoText7 = "PRESS ENTER TO START";

				cinematicSpeed = 0;
				if (CheckInput(pKeyboardState, pOldKeyBoardState, Keys.Enter, pKeySound))
				{
					cinematicSpeed = defaultCinematicSpeed;
					reset();
					return "system";
				}
				
				Vector2 spacing = new Vector2(0, 50);
				pSpriteBatch.DrawString(pOtherFont, tutoText1, center-spacing*3, Color.Red, 0, new Vector2(pOtherFont.MeasureString(tutoText1).X / 2, pOtherFont.MeasureString(tutoText1).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, tutoText2, center-spacing, Color.Red, 0, new Vector2(pOtherFont.MeasureString(tutoText2).X / 2, pOtherFont.MeasureString(tutoText2).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, tutoText3, center, Color.Red, 0, new Vector2(pOtherFont.MeasureString(tutoText3).X / 2, pOtherFont.MeasureString(tutoText3).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, tutoText4, center+spacing, Color.Red, 0, new Vector2(pOtherFont.MeasureString(tutoText4).X / 2, pOtherFont.MeasureString(tutoText4).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, tutoText5, center+spacing*2, Color.Red, 0, new Vector2(pOtherFont.MeasureString(tutoText5).X / 2, pOtherFont.MeasureString(tutoText5).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pOtherFont, tutoText6, center+spacing*3, Color.Red, 0, new Vector2(pOtherFont.MeasureString(tutoText6).X / 2, pOtherFont.MeasureString(tutoText6).Y / 2), 1f, SpriteEffects.None, 0);
				pSpriteBatch.DrawString(pSmallFont, tutoText7, center+spacing*5, Color.White, 0, new Vector2(pSmallFont.MeasureString(tutoText7).X / 2, pSmallFont.MeasureString(tutoText7).Y / 2), 1f, SpriteEffects.None, 0);
				
			}
			return null;
			
		}
		
		public void Update(GameTime pGameTime)
		{
			pTimerMilliseconds += pGameTime.ElapsedGameTime.Milliseconds * cinematicSpeed;
		}
	}
}
