using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using UpGS.Pattern;
using FreeDraw;

namespace UpGS.Painter
{

	class CommandColor : Command
	{
		Color		old_color; // For Undo command
		Color		color;
		// Constructor
		public CommandColor(Color _color)
		{
			color = _color;
		}
		
		
		public override void Execute()
		{
			old_color = FreeDraw.Drawable.Pen_Colour;
			FreeDraw.Drawable.Pen_Colour=color;
		}
		
		public override bool UnExecute()
			//return true then not find old data
		{
			if (old_color != null) {
				FreeDraw.Drawable.Pen_Colour=old_color;
				return false;
			}
			return true;
		}


	}
	

	}

