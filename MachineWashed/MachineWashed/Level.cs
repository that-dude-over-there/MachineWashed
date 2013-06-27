using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MachineWashed
{
	public class Level
	{
		public Entity[] Tiles{get;private set;}
		private int current;

		public Level()
		{
			Tiles=new Entity[64];
			current=0;
		}

		public Level(Entity[] arr)
		{
			Tiles=arr;
			current=0;
		}

		public void add(Entity obj)
		{
			if (current>=Tiles.Length)
			{
				Entity[] temp=new Entity[Tiles.Length+32];
				Tiles.CopyTo(temp,0);
				Tiles=temp;
			}

			Tiles[current++]=obj;
		}

		public void loadContent(ContentManager cManager)
		{
			for(int i=0;i<Tiles.Length;i++)
			{
				if (Tiles[i]!=null)
					Tiles[i].loadContent(cManager);
				else
				return;
			}
		}

		public void draw(SpriteBatch sBatch)
		{
			for(int i=0;i<Tiles.Length;i++)
			{
				if (Tiles[i]!=null)
					Tiles[i].draw(sBatch);
				else
				return;
			}
		}
	}
}