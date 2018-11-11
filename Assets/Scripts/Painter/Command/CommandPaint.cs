using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using UpGS.Pattern;
using FreeDraw;

namespace UpGS.Painter
{
	public enum CommandState{Start=1,Continue=2,End=3};

	public class PaintParam
	{
		public Vector2 place;
		public CommandState	commandState;
		public float 				time;
		// Constructor
		public PaintParam(CommandState _commandState, Vector2 _place)
		{
			place = _place;
			commandState = _commandState;
			time = Time.time;
		}
	}


	class CommandPaint : Command
	{
		PaintParam			paintParam;
		Color32[] 			old_colors; // For Undo command
		// Constructor
		public CommandPaint(PaintParam _paintParam)
		{
			paintParam = _paintParam;
		}

		
		public override void Execute()
		{
			switch(paintParam.commandState){
			case CommandState.Start:
				old_colors=new Color32[PainterDrawable.instance.cur_colors.Length];
				PainterDrawable.instance.cur_colors.CopyTo(old_colors,0);
				PainterDrawable.instance.ClearDragPosition ();
				PainterDrawable.instance.SetPenBrush();
				PainterDrawable.instance.current_brush(paintParam.place);
				break;
			case CommandState.Continue:
				PainterDrawable.instance.current_brush(paintParam.place);
				break;
			case CommandState.End:
				PainterDrawable.instance.ClearDragPosition ();
				break;
			}
		}
		
		public override bool UnExecute()
			//return true then not find old data
		{
			if (old_colors != null) {
				old_colors.CopyTo(PainterDrawable.instance.cur_colors,0);
				PainterDrawable.instance.ApplyMarkedPixelChanges();
				old_colors=null; //clear old data after use
				return false;
			}
			return true;
		}
		

	}
	

	}

