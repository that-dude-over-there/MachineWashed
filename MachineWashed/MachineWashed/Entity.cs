using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MachineWashed
{
	public class Entity:Sprite
	{
		protected Game1 currentGame;

		public bool Solid{get;protected set;}
		public bool Active{get;set;}
		public Hitbox Bbox{get;protected set;}
		protected float Grav{get;set;}
		protected float Fric{get;set;}
		protected float Vspeed{get;set;}
		protected float Hspeed{get;set;}
		private float maxVspeed;

		public Entity(string asset,Vector2 pos,int frameWidth,int frameHeight,int offset,Game1 game):base(asset,pos,frameWidth,frameHeight,offset)
		{
			Solid=false;
			Active=true;

			Vspeed=0;
			Hspeed=0;
			maxVspeed=(float)frameHeight*2;

			Grav=0;
			Fric=0;

			Bbox=new Hitbox(Pos,frameWidth,frameHeight,this);

			currentGame=game;
		}

		public Entity(string asset,Vector2 pos,int frameWidth,int frameHeight,int offset,bool solid,bool active,Game1 game):base(asset,pos,frameWidth,frameHeight,offset)
		{
			Solid=solid;
			Active=active;

			Vspeed=0;
			Hspeed=0;

			Grav=0;
			Fric=0;

			Bbox=new Hitbox(Pos,frameWidth,frameHeight,this);

			currentGame=game;
		}

		public Entity checkMove(Vector2 offset,Entity obj)
		{
			return(Bbox.checkCol(Pos+offset,obj));
		}

		private void checkGravity()
		{
			if (Grav!=0)
			{
				Vspeed+=(Grav*maxVspeed);
				if (Vspeed>maxVspeed)
					Vspeed=maxVspeed;
				else
				if (Math.Abs(Vspeed)>maxVspeed)
					Vspeed=maxVspeed*-1;
			}
		}

		private void checkFriction()
		{
			if (Fric!=0)
			{
				Hspeed*=Fric;
				if (Hspeed<1)
					Hspeed=0;
			}
		}

		public void update(GameTime gameTime)
		{
			base.update(gameTime);
			Bbox.update();
			checkGravity();
			checkFriction();
		}
	}
}