using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections.Generic;

namespace UpGS.Pattern
{
	// "Command" : Команда
	
	public abstract class Command
	{

		abstract public void Execute();
		abstract public bool UnExecute();
	}
	
}