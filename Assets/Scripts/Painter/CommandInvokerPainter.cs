using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpGS.Pattern;
using UpGS.Data;

namespace UpGS.Painter
{
	public enum CommandType{Paint=1,Fill=2,SelectColor=3};

	public class CommandInvokerPainter : CommandInvoker {

		EventPublisherTopics ButtonPublisher; // event controll for button redo

		//Constructor
		public CommandInvokerPainter()
		{
			ButtonPublisher = new EventPublisherTopics ();
			if (_current >= _commands.Count) ButtonPublisher.Publish ("Redo",false);
			if (_current <= 0) ButtonPublisher.Publish ("Undo",false);
		}

		override public void Undo(int levels)
		{
			if (GameControll.gameControll.DebugLog)Debug.Log ("----------Undo "+levels+" levels");
			bool needNext=false; // Set when command not contains undo data
			// Make undo
			for (int i = 0; i < levels; i++)
				if (_current > 0)
					needNext=_commands[--_current].UnExecute();
			while (needNext&&_current > 0) {
				needNext=_commands[--_current].UnExecute();
			}
			ButtonPublisher.Publish ("Redo",true);
			if (_current<=0) ButtonPublisher.Publish ("Undo",false);
		}

		override public void Redo(int levels)
		{
			base.Redo (levels);
			if (_current >= _commands.Count) ButtonPublisher.Publish ("Redo",false);
		}

		public void Execute(CommandType _type, object _param)
		{
			
			// Command create and execute
			Command command;
			switch (_type) {
			case CommandType.Paint:
				command=new CommandPaint((PaintParam)_param);
				break;
			case CommandType.Fill:
				command=new CommandFill((PaintParam)_param);
				break;
			case CommandType.SelectColor:
				command=new CommandColor((Color)_param);
				break;
			default:
				return;
			}
			command.Execute();
			
			if (_current < _commands.Count)
			{
				// если "внутри undo" мы запускаем новую операцию, 
				// надо обрубать список команд, следующих после текущей, 
				// иначе undo/redo будут некорректны
				_commands.RemoveRange(_current, _commands.Count - _current);
			}
			
			// Добавляем операцию к списку отмены
			_commands.Add(command);
			_current++;
			ButtonPublisher.Publish ("Redo",false);
			ButtonPublisher.Publish ("Undo",true);
		}
	}
}
