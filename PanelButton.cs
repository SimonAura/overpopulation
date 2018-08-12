using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Overpopulation
{
	public class PanelButton : ClicableElement
	{
		public Texture2D texture { get; set;}
		Texture2D otherTexture { get; set; }
		public bool isOn { get; set; }
		public float scale { get; set;}
		
		public PanelButton(SpriteFont pFont, string pText, Vector2 pPosition, string pAction, Color pColor, string pOrigin, bool pIsInteractable,Texture2D pTexture, Texture2D pOtherTexture,float pScale) : base(pFont,pText,pPosition,pAction,pColor,pOrigin,pIsInteractable)
		{
			texture = pTexture;
			otherTexture = pOtherTexture;
			scale = pScale;
			size = new Size2(texture.Width*scale, texture.Height*scale);
		}

		public override string CheckInteraction(Vector2 pMousePosition, bool pHaveClicked, SoundEffect pSoundSwitchOn, SoundEffect pSoundSwitchOff)
		{
			string result = base.CheckInteraction(pMousePosition, pHaveClicked,pSoundSwitchOn,pSoundSwitchOff);
			if (result == "switch")
			{
				if (isOn == false)
				{
					pSoundSwitchOn.Play();
				}
				else
				{
					pSoundSwitchOff.Play();
				}
				ForceInteraction();
				return "switch";
			}
			return "";
		}

		public void ForceInteraction()
		{
				isOn = !isOn;
				Texture2D tamp = texture;
				texture = otherTexture;
				otherTexture = tamp;
		}
		
		public override void Draw(SpriteBatch pSpriteBatch)
		{
			pSpriteBatch.Draw(texture, position, null, null, origin, 0, new Vector2(scale,scale),color, SpriteEffects.None,0);
		}
	}
}