using System;
using System.IO;
using System.Windows.Forms;

namespace KeyboardRecord {
	public class Data {

		public string[] nameZh = {
			"退格","Tab","回车","大写锁","Esc",
			"空格",
			"PageUp","PageDown","End","Home",
			"左","上","右","下",
			// 14
			"插入","删除",
			// 16
			"0","1","2","3","4","5","6","7","8","9",
			"右括号","感叹号","@","井号","$","百分号","^","&","星号","左括号",
			// 36
			"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
			// 62
			"Win","App",
			// 64
			"F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12",
			// 76
			"左Shift","右Shift","左Ctrl","右Ctrl","左Alt","右Alt",
			// 82
			"分号","等于号","逗号","横线(减号)","点","斜杠","`","左中括号","反斜杠","右中括号","单引号",
			// 93
			"冒号","加号","小于号","下划线","大于号","问号","~","左花括号","|","右花括号","双引号",
			// 104
			"复制","粘贴","撤销","保存","剪切"
		};

		public string[] name = {
			// 0
			"Back","Tab","Enter","Caps","Esc",
			// 5
			"Space",
			"PageUp","PageDown","End","Home",
			"Left","Up","Right","Down",
			// 14
			"Insert","Delete",
			// 16
			"0","1","2","3","4","5","6","7","8","9",
			")","!","@","#","$","%","^","&","*","(",
			// 36
			"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
			// 62
			"Win","App",
			// 64
			"F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","F11","F12",
			// 76
			"LShift","RShift","LCtrl","RCtrl","LAlt","RAlt",
			// 82
			";","=",",","-",".","/","`","[","\\","]","'",
			// 93
			":","+","<","_",">","?","~","{","|","}","\"",
			// 104
			"Ctrl+C","Ctrl+V","Ctrl+Z","Ctrl+S","Ctrl+X"
		};
		// 存放按键次数的数组
		public int[] times;

		public Data() {
			loadData();
		}


		public void loadData() {

			times = new int[name.Length];
			// 从本地的文件读取数据
			string path = Path.Combine((Application.StartupPath + @"\"),"data.csv");
			try {
				if(!File.Exists(path)) return;
				using StreamReader reader = new StreamReader(new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.None));
				for(int i = 0;i<name.Length;i++) {
					// 一次读一行数据
					string line = reader.ReadLine();
					string[] sp = line.Split('\t');
					times[i] = int.Parse(sp[1]);
				}
			} catch(Exception e) {
				// 读取遇到问题就从上一次保存的文件恢复数据（我可不想辛辛苦苦记录的数据说没就没了）
				File.Delete(path);
				if(File.Exists(path + ".bak")) {
					File.Move(path + ".bak",path);
					// 重新载入数据
					loadData();
					MessageBox.Show("载入数据时出错，尝试从备份文件中恢复\n"+e.Message,"错误");
				} else {
					MessageBox.Show("载入数据时出错!\n"+e.Message,"错误");
				}
			}
		}
		// 保存记录的数据
		public void saveData() {
			string path = Path.Combine((Application.StartupPath + @"\"),"data.csv");
			try {
				// 把之前保存的数据备份
				if(File.Exists(path)) {
					if(File.Exists(path + ".bak")) File.Delete(path + ".bak");
					File.Copy(path,path + ".bak");
				}
				using StreamWriter writer = new StreamWriter(new FileStream(path,FileMode.Create,FileAccess.Write,FileShare.None));
				for(int i = 0;i<name.Length;i++) {
					// 一行的数据格式为：名称 + Tab + 按键次数
					writer.Write(name[i]);
					writer.Write('\t');
					writer.Write(times[i].ToString());
					writer.Write("\r\n");
				}
			} catch(Exception e) {
				if(File.Exists(path)) File.Delete(path);
				MessageBox.Show("保存数据时出错!\n"+e.Message,"错误");
			}
		}
	}
}
