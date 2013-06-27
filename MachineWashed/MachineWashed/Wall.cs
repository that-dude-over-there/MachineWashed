using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MachineWashed
{
	class Wall:Entity
	{
		public Wall(string asset,Vector2 pos,int frameWidth,int frameHeight,int offset,Game1 game):base(asset,pos,frameWidth,frameHeight,offset,game){}
	}
}
