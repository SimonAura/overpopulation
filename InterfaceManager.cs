using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class InterfaceManager
	{
		List<ClicableElement> list_clicableElements;
		List<PanelJauge> list_panelJauges;
		List<PanelButton> list_panelButtons;
	
		public InterfaceManager()
		{
			list_clicableElements = new List<ClicableElement>();
			list_panelButtons = new List<PanelButton>();
			list_panelJauges = new List<PanelJauge>();
		}

		public string CheckInteraction(Vector2 pMousePosition, bool pHaveClicked, SoundEffect pSoundSwitchOn, SoundEffect pSoundSwitchOff)
		{
			foreach (PanelButton p in list_panelButtons)
			{
				string result = p.CheckInteraction(pMousePosition, pHaveClicked, pSoundSwitchOn, pSoundSwitchOff);
				if (result != "")
				{
					return result;
				}
			}
			foreach (ClicableElement c in list_clicableElements)
			{
				string result = c.CheckInteraction(pMousePosition,pHaveClicked, pSoundSwitchOn, pSoundSwitchOff);
				if (result != "")
				{
					return result;
				}
			}
			return null;
		}

		public void Draw(SpriteBatch pSpriteBatch)
		{
			foreach (ClicableElement c in list_clicableElements)
			{
				c.Draw(pSpriteBatch);
			}
			foreach (PanelJauge p in list_panelJauges)
			{
				p.Draw(pSpriteBatch);
			}
			foreach (PanelButton p in list_panelButtons)
			{
				p.Draw(pSpriteBatch);
			}
		}

		public void Clear()
		{
			list_clicableElements = new List<ClicableElement>();
		}

		public void createButton(SpriteBatch pSpriteBatch, Vector2 pPosition, string pText, string pAction, SpriteFont pFont, string pOrigin, Color pColor, bool pIsInteractable)
		{
			ClicableElement newButton = new ClicableElement(pFont, pText, pPosition, pAction, pColor, pOrigin, pIsInteractable);
			list_clicableElements.Add(newButton);
		}
		public PanelItem createPanelItem(SpriteBatch pSpriteBatch, Vector2 pPosition, string pText, string pAction,SpriteFont pFont, Size2 pSize, string pOrigin, bool pIsInteractable)
		{
			PanelItem newPanelItem = new PanelItem(pFont, pText, pPosition, pAction, new Color(0, 255, 0), pSize, pOrigin, pIsInteractable);
			list_clicableElements.Add(newPanelItem);
			return newPanelItem;
		}
		public PanelJauge createPanelJauge(SpriteBatch pSpriteBatch, Texture2D pTexture, Color pColor, Vector2 pPosition, float pValue, string pOrigin, float pScale)
		{
			PanelJauge newPanelJauge = new PanelJauge(pPosition, pTexture, pColor,pValue,pOrigin,pScale);
			list_panelJauges.Add(newPanelJauge);
			return newPanelJauge;
		}

		public PanelButton createPanelButton(SpriteFont pFont, string pText, Vector2 pPosition, string pAction, string pOrigin, bool pIsInteractable,Texture2D pTexture, Texture2D pOtherTexture,float pScale)
		{
			PanelButton newPanelButton = new PanelButton(pFont, pText, pPosition, pAction, Color.White, pOrigin, pIsInteractable, pTexture, pOtherTexture, pScale);
			list_panelButtons.Add(newPanelButton);
			
			return newPanelButton;
		}
	}
}
