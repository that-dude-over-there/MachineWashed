using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MachineWashed
{
	class Player:Entity
	{
		private KeyboardState keyState;
		public enum State
		{
			Idle,
			Walking,
			Jumping
		}

		public State state;

		public Player(string asset,Vector2 pos,int frameWidth,int frameHeight,int offset,Game1 game):base(asset,pos,frameWidth,frameHeight,offset,game)
		{
			
		}

		public void update(GameTime gameTime)
		{
			base.update(gameTime);
			state=State.Idle;
			Grav=0;
			if (checkMove(new Vector2(0,1),currentGame.level.Tiles)==null)
			{
				if (checkMove(new Vector2(0,-1),currentGame.level.Tiles)!=null)
				{
					Vspeed=0;
					Pos+=new Vector2(0,1);
				}
				state=State.Jumping;
				Grav=.03f;
			}
			else
			if (Vspeed>=0)
				Vspeed=0;
			getInput();

			for(int i=(int)Math.Abs(Math.Ceiling(Hspeed));i>0;i--)
			{
				Vector2 mov = new Vector2(i*Math.Sign(Hspeed),0)*(float)gameTime.ElapsedGameTime.TotalSeconds;
				if (checkMove(mov,currentGame.level.Tiles)==null)
				{
					Pos+=mov;
				}
			}

			for(int i=(int)Math.Abs(Math.Ceiling(Vspeed));i>0;i--)
			{
				Vector2 mov=new Vector2(0,i*Math.Sign(Vspeed))*(float)gameTime.ElapsedGameTime.TotalSeconds;
				if (checkMove(mov,currentGame.level.Tiles)==null)
				{
					Pos+=mov;
				}
			}
			Console.WriteLine(state);
		}

		public void getInput()
		{
			keyState=Keyboard.GetState();

			if (keyState.IsKeyDown(Keys.W))
			{
				if (state!=State.Jumping)
				{
					Vspeed=-35;
					state=State.Jumping;
				}
			}

			if (keyState.IsKeyDown(Keys.A))
			{
				Hspeed=-20;
				if (state!=State.Jumping)
					state=State.Walking;
			}
			else
			if (keyState.IsKeyDown(Keys.D))
			{
				Hspeed=20;
				if (state!=State.Jumping)
					state=State.Walking;
			}
			else
			{
				Hspeed=0;
				if (state!=State.Jumping)
					state=State.Idle;
			}

			if (keyState.IsKeyDown(Keys.Space))
			{
				Console.WriteLine(Bbox.Origin);
				Console.WriteLine(Pos);
			}
		}

		public Entity checkMove(Vector2 offset,Entity[] obj)
		{	
			Entity temp;
			for(int i=0;i<obj.Length;i++)
			{
				if ((temp=base.checkMove(offset,obj[i]))!=null)
				{
					return(temp);
				}
			}
			return(null);
		}
	}
}