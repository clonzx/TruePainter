using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
using UpGS.Pattern;
using UpGS.Data;
using UpGS.Manager;

namespace UpGS.Painter{

	public class PainterControll : EventSubscriber
	{
		public PainterDrawable		drawable;
		protected CommandInvokerPainter	invoker;
		protected CommandType		currentCommand;
		//clonx 19.10.2018 -->
		void Start()
		{
			EventRegister.SetPointerProcessorUp(OnPointerUp);
			EventRegister.SetPointerProcessorDown(OnPointerDown);
			EventRegister.SetPointerProcessorDrag(OnPointerDrag);
			invoker = new CommandInvokerPainter ();
			currentCommand=CommandType.Paint;
		}


		override public void Notify(string data)
		{
			switch (data) 
			{
			//Brush
			case "FillBrush":
				currentCommand=CommandType.Fill;
				break;
			case "PenBrush":
				currentCommand=CommandType.Paint;
				break;
			//Color
			case "RedColor":
				invoker.Execute(CommandType.SelectColor,Color.red);
				break;
			case "GreenColor":
				invoker.Execute(CommandType.SelectColor,Color.green);
				break;
			case "BlueColor":
				invoker.Execute(CommandType.SelectColor,Color.blue);
				break;
			}
		}


		public void OnPointerUp(PointerEventData data ) {
			invoker.Execute(currentCommand,new PaintParam(CommandState.End, new Vector2(0,0)));
		}

		public void OnPointerDown(PointerEventData data ) {
			invoker.Execute(currentCommand,new PaintParam(CommandState.Start, data.position)); 
		}
		
		public void OnPointerDrag(PointerEventData data ) {
			invoker.Execute(currentCommand,new PaintParam(CommandState.Continue, data.position)); 
		}

		public void UndoButton()
		{
			invoker.Undo (1);
		}

		public void RedoButton()
		{
			invoker.Redo (1);
		}



	}
}