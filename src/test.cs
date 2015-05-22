using System;
using System.IO;
using System.Collections.Generic;
namespace Cons{
	class test{
		private static List<Item> _arrItem=new List<Item>();
		public static void Main (string[] args){
			Console.WriteLine ("Hello World!"+Environment.CurrentDirectory);
			string[] files = Directory.GetFiles(Environment.CurrentDirectory);

			foreach (string file in files){
				var item=new Item(file);
				if(!item.isOk)continue;
				_arrItem.Add(item);
				var path=Environment.CurrentDirectory+@"\"+item.suffix;
				Console.WriteLine (file+" "+path);
				if(item.suffix!="exe"){
					Directory.CreateDirectory(path);
					Directory.Move(file,path+@"\"+item.fName);
				}
			}

			Console.Read();
		}
	}
	class Item{
		public string name;
		public string suffix;
		public string fName;
		public bool isOk;
		public Item(string str){
			fName=Path.GetFileName(str);
			var spr=fName.Split('.');
			if(spr.Length>=2){
				isOk=true;
			}else{
				return;
			}
			name=spr[0];
			suffix=spr[spr.Length-1];
		}

	}
}
