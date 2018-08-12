using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class SystemGenerator
	{
		SystemSolar currentSystemSolar;
		List<Vector2> list_backgroundStars;
		InterfaceManager myInterfaceManager;
	
		public SystemGenerator()
		{
			list_backgroundStars = new List<Vector2>();
			myInterfaceManager = new InterfaceManager();
		}

		public string GenerateSystemName(Random pRandom)
		{
			string name = "";
			
			char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789".ToCharArray();
			int count_chars = pRandom.Next(8, 10);
			for (int i = 0; i < count_chars; i++)
			{
				name = name + chars[pRandom.Next(chars.Length)];
			}
		
			return name;
		}

		public void GenerateSystem(Random pRandom, GraphicsDevice pGraphicsDevice, GameState pGameState)
		{
			String name = GenerateSystemName(pRandom);
			
			float distance = pRandom.Next(5, 100);

			SystemSolar newSystem = new SystemSolar(name, distance,pRandom, pGraphicsDevice);
			currentSystemSolar = newSystem;

			pGameState.currentSystem = newSystem;

			int count_stars = pRandom.Next(100, 200);
			for (int i = 0; i < count_stars; i++)
			{
				Vector2 newStarPosition = new Vector2(pRandom.Next(0,pGraphicsDevice.Viewport.Width), pRandom.Next(0, pGraphicsDevice.Viewport.Height));
				list_backgroundStars.Add(newStarPosition);
			}
			
		}

		public string CheckInteraction(Vector2 pMousePosition, GameState pGameState, bool pHaveClicked, SoundEffect pSoundEffect1, SoundEffect pSoundEffect2)
		{
			if (currentSystemSolar.CheckInteraction(pMousePosition, pGameState) == "selection")
			{
				{
					myInterfaceManager.Clear();
				}
			}
			if (myInterfaceManager.CheckInteraction(pMousePosition, pHaveClicked, pSoundEffect1,pSoundEffect2) == "launch")
			{
				Close();
				return "launch";
			}
			return null;
		}

		public void Close()
		{
			currentSystemSolar = null;
			list_backgroundStars = new List<Vector2>();
			myInterfaceManager.Clear();
		}

		public void Update()
		{
			currentSystemSolar.Update();
		}

		public void Draw(SpriteBatch pSpriteBatch, SpriteFont pFont)
		{
			foreach (Vector2 pos in list_backgroundStars)
			{
				pSpriteBatch.DrawPoint(pos, Color.White, 1);
			}
			currentSystemSolar.Draw(pSpriteBatch, pFont, myInterfaceManager);
			myInterfaceManager.Draw(pSpriteBatch);
		}
		
	}
}
