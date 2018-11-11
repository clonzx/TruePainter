using UnityEngine;
using UnityEditor;

namespace UpGS.Data
{

public class GameControll:ScriptableObject 
{
		public bool DebugLog; //Выводить сообщения отладчика;
		public static GameControll gameControll;
}

[CreateAssetMenu(fileName = "UpGS GameControllPainter",menuName="UpGS/GameControllPainter",order=0)]
//[MenuItem("Assets/Create/UpGS/FloatVariable")]
public class GameControllPainter:GameControll 
{

}



}
