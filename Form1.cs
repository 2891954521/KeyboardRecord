using System;
using System.Collections;
using System.Windows.Forms;

namespace KeyboardRecord {

	public partial class Form1 : Form {
        // 储存按键次数的类
        private Data data;
        // 监听按键按下的钩子类
        private KeyboardHook keyboardHook;
        // 一个用于处理窗口自由缩放后UI跟随窗口变化的类
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        // 用于给列表元素排序的类
        private ListViewItemComparer comparer;

        public Form1() {

			InitializeComponent();
            // 给托盘菜单的选项添加点击事件
            show.Click += ShowApp;
            exit.Click += ExitApp;
        }

		private void MainLoad(object sender,EventArgs e) {
            asc.controllInitializeSize(this);
            // 初始化需要用到的类
            data = new Data();
            keyboardHook = new KeyboardHook(data);
            comparer = new ListViewItemComparer();

            keyList.ListViewItemSorter = comparer;

            initList();
        }

        // 初始化列表
        private void initList() {
            // 把记录的数据加到ListView里去
            for(int i = 0;i<data.name.Length;i++) {
                keyList.Items.Add(new ListViewItem(new string[] { i.ToString(), data.name[i],data.nameZh[i],data.times[i].ToString() }));
            }
        }

        // 双击托盘图标显示程序主界面
        private void IconDoubleClick(object sender,MouseEventArgs e) {
            ShowApp(null,null);
        }

        // 监听窗口最小化
        private void MainSizeChanged(object sender,EventArgs e) {
            asc.controlAutoSize(this);
            if(WindowState == FormWindowState.Minimized) {
                // 最小化的时候在任务栏里隐藏
                this.ShowInTaskbar = false;
            }
        }

        // 监听右上角关闭按钮
        private void MainFormClosing(object sender,FormClosingEventArgs e) {
            // 让窗口最小化，而不是退出程序
            WindowState = FormWindowState.Minimized;
            // 取消点击事件，让系统不会关闭程序
            e.Cancel = true;
        }

        // 显示主界面
        private void ShowApp(object sender,EventArgs e) {
            if(WindowState == FormWindowState.Minimized) {
                // 还原窗口
                WindowState = FormWindowState.Normal;
                Activate();
                // 重新在任务栏里显示
                this.ShowInTaskbar = true;
            }
		}

        // 确认是否退出
        private void ExitApp(object sender,EventArgs e) {
            if(MessageBox.Show("退出程序？","退出",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) {
                // 保存数据
                data.saveData();
                // 停止监听按键
                keyboardHook.Stop();
                notifyIcon.Visible = false;
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        // 刷新列表
        private void UpdateList() {
            // 移除现有的所有Item
            keyList.Items.Clear();
            initList();
		}

        // 启动按钮
        private void status_Click(object sender,EventArgs e) {
			if(keyboardHook.IsStarted) {
                // 停止监听
                keyboardHook.Stop();
                status.Text = "开始";
                Invalidate();
			} else {
                // 启用钩子，监听按键操作
                keyboardHook.Start();
                status.Text = "停止";
                Invalidate();
            }
        }

        // 导出按钮
		private void explore_Click(object sender,EventArgs e) {
            data.saveData();
            MessageBox.Show("导出完成!","完成");
		}

        // 清除按钮
		private void clear_Click(object sender,EventArgs e) {
            if(MessageBox.Show("确定清除记录的次数？","清除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) {
                data.times = new int[data.name.Length];
                UpdateList();
            }
		}

        // List表头点击监听
		private void keyList_SelectedIndexChanged(object sender,ColumnClickEventArgs e) {
            // 设置点击的列
            comparer.setIndex(e.Column);
            // 执行排序
            keyList.Sort();
		}

	}

	public class ListViewItemComparer : IComparer {
        // 是否反向排序
        private bool flip = true;
        // 要排序的列
        private int index;

        public int Compare(object x,object y) {
            // 获取需要排序的文本
            string s1 = ((ListViewItem)x).SubItems[index].Text;
            string s2 = ((ListViewItem)y).SubItems[index].Text;
            // 正向排序/反向排序
            if(flip) return int.Parse(s1) > int.Parse(s2) ? 1 : -1;
            else return int.Parse(s1) > int.Parse(s2) ? -1 : 1;
        } 

        public void setIndex(int index) {
			// 当点击的是按键次数的列时按按键次数排序，否则就按id排序
			if(index==3) this.index = 3;
            else this.index = 0;
            // 反向排序
            flip = !flip;
		}
    }

}
