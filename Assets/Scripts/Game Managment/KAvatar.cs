using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AssemblyCSharp
{
	public class KAvatar
	{
		string avatarName;
		string avatarRute;

		public KAvatar ()
		{
			avatarRute = Application.persistentDataPath + "/playerAvatar.txt";
		}

		public string AvatarName{
			set{
				avatarName = value;
				Save ();
			}
			get { 
				Charge ();
				return avatarName;
			}
		}

		private void Save(){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (avatarRute);

			KeepData info = new KeepData (avatarName);
			bf.Serialize (file, info);

			file.Close ();
		}

		public void Charge(){
			if (File.Exists (avatarRute)) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (avatarRute, FileMode.Open);

				KeepData info = (KeepData)bf.Deserialize (file);
				avatarName = info.name;

				file.Close ();
			} 
			else {
				avatarName = "";
			}
		}
	}
}

