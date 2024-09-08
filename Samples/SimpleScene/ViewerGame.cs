﻿using AssetManagementBase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nursia;
using Nursia.Modelling;
using Nursia.Rendering;
using Nursia.Rendering.Lights;
using Nursia.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleScene
{
	public class ViewerGame : Game
	{
		private readonly GraphicsDeviceManager _graphics;
		private Scene _scene;
		private NursiaModel _model;
		private DirectLight _light;
		private CameraInputController _controller;
		private readonly ForwardRenderer _renderer = new ForwardRenderer();
		private readonly FramesPerSecondCounter _fpsCounter = new FramesPerSecondCounter();
		private DateTime? _animationMoment;
		private SpriteBatch _spriteBatch;

		public static string ExecutingAssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().Location;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		public ViewerGame()
		{
			_graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = 1200,
				PreferredBackBufferHeight = 800
			};

			Window.AllowUserResizing = true;
			IsMouseVisible = true;

			if (Configuration.NoFixedStep)
			{
				IsFixedTimeStep = false;
				_graphics.SynchronizeWithVerticalRetrace = false;
			}
		}

		protected override void LoadContent()
		{
			base.LoadContent();

			// Nursia
			Nrs.Game = this;

			var assetManager = AssetManager.CreateFileAssetManager(Path.Combine(ExecutingAssemblyDirectory, "Assets"));
			_scene = assetManager.LoadScene("test.scene");

			_model = _scene.QueryByType<NursiaModel>()[0];
			_model.Model.CurrentAnimation = _model.Model.Animations.First().Value;

			_light = _scene.QueryByType<DirectLight>()[0];

			_controller = new CameraInputController(_scene.Camera);

			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			_fpsCounter.Update(gameTime);

			var keyboardState = Keyboard.GetState();

			// Manage camera input controller
			_controller.SetControlKeyState(CameraInputController.ControlKeys.Left, keyboardState.IsKeyDown(Keys.A));
			_controller.SetControlKeyState(CameraInputController.ControlKeys.Right, keyboardState.IsKeyDown(Keys.D));
			_controller.SetControlKeyState(CameraInputController.ControlKeys.Forward, keyboardState.IsKeyDown(Keys.W));
			_controller.SetControlKeyState(CameraInputController.ControlKeys.Backward, keyboardState.IsKeyDown(Keys.S));
			_controller.SetControlKeyState(CameraInputController.ControlKeys.Up, keyboardState.IsKeyDown(Keys.Up));
			_controller.SetControlKeyState(CameraInputController.ControlKeys.Down, keyboardState.IsKeyDown(Keys.Down));

			var mouseState = Mouse.GetState();
			_controller.SetTouchState(CameraInputController.TouchType.Rotate, mouseState.RightButton == ButtonState.Pressed);
			_controller.SetMousePosition(new Point(mouseState.X, mouseState.Y));

			_controller.Update();

			if (_animationMoment == null)
			{
				_animationMoment = DateTime.Now;
			}
			else
			{
				var passed = (float)(DateTime.Now - _animationMoment.Value).TotalSeconds;
				_model.Model.UpdateCurrentAnimation(passed);
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			GraphicsDevice.Clear(Color.Black);

			_renderer.Render(_scene, _scene.Camera);

			_fpsCounter.Draw(gameTime);

			_spriteBatch.Begin();

			_spriteBatch.Draw(_light.ShadowMap, 
				new Rectangle(0, 0, 256, 256), 
				Color.White);

			_spriteBatch.End();
		}
	}
}