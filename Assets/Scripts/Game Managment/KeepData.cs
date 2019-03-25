using System;

namespace AssemblyCSharp
{
	[Serializable]
	public class KeepData{

		// Para mantener el avatar seleccionado
		public string name;

		// Para saber qué niveles se han superado
		public int[] passedLevels;

		public KeepData(int[] passedLevels){
			this.passedLevels = passedLevels;
		}

		public KeepData(string name){
			this.name = name;
		}
	}
}

