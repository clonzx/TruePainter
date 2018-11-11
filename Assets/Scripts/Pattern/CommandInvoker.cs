using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections.Generic;
using UpGS.Data;

namespace UpGS.Pattern
{
	 

	public class CommandInvoker
	{
		// Initializers
		public List<Command> _commands = new List<Command>();
		
		protected int _current = 0;
		
		virtual public void Redo(int levels)
		{
			if (GameControll.gameControll.DebugLog) Debug.Log ("------Redo "+levels+" levels");
			
			// Make redo
			for (int i = 0; i < levels; i++)
				if (_current < _commands.Count)
					_commands[_current++].Execute();
		}
		
		virtual public void Undo(int levels)
		{
			if (GameControll.gameControll.DebugLog)Debug.Log ("----------Undo "+levels+" levels");
			bool needNext=false; // Set when command not contains undo data
			// Make undo
			for (int i = 0; i < levels; i++)
				if (_current > 0)
					needNext=_commands[--_current].UnExecute();
		}

		public void Execute()
		{
			
			Command command=null;
			//paste  command init  ...
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
		}

	}
}
