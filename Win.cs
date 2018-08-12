using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Overpopulation
{
	public class Win
	{

		ParticleManager myStarManager;
		float alpha;
		string result = "";

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

		public void reset()
		{
			result = "";
			myStarManager.clear();
			alpha = 1f;
		}

		public Win(GraphicsDevice pGraphicsDevice)
		{
			alpha = 1f;
			myStarManager = new ParticleManager(new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height/2));
		}
		
		public void Update(KeyboardState pKeyboardState, KeyboardState pOldKeyboardState, Random pRandom, Texture2D pStarTexture, GraphicsDevice pGraphicsDevice, SoundEffect pKeySound, GameState pGameState)
		{
			myStarManager.addParticleStar(pRandom, pStarTexture, pGraphicsDevice, 0.1f);
			myStarManager.Update();
			if (CheckInput(pKeyboardState, pOldKeyboardState, Keys.Enter, pKeySound))
			{
				if (pGameState.rocketArrived < pGameState.targetRocketArrived)
				{
					result = "system";
				}
				else
				{
					result = "end";
				}
			}
			if (result == "system" || result == "end")
			{
				alpha -= 0.1f;
			}
		}

		public string Draw(SpriteBatch pSpriteBatch, GraphicsDevice pGraphicsDevice, SpriteFont pFont, SpriteFont pOtherFont, SpriteFont pSmallFont, GameState pGameState, InterfaceManager pInterfaceManager)
		{
			myStarManager.Draw(pSpriteBatch);
			string sTitle = "-MISSION ACCOMPLISHED-";
			string sTotal = "-" + pGameState.rocketHumansCapacity + " HUMANS";
			string sRemaining = pGameState.rocketArrived + "/" + pGameState.targetRocketArrived + " ROCKETS ARRIVED";
			string sContinue = "PRESS ENTER TO CONTINUE";

			Vector2 spacing = new Vector2(0, 100);
			
			Vector2 startPos = new Vector2(pGraphicsDevice.Viewport.Width/2,(pGraphicsDevice.Viewport.Height/2)-200);
			pSpriteBatch.DrawString(pFont, sTitle, startPos, Color.Green*alpha, 0, new Vector2(pFont.MeasureString(sTitle).X / 2, pFont.MeasureString(sTitle).Y / 2), 1f, SpriteEffects.None, 0);
			
			pSpriteBatch.DrawString(pOtherFont, sTotal, startPos + spacing * 1.5f, Color.White*alpha, 0, new Vector2(pOtherFont.MeasureString(sTotal).X / 2, pOtherFont.MeasureString(sTotal).Y / 2), 1f, SpriteEffects.None, 0);

			pSpriteBatch.DrawString(pOtherFont, sRemaining, startPos + spacing * 2, Color.White * alpha, 0, new Vector2(pOtherFont.MeasureString(sRemaining).X / 2, pOtherFont.MeasureString(sRemaining).Y / 2), 1f, SpriteEffects.None, 0);

			pSpriteBatch.DrawString(pSmallFont, sContinue, startPos + spacing * 3, Color.White * alpha, 0, new Vector2(pSmallFont.MeasureString(sContinue).X / 2, pSmallFont.MeasureString(sContinue).Y / 2), 1f, SpriteEffects.None, 0);
			
			float radius = 450f;
			pGameState.currentPlanet.position = new Vector2(pGraphicsDevice.Viewport.Width / 2, pGraphicsDevice.Viewport.Height + radius / 1.2f);
			pGameState.currentPlanet.radius = radius;
			pGameState.currentPlanet.DrawGlow(pSpriteBatch);
			pGameState.currentPlanet.Draw(pSpriteBatch, pFont, pInterfaceManager);
			pGameState.currentPlanet.displayOrbit = false;
			pGameState.currentPlanet.displayHUD = false;
			if (alpha <= 0)
			{
				return result;
			}
			else
			{
				return null;
			}
		}
		
	
	}
}