using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.Sprites;

namespace Overpopulation
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Introduction myIntroduction;
		Win myWin;
		End myEnd;
		Gameover myGameover;
		//-----------------------------
		GameState myGameState;
		// -- Graphics
		SpriteFont fontDefault;
		SpriteFont fontTitle;
		SpriteFont fontMenu;
		SpriteFont fontIntro;
		Random myRandom;
		SystemGenerator mySystemGenerator;
		BasicEffect defaultEffect;
		Texture2D img_launchPad;
		Texture2D img_rocket;
		Texture2D img_controlpanel;
		Texture2D img_switchOn;
		Texture2D img_switchOff;
		Texture2D img_leverOn;
		Texture2D img_leverOff;
		Texture2D img_jauge;
		Texture2D img_ledOn;
		Texture2D img_ledOff;
		Texture2D img_particleFire;
		Texture2D img_background;
		Texture2D img_star;
		Texture2D img_jaugeInverted;
		Texture2D img_fragment1;
		Texture2D img_fragment2;
		Texture2D img_fragment3;
		Texture2D img_fragment4;
		Texture2D img_fragment5;
		Texture2D img_fragment6;
		Texture2D img_fragment7;
		Texture2D[] fragmentArray;
		Texture2D img_backgroundsky;
		Texture2D img_cursor;
		ParticleManager myParticleStarManager;
		float resolutionFactor;
		float panelHeight;
		// -- Gameplay
		string currentState;
		MouseState oldMouseState;
		KeyboardState currentKeyboardState;
		KeyboardState oldKeyboardState;
		InterfaceManager myInterfaceManager;
		PanelItem panel_countHumans;
		PanelItem panel_planetName;
		PanelItem panel_planetTemperature;
		PanelItem panel_rocketAltitude;
		PanelItem panel_textPlanet;
		PanelItem panel_textRocket;
		PanelItem panel_stabilized;
		PanelJauge panel_fuelJauge;
		PanelJauge panel_tempJauge;
		PanelJauge panel_oxyJauge;
		PanelButton panel_buttonRefuel;
		PanelButton panel_buttonCool;
		PanelButton panel_buttonElectricity;
		PanelButton panel_buttonOxygene;
		PanelButton panel_lever;
		PanelButton panel_gpsLever;
		Rocket myRocket;
		Vector2 defaultRocketPosition;
		// -- MENU
		ClicableElement menu_start;
		ClicableElement menu_settings;
		ClicableElement menu_exit;
		ClicableElement settings_soundOn;
		ClicableElement settings_soundOff;
		ClicableElement settings_musicOn;
		ClicableElement settings_musicOff;
		ClicableElement settings_exit;
		//-- GAMEOVER
		float timerGameOver;
		float maxTimerGameOver = 4;
		// -- AUDIO
		SoundEffect sound_clic;
		SoundEffect sound_engine;
		SoundEffect sound_explosion;
		SoundEffect sound_refuel;
		SoundEffect sound_air;
		SoundEffect sound_music;
		SoundEffect sound_cool;
		SoundEffect sound_alarm;
		SoundEffect sound_key;
		SoundEffect sound_switchOn;
		SoundEffect sound_switchOff;
		SoundEffectInstance sound_refuelInstance;
		SoundEffectInstance sound_airInstance;
		SoundEffectInstance sound_musicInstance;
		SoundEffectInstance sound_coolInstance;
		SoundEffectInstance sound_alarmInstance;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";				
			currentState = "menu";
			IsMouseVisible = false;
			this.Window.Title = "OVERPOPULATION LD#42 | SIMON AURA SCUSSEL |";
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 600;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			resolutionFactor = (float)GraphicsDevice.Viewport.Width / 1920;
			//TODO: use this.Content to load your game content here 
			
			myIntroduction = new Introduction();
			myGameover = new Gameover();
			myWin = new Win(GraphicsDevice);
			myEnd = new End();

			myGameState = new GameState();
			myGameState.init("normal");

			mySystemGenerator = new SystemGenerator();
			myRandom = new Random();

			myInterfaceManager = new InterfaceManager();

			fontDefault = Content.Load<SpriteFont>("defaultFont");
			fontTitle = Content.Load<SpriteFont>("titleFont");
			fontMenu = Content.Load<SpriteFont>("menuFont");
			fontIntro = Content.Load<SpriteFont>("introFont");

			defaultEffect = new BasicEffect(GraphicsDevice);

			// -- LOAD ALL IMAGES
			img_launchPad = Content.Load<Texture2D>("launchpad");
			img_rocket = Content.Load<Texture2D>("rocket");
			img_controlpanel = Content.Load<Texture2D>("controlpanel");
			img_jauge = Content.Load<Texture2D>("jauge");
			img_ledOn = Content.Load<Texture2D>("greenlight");
			img_ledOff = Content.Load<Texture2D>("redlight");
			img_leverOff = Content.Load<Texture2D>("leverOff");
			img_leverOn = Content.Load<Texture2D>("leverOn");
			img_switchOff = Content.Load<Texture2D>("switchOff");
			img_switchOn = Content.Load<Texture2D>("switchOn");
			img_particleFire = Content.Load<Texture2D>("particle");
			img_background = Content.Load<Texture2D>("background");
			img_star = Content.Load<Texture2D>("star");
			img_jaugeInverted = Content.Load<Texture2D>("jaugeinverted");
			img_fragment1 = Content.Load<Texture2D>("fragment1");
			img_fragment2 = Content.Load<Texture2D>("fragment2");
			img_fragment3 = Content.Load<Texture2D>("fragment3");
			img_fragment4 = Content.Load<Texture2D>("fragment4");
			img_fragment5 = Content.Load<Texture2D>("fragment5");
			img_fragment6 = Content.Load<Texture2D>("fragment6");
			img_fragment7 = Content.Load<Texture2D>("fragment7");
			fragmentArray = new Texture2D[7];
			fragmentArray[0] = img_fragment1;
			fragmentArray[1] = img_fragment2;
			fragmentArray[2] = img_fragment3;
			fragmentArray[3] = img_fragment4;
			fragmentArray[4] = img_fragment5;
			fragmentArray[5] = img_fragment6;
			fragmentArray[6] = img_fragment7;
			img_backgroundsky = Content.Load<Texture2D>("backgroundsky");
			img_cursor = Content.Load <Texture2D>("White");
			MouseCursor.FromTexture2D(img_cursor, 0, 0);
			//-- LOAD ALL SOUNDS
			sound_clic = Content.Load<SoundEffect>("clic");
			sound_engine = Content.Load<SoundEffect>("engine");
			sound_refuel = Content.Load<SoundEffect>("refuel");
			sound_explosion = Content.Load<SoundEffect>("explosion");
			sound_air = Content.Load<SoundEffect>("air");
			sound_music = Content.Load<SoundEffect>("music");
			sound_cool = Content.Load<SoundEffect>("cool");
			sound_key = Content.Load<SoundEffect>("key");
			sound_alarm = Content.Load<SoundEffect>("alarm");
			sound_switchOn = Content.Load<SoundEffect>("sd_switchOn");
			sound_switchOff = Content.Load<SoundEffect>("sd_switchOff");
			
			sound_refuelInstance = sound_refuel.CreateInstance();
			sound_airInstance = sound_air.CreateInstance();
			sound_musicInstance = sound_music.CreateInstance();
			sound_musicInstance.IsLooped = true;
			sound_coolInstance = sound_cool.CreateInstance();
			sound_alarmInstance = sound_alarm.CreateInstance();
			InitMenuInterface();

			panelHeight = GraphicsDevice.Viewport.Height - img_controlpanel.Height * resolutionFactor;
			myParticleStarManager = new ParticleManager(new Vector2(GraphicsDevice.Viewport.Width/2,GraphicsDevice.Viewport.Height/2));

			defaultRocketPosition = new Vector2(GraphicsDevice.Viewport.Width / 2, panelHeight - img_launchPad.Height + 8);
			InitGameplayInterface();
			
		}

		public void reset()
		{
			timerGameOver = 0;
			myGameState.init("normal");
			if (panel_lever.isOn)
				panel_lever.ForceInteraction();
			if (panel_buttonCool.isOn)
				panel_buttonCool.ForceInteraction();
			if (panel_buttonElectricity.isOn)
				panel_buttonElectricity.ForceInteraction();
			if (panel_gpsLever.isOn)
				panel_gpsLever.ForceInteraction();
			if (panel_buttonOxygene.isOn)
				panel_buttonOxygene.ForceInteraction();
			if (panel_buttonRefuel.isOn)
				panel_buttonRefuel.ForceInteraction();
		}

		public void InitMenuInterface()
		{
			float spacing = 80;
			Vector2 UIposition = new Vector2(35, 180);
			menu_start = new ClicableElement(fontMenu, "- START", UIposition, "start", Color.White, "default", true);
			settings_musicOn = new ClicableElement(fontMenu, "- MUSIC : ON", UIposition, "musicoff", Color.White, "default", true);
			settings_musicOff = new ClicableElement(fontMenu, "- MUSIC : OFF", UIposition, "musicon", Color.White, "default", true);
			UIposition += new Vector2(0, spacing);
			menu_settings = new ClicableElement(fontMenu, "- SETTINGS", UIposition, "settings", Color.White, "default", true);
			settings_soundOn = new ClicableElement(fontMenu, "- SOUND : ON", UIposition, "soundoff", Color.White, "default", true);
			settings_soundOff = new ClicableElement(fontMenu, "- SOUND : OFF", UIposition, "soundon", Color.White, "default", true);
			UIposition += new Vector2(0, spacing);
			menu_exit = new ClicableElement(fontMenu, "- EXIT", UIposition, "exit", Color.White, "default", true);
			settings_exit = new ClicableElement(fontMenu, "- EXIT", UIposition, "settingsexit", Color.White, "default", true);
		}

		public void InitGameplayInterface()
		{
			//-- HUMANS COUNT
			Vector2 elementPosition;
			
			elementPosition = new Vector2((GraphicsDevice.Viewport.Width/3)+5,panelHeight+40);
			panel_textPlanet = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, "PLANET INFO", "none", fontDefault, new Size2(3, 3), "default", false);

			elementPosition = new Vector2(((GraphicsDevice.Viewport.Width/3)*2)+5, panelHeight + 1);
			panel_textRocket = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, "ROCKET INFO", "none", fontDefault, new Size2(3, 3), "default", false);
			
			
			elementPosition = new Vector2((GraphicsDevice.Viewport.Width/3)+5,panelHeight+1);
			panel_countHumans = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, myGameState.count_humans.ToString() + " HUMANS", "none", fontDefault, new Size2(3, 3), "default", true);
			elementPosition = new Vector2((GraphicsDevice.Viewport.Width/3)+5, panelHeight + 75);
			panel_planetName = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, "", "none", fontDefault, new Size2(3,3), "default",true);
			elementPosition += new Vector2(0, 35);
			panel_planetTemperature = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, "", "none", fontDefault, new Size2(3, 3), "default", true);
			elementPosition = new Vector2(30,panelHeight + 20);
			panel_fuelJauge = myInterfaceManager.createPanelJauge(spriteBatch, img_jauge, Color.Black, elementPosition, 0, "default", 0.3f);
			elementPosition += new Vector2(0, 90);
			panel_buttonRefuel = myInterfaceManager.createPanelButton(fontDefault, "", elementPosition, "switch", "center", true,img_switchOff, img_switchOn, 0.2f);
			elementPosition = new Vector2(65, panelHeight + 20);
			panel_tempJauge = myInterfaceManager.createPanelJauge(spriteBatch, img_jaugeInverted, Color.Red, elementPosition, myGameState.currentTemperature, "default", 0.3f);
			elementPosition += new Vector2(0, 90);
			panel_buttonCool = myInterfaceManager.createPanelButton(fontDefault, "", elementPosition, "switch", "center", true,img_switchOff, img_switchOn, 0.2f);
			elementPosition = new Vector2(100, panelHeight + 20);
			panel_oxyJauge = myInterfaceManager.createPanelJauge(spriteBatch, img_jauge, Color.MediumSlateBlue, elementPosition, myGameState.currentOxygene, "default", 0.3f);
			elementPosition += new Vector2(0, 90);
			panel_buttonOxygene = myInterfaceManager.createPanelButton(fontDefault, "", elementPosition, "switch", "center", true, img_switchOn, img_switchOff, 0.2f);

			elementPosition = new Vector2(elementPosition.X+35, panelHeight + 110);
			panel_gpsLever = myInterfaceManager.createPanelButton(fontDefault, "", elementPosition, "switch", "center", true,img_switchOn, img_switchOff, 0.2f);

			elementPosition = new Vector2(GraphicsDevice.Viewport.Width - GraphicsDevice.Viewport.Width / 3 - img_switchOn.Width * 0.2f - 58, panelHeight + 110);
			panel_buttonElectricity = myInterfaceManager.createPanelButton(fontDefault, "", elementPosition, "switch", "center", true,img_switchOff, img_switchOn, 0.2f);

			elementPosition += new Vector2(30, -13);
			panel_lever = myInterfaceManager.createPanelButton(fontDefault, "", elementPosition, "switch", "center", true,img_leverOff, img_leverOn, 0.3f);

			elementPosition = new Vector2(((GraphicsDevice.Viewport.Width / 3) * 2) + 5, panelHeight + 40);
			panel_rocketAltitude = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, "", "none", fontDefault, new Size2(3,3), "default",true);

			elementPosition = new Vector2(elementPosition.X,panelHeight + 75);
			panel_stabilized = myInterfaceManager.createPanelItem(spriteBatch, elementPosition, "", "none", fontDefault, new Size2(3,3), "default",true);

			myRocket = new Rocket(defaultRocketPosition,img_rocket);
			
		}

		public void DrawSettings()
		{
			myParticleStarManager.Draw(spriteBatch);
			Vector2 creditPosition = new Vector2(5, GraphicsDevice.Viewport.Height - 30);
			spriteBatch.DrawString(fontDefault, "V1.0 Made by Simon Aura--Scussel", creditPosition, Color.White);
			if (myGameState.musicEnabled)
			{
				//Console.WriteLine("DRAW MUSIC ON");
				settings_musicOn.Draw(spriteBatch);
			}
			else
			{
				//Console.WriteLine("DRAW MUSIC OFF");
				settings_musicOff.Draw(spriteBatch);
			}
			if (myGameState.soundEnabled)
				settings_soundOn.Draw(spriteBatch);
			else
				settings_soundOff.Draw(spriteBatch);
			settings_exit.Draw(spriteBatch);
		}

		public void UpdateMenu(MouseState pCurrentMouseState)
		{
			bool haveClicked = false;
			if (myGameState.musicEnabled)
			{
				sound_musicInstance.Play();
			}
			if (pCurrentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
			{
				haveClicked = true;
			}
			Vector2 mPose = new Vector2(pCurrentMouseState.Position.X,pCurrentMouseState.Position.Y);
			myParticleStarManager.addParticleStar(myRandom, img_star, GraphicsDevice, 0.1f);
			myParticleStarManager.Update();

			string start_result = menu_start.CheckInteraction(mPose, haveClicked,sound_clic,sound_clic);
			string settings_result = menu_settings.CheckInteraction(mPose, haveClicked,sound_clic,sound_clic);
			string exit_result = menu_exit.CheckInteraction(mPose, haveClicked,sound_clic,sound_clic);
			
			Color highlighted = Color.Crimson;
			Color defaultColor = Color.White;
			
			if (start_result == "over")
			{
				menu_start.color = highlighted;
			}
			else if (start_result == "start")
			{
				sound_clic.Play();
				mySystemGenerator.GenerateSystem(myRandom,GraphicsDevice,myGameState);
				currentState = "introduction";
			}
			else if (start_result == null)
			{
				menu_start.color = defaultColor;
			}
			if (settings_result == "over")
			{
				menu_settings.color = highlighted;
			}
			else if (settings_result == "settings")
			{
				sound_clic.Play();
				currentState = "settings";
			}
			else if (settings_result == null)
			{
				menu_settings.color = defaultColor;
			}
			if (exit_result == "over")
			{
				menu_exit.color = highlighted;
			}
			else if (exit_result == "exit")
			{
				sound_clic.Play();
				Exit();
			}
			else if (exit_result == null)
			{
				menu_exit.color = defaultColor;
			}
			
			
		}

		public void UpdateSettings(MouseState pCurrentMouseState)
		{
			bool haveClicked = false;
			if (myGameState.musicEnabled)
			{
				sound_musicInstance.Play();
			}
			if (pCurrentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
			{
				haveClicked = true;
			}


			Vector2 mPose = new Vector2(pCurrentMouseState.Position.X,pCurrentMouseState.Position.Y);
			myParticleStarManager.addParticleStar(myRandom, img_star, GraphicsDevice, 0.1f);
			myParticleStarManager.Update();

			string musicOn_result = null;
			string musicOff_result = null;
			string soundOn_result = null;
			string soundOff_result = null;
			string settingsExit_result = null;

			if (myGameState.musicEnabled)
			{
				musicOn_result = settings_musicOn.CheckInteraction(mPose, haveClicked, sound_clic, sound_clic);
			}
			else
			{
				musicOff_result = settings_musicOff.CheckInteraction(mPose, haveClicked,sound_clic,sound_clic);
			}
			if (myGameState.soundEnabled)
			{
				soundOn_result = settings_soundOn.CheckInteraction(mPose, haveClicked, sound_clic, sound_clic);
			}
			else
			{
				soundOff_result = settings_soundOff.CheckInteraction(mPose, haveClicked,sound_clic,sound_clic);
			}
			settingsExit_result = settings_exit.CheckInteraction(mPose, haveClicked,sound_clic,sound_clic);

			Color highlighted = Color.Crimson;
			Color defaultColor = Color.White;
			//Console.WriteLine("MUSIC ON ? : " + myGameState.musicEnabled);
			if (musicOn_result == "over")
			{
				settings_musicOn.color = highlighted;
			}
			else if (musicOn_result == "musicoff")
			{
				sound_clic.Play();
				myGameState.musicEnabled = false;
				sound_musicInstance.Stop();
			}
			else if (musicOn_result == null)
			{
				settings_musicOn.color = defaultColor;
			}
			if (musicOff_result == "over")
			{
				settings_musicOff.color = highlighted;
			}
			else if (musicOff_result == "musicon")
			{
				sound_clic.Play();
				myGameState.musicEnabled = true;
			}
			else if (musicOff_result == null)
			{
				settings_musicOff.color = defaultColor;
			}
			if (soundOn_result == "over")
			{
				settings_soundOn.color = highlighted;
			}
			else if (soundOn_result == "soundoff")
			{
				sound_clic.Play();
				myGameState.soundEnabled = false;
			}
			else if (soundOn_result == null)
			{
				settings_soundOn.color = defaultColor;
			}
			
			if (soundOff_result == "over")
			{
				settings_soundOff.color = highlighted;
			}
			else if (soundOff_result == "soundon")
			{
				sound_clic.Play();
				myGameState.soundEnabled = true;
			}
			else if (soundOff_result == null)
			{
				settings_soundOff.color = defaultColor;
			}
			
			if (settingsExit_result == "over")
			{
				settings_exit.color = highlighted;
			}
			else if (settingsExit_result == "settingsexit")
			{
				sound_clic.Play();
				currentState = "menu";
			}
			else if (settingsExit_result == null)
			{
				settings_exit.color = defaultColor;
			}
			
			
			
			
		}

		public void UpdateGameplay(MouseState pCurrentMouseState, GameTime pGameTime)
		{
			myGameState.count_humans += 1;

			if (myGameState.currentAltitude >= myGameState.targetAltitude)
			{
				reset();
				myRocket = null;
				myRocket = new Rocket(defaultRocketPosition, img_rocket);
				myGameState.count_humans -= (int)myGameState.rocketHumansCapacity;
				myGameState.rocketArrived += 1;
				currentState = "win";
			}


			float destabilizationRNG = myRandom.Next(1, 1000);
			if (destabilizationRNG == myGameState.destabilizationChance)
			{
				myGameState.isStabilized = "NOT STABILIZED";
			}
			if (pCurrentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
			{
				myInterfaceManager.CheckInteraction(new Vector2(pCurrentMouseState.Position.X, pCurrentMouseState.Position.Y), true, sound_switchOn, sound_switchOff);
			}

			if (panel_gpsLever.isOn && panel_buttonElectricity.isOn)
			{
				myGameState.isStabilized = "STABILIZED";
				panel_gpsLever.ForceInteraction();
			}

 
			if (panel_buttonOxygene.isOn && panel_lever.isOn == false && myGameState.currentAltitude == myGameState.defaultAltitude && panel_buttonElectricity.isOn)
			{
				if (myGameState.currentOxygene < 1)
				{
					myGameState.currentOxygene += 0.005f;
				}
				else
				{
					panel_buttonOxygene.ForceInteraction();
				}
			}
			else
			{
				if (myGameState.currentOxygene > 0)
				{
					myGameState.currentOxygene -= 0.0001f;
				}
			}
			if (panel_buttonCool.isOn && panel_lever.isOn == false && myGameState.currentAltitude == myGameState.defaultAltitude && panel_buttonElectricity.isOn)
			{
				if (myGameState.currentTemperature > 0)
				{
					myGameState.currentTemperature -= 0.005f;
					if (myGameState.soundEnabled)
					{
						sound_coolInstance.Play();
					}
				}
				else
				{
					panel_buttonCool.ForceInteraction();
				}
			}
			else
			{
				if (myGameState.currentTemperature < 1 && myRocket.inSpace == false)
				{
					myGameState.currentTemperature += 0.0005f;
				}
				else if (myGameState.currentTemperature < 1 && myRocket.inSpace)
				{
					myGameState.currentTemperature -= 0.0005f;
				}
			}

			//--- DEATH DETECTION
			if (myGameState.currentTemperature > myGameState.explosionTemperature && myGameState.currentAltitude > myGameState.defaultAltitude && myRocket.isDestroyed == false)
			{
				myRocket.health -= 0.5f;
				for (int i = 0; i < 10; i++)
				{
					myRocket.Burn(myRandom, img_particleFire);
				}
			}
			if (myRocket.health < myGameState.rocketMinHealth && myRocket.isDestroyed == false)
			{
				myRocket.isDestroyed = true;
				for (int i = 0; i < 5; i++)
				{
					myRocket.Explode(myRandom, img_particleFire);
				}
				myRocket.Destroy(myRandom, fragmentArray);
			}
			if (myGameState.currentOxygene < 0 && myGameState.currentAltitude != myGameState.defaultAltitude)
			{
				timerGameOver += 0.1f;
				if (timerGameOver > maxTimerGameOver)
				{
					myRocket = null;
					myRocket = new Rocket(defaultRocketPosition, img_rocket);
					reset();
					currentState = "gameover";
					myGameover.giveReason("NO MORE OXYGENE-");
				}
			}
			//--- ROCKET PHYSICS
			if (panel_buttonRefuel.isOn && panel_lever.isOn == false && myGameState.currentAltitude == myGameState.defaultAltitude)
			{
				if (myGameState.currentFuel < 1)
				{
					if (sound_refuelInstance.State == SoundState.Stopped && myGameState.soundEnabled)
					{
						sound_refuelInstance.Play();
					}
					
					myGameState.currentFuel += 0.005f;
				}
				else
				{
					panel_buttonRefuel.ForceInteraction();
				}
			}

			if (myGameState.currentAltitude > myGameState.maxAltitude && myRocket.isDestroyed == false)
			{
				if (myGameState.soundEnabled)
				{
					sound_musicInstance.Play();
				}
				myRocket.checkStabilization(myRandom, myGameState.isStabilized);
				myRocket.inSpace = true;
			}
			if (panel_lever.isOn && myGameState.currentFuel > 0.05f && myRocket.inSpace == false && myRocket.isDestroyed == false && myGameState.currentAltitude >= myGameState.defaultAltitude)
			{
				if (myRocket.engineOn == false && myGameState.soundEnabled)
				{
					sound_engine.Play();
				}
				if (myGameState.soundEnabled)
				{
					sound_airInstance.Play();
				}
				myRocket.engineOn = true;
				myRocket.Vibrate(myRandom);
				Vector2 propulsion = new Vector2(0, -0.1f);
				myRocket.applyForce(propulsion);
				myGameState.currentFuel -= 0.0002f;
				myGameState.currentAltitude -= myRocket.velocity.Y;
				string result = myRocket.checkStabilization(myRandom,myGameState.isStabilized);
				if (result == "gameover")
				{
					myRocket.isDestroyed = true;
					myRocket.Burn(myRandom,img_particleFire);
					myRocket.Destroy(myRandom, fragmentArray);
					myGameover.giveReason("WRONG ORIENTATION");
				}
			}
			else
			{
				if (myGameState.currentAltitude > myGameState.defaultAltitude && myRocket.isDestroyed == false &&myGameState.currentAltitude < myGameState.maxAltitude)
				{
					if (myGameState.soundEnabled)
					{
						sound_airInstance.Play();
					}
					myRocket.engineOn = false;
					Vector2 gravity = new Vector2(0, 1);
					myRocket.applyForce(gravity);
					myGameState.currentAltitude -= myRocket.velocity.Y;
				}
				else if (myGameState.currentAltitude > myGameState.maxAltitude && myRocket.isDestroyed == false)
				{
					myRocket.engineOn = false;
					myGameState.currentAltitude -= myRocket.velocity.Y;
				}
				else if (myGameState.currentAltitude <= myGameState.defaultAltitude)
				{
					if (myRocket.velocity.Y >= 10)
					{
						myRocket.Destroy(myRandom, fragmentArray);
						myRocket.Burn(myRandom, img_particleFire);
						myRocket.isDestroyed = true;
					}
					
					myRocket.engineOn = false;
					myGameState.currentAltitude = myGameState.defaultAltitude;
					myRocket.velocity = Vector2.Zero;
					myRocket.acceleration = Vector2.Zero;
				}
			}

			if (myRocket.isDestroyed)
			{
				timerGameOver += 0.1f;
				if (timerGameOver > maxTimerGameOver)
				{
					if ((int)myRocket.rotation == 0)
					{
						myGameover.giveReason("ROCKET DESTROYED-");
					}
					myRocket = null;
					myRocket = new Rocket(defaultRocketPosition, img_rocket);
					reset();
					currentState = "gameover";
				}
			}


			myRocket.Update(myRandom, img_particleFire);
			myParticleStarManager.ApplyForce(new Vector2(0, 0.01f));
			myParticleStarManager.Update();
		}

		public void DrawMenu()
		{
			myParticleStarManager.Draw(spriteBatch);
			Vector2 titlePosition = new Vector2(30, 35);
			Vector2 creditPosition = new Vector2(5, GraphicsDevice.Viewport.Height - 30);
			spriteBatch.DrawString(fontTitle, "OVERPOPULATION", titlePosition, Color.White);
			spriteBatch.DrawString(fontDefault, "V1.0 Made by Simon Aura--Scussel", creditPosition, Color.White);
			menu_start.Draw(spriteBatch);
			menu_settings.Draw(spriteBatch);
			menu_exit.Draw(spriteBatch);
			
		}

		public void DrawGameplay()
		{
			//-- CONTROL PANEL
			Vector2 backgroundPosition = new Vector2(0, 0 - (myGameState.defaultAltitude - myGameState.currentAltitude));
			Vector2 backgroundSkyPosition1 = backgroundPosition;
			if (backgroundPosition.Y > 0)
			{
				spriteBatch.Draw(img_backgroundsky, backgroundSkyPosition1, null, null, new Vector2(0, img_backgroundsky.Height), 0, new Vector2(resolutionFactor, resolutionFactor));
			}
			if (backgroundPosition.Y < GraphicsDevice.Viewport.Height)
			{
				spriteBatch.Draw(img_background, backgroundPosition, null, null,Vector2.Zero, 0, new Vector2(resolutionFactor, resolutionFactor));
			}
			else if (myGameState.currentAltitude > 5000)
			{
				myParticleStarManager.addParticleStar(myRandom, img_star, GraphicsDevice, 0.1f);
				myParticleStarManager.Draw(spriteBatch);
			}
			//-- DYNAMIC ROCKET AND LAUNCHPAD
			Vector2 launchpadPosition = new Vector2(GraphicsDevice.Viewport.Width / 2, panelHeight);
			spriteBatch.Draw(img_launchPad, new Vector2(launchpadPosition.X,launchpadPosition.Y - (myGameState.defaultAltitude-myGameState.currentAltitude)), null, null, new Vector2(img_launchPad.Width / 2, img_launchPad.Height), 0f, new Vector2(1, 1), Color.White, SpriteEffects.None,0);
			myRocket.Draw(spriteBatch);
			// --
			Color panelColor = Color.Black;
			spriteBatch.Draw(img_controlpanel, new Vector2(0, panelHeight), null, null, Vector2.Zero, 0, new Vector2(resolutionFactor,resolutionFactor), Color.White,SpriteEffects.None,0);
			//-- DYNAMIC PANEL
			if (panel_buttonElectricity.isOn)
			{
				panel_countHumans.isVisible = true;
				panel_planetName.isVisible = true;
				panel_planetTemperature.isVisible = true;
				panel_rocketAltitude.isVisible = true;
				panel_textPlanet.isVisible = true;
				panel_textRocket.isVisible = true;
				panel_stabilized.isVisible = true;
				panel_stabilized.UpdateDisplay(myGameState.isStabilized);
				panel_countHumans.UpdateDisplay(myGameState.count_humans + " HUMANS");
				panel_planetName.UpdateDisplay("ID: " + myGameState.currentPlanet.name);
				panel_planetTemperature.UpdateDisplay(myGameState.currentPlanet.temperature.ToString() + " F");
				panel_rocketAltitude.UpdateDisplay(myGameState.currentAltitude.ToString() + " KM");
			}
			else
			{
				panel_stabilized.isVisible = false;
				panel_countHumans.isVisible = false;
				panel_planetName.isVisible = false;
				panel_planetTemperature.isVisible = false;
				panel_rocketAltitude.isVisible = false;
				panel_planetName.isVisible = false;
				panel_textPlanet.isVisible = false;
				panel_textRocket.isVisible = false;
			}
			panel_fuelJauge.UpdateDisplay(myGameState.currentFuel);
			panel_tempJauge.UpdateDisplay(myGameState.currentTemperature);
			panel_oxyJauge.UpdateDisplay(myGameState.currentOxygene);

			float ledScale = 0.1f;
			Vector2 ledPosition = new Vector2(panel_buttonElectricity.position.X+7,panel_buttonElectricity.position.Y - 20);
			if (panel_buttonElectricity.isOn)
			{
				spriteBatch.Draw(img_ledOn, ledPosition,null,null,new Vector2((img_ledOn.Width*ledScale)/2,img_ledOn.Height/2),0,new Vector2(ledScale, ledScale), Color.White,SpriteEffects.None,0);
			}
			else
			{
				spriteBatch.Draw(img_ledOff, ledPosition,null,null,new Vector2((img_ledOn.Width*ledScale)/2,img_ledOn.Height/2),0, new Vector2(ledScale, ledScale),Color.White,SpriteEffects.None,0);
			}
			
			myInterfaceManager.Draw(spriteBatch);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS

			// TODO: Add your update logic here

			MouseState currentMouseState = Mouse.GetState();
			Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);

			currentKeyboardState = Keyboard.GetState();
			if (currentState == "system")
			{
				mySystemGenerator.Update();
				if (oldMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
				{
					if (mySystemGenerator.CheckInteraction(mousePosition, myGameState, true, sound_clic, sound_clic) == "launch")
					{
						sound_musicInstance.Stop();
						panel_planetName.UpdateDisplay("ID: " + myGameState.currentPlanet.name);
						panel_planetTemperature.UpdateDisplay(myGameState.currentPlanet.temperature.ToString() + "  F");
						panel_rocketAltitude.UpdateDisplay(myGameState.currentAltitude.ToString() + " KM");
						panel_stabilized.UpdateDisplay(myGameState.isStabilized);
						currentState = "gameplay";
					}
				}
			}
			else if (currentState == "gameplay")
			{
				UpdateGameplay(currentMouseState, gameTime);
			}
			else if (currentState == "menu")
			{
				UpdateMenu(currentMouseState);
			}
			else if (currentState == "introduction")
			{
				if (myGameState.musicEnabled)
				{
					sound_musicInstance.Play();
				}
				myIntroduction.Update(gameTime);
			}
			else if (currentState == "gameover")
			{
				if (myGameState.musicEnabled)
				{
					sound_musicInstance.Play();
				}
				myGameover.Update(currentKeyboardState, oldKeyboardState, myRandom);
			}
			else if (currentState == "win")
			{
				if (myGameState.musicEnabled)
				{
					sound_musicInstance.Play();
				}
				myWin.Update(currentKeyboardState, oldKeyboardState, myRandom, img_star, GraphicsDevice, sound_key, myGameState);
			}
			else if (currentState == "end")
			{
				if (myGameState.musicEnabled)
				{
					sound_musicInstance.Play();
				}
				myEnd.Update(currentKeyboardState, oldKeyboardState, gameTime);
			}
			else if (currentState == "settings")
			{
				if (myGameState.musicEnabled)
				{
					sound_musicInstance.Play();
				}
				UpdateSettings(currentMouseState);
			}

			oldMouseState = currentMouseState;
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			if (currentState == "system")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}
			else if (currentState == "gameplay")
			{
				Color defaultColor = Color.SkyBlue;
				graphics.GraphicsDevice.Clear(defaultColor * (1 - (myGameState.currentAltitude / myGameState.maxAltitude)));
			}
			else if (currentState == "menu")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}
			else if (currentState == "introduction")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}
			else if (currentState == "gameover")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}
			else if (currentState == "win")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}
			else if (currentState == "end")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}
			else if (currentState == "settings")
			{
				graphics.GraphicsDevice.Clear(Color.Black);
			}

			//TODO: Add your drawing code here

			spriteBatch.Begin();

			// -- CONTROL PANEL

			if (currentState == "system")
			{
				mySystemGenerator.Draw(spriteBatch, fontDefault);
			}
			else if (currentState == "gameplay")
			{
				DrawGameplay();
			}
			else if (currentState == "menu")
			{
				DrawMenu();
			}
			else if (currentState == "introduction")
			{
				string result = myIntroduction.Draw(spriteBatch, myGameState, currentKeyboardState, oldKeyboardState, GraphicsDevice, fontTitle, fontIntro, fontDefault, sound_key, sound_alarmInstance);
				if (result == "system")
				{
					currentState = result;
				}
				oldKeyboardState = currentKeyboardState;
			}
			else if (currentState == "gameover")
			{
				string result = myGameover.Draw(spriteBatch, GraphicsDevice, fontIntro);
				if (result == "menu")
				{
					currentState = result;
				}
				oldKeyboardState = currentKeyboardState;
			}
			else if (currentState == "win")
			{
				string result = myWin.Draw(spriteBatch, GraphicsDevice, fontMenu, fontIntro, fontDefault, myGameState, myInterfaceManager);
				if (result == "system")
				{
					mySystemGenerator.GenerateSystem(myRandom, GraphicsDevice, myGameState);
					myWin.reset();
					currentState = result;
				}
				else if (result == "end")
				{
					myWin.reset();
					currentState = result;
				}
			}
			else if (currentState == "end")
			{
				string result = myEnd.Draw(spriteBatch, myRandom, GraphicsDevice, fontTitle, fontMenu, fontIntro, fontDefault, currentKeyboardState, oldKeyboardState, img_star);
				if (result == "menu")
				{
					myEnd.reset();
					currentState = "menu";
				}
			}
			else if (currentState == "settings")
			{
				DrawSettings();
			}
			oldKeyboardState = currentKeyboardState;
			
			spriteBatch.Draw(img_cursor, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), null, null, new Vector2((img_cursor.Width * 0.4f)/2,(img_cursor.Height * 0.4f)/2), 0, new Vector2(0.4f, 0.4f),Color.White,SpriteEffects.None,0);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
