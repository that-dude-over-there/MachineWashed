#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace MachineWashed
{
	public class Game1 : Game
	{
		public Level level;

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Player player;
		public Game1() : base()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			player=new Player("faceSheet",new Vector2(200,200),32,32,0,this);
			level=new Level();
			level.add(new Wall("wall",new Vector2(200,300),32,32,0,this));
			level.add(new Wall("wall",new Vector2(232,300),32,32,0,this));
			level.add(new Wall("wall",new Vector2(264,300),32,32,0,this));
			level.add(new Wall("wall",new Vector2(264,268),32,32,0,this));

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			level.loadContent(this.Content);
			player.loadContent(this.Content);
		}

		protected override void UnloadContent()
		{

		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			player.update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();
			player.draw(spriteBatch);
			level.draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
