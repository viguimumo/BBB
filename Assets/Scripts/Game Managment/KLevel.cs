using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AssemblyCSharp
{
	public class KLevel
	{
		string levelRute;
		public int[] passedLevels;
		
		public KLevel ()
		{
			Charge ();
			levelRute = Application.persistentDataPath + "/passedLevels.text.bytes";
		}

		public int[] PassedLevels{
			set{
				passedLevels = value;
				Save ();
			}
			get { 
				Charge ();
				return passedLevels;
			}
		}

		public void Save (){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (levelRute);

			KeepData info = new KeepData (passedLevels);
			bf.Serialize (file, info);

			file.Close ();
		}

		public void Charge (){
			if (File.Exists (levelRute)) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (levelRute, FileMode.Open);

				KeepData info = (KeepData) bf.Deserialize (file);
				passedLevels = info.passedLevels;

				file.Close ();
			} 
			else {
				passedLevels = new int[0];
			}
		}
	}
}

