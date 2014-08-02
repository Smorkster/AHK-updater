using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class Tree : Form
	{
		BindingList<AHKCommand> commandsList;
		public Tree(BindingList<AHKCommand> l)
		{
			InitializeComponent();
			commandsList = l;
		}

		void fillTree()
		{
			List<TreeNode> roots = new List<TreeNode>();
			foreach(AHKCommand item in commandsList)
			{
				if (!item.System.Equals(""))
				{
					string v = item.System;
					if (!treeView1.Nodes.ContainsKey(item.System))
					{
						TreeNode tn = new TreeNode(item.System);
						tn.Name = item.System;
						treeView1.Nodes.Add(tn);
					}
					treeView1.Nodes[item.System].Nodes.Add(item.Command);
				}
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button2Click(object sender, System.EventArgs e)
		{
			fillTree();
		}
		
		void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			for (int i = 0; i < commandsList.Count; i++)
			{
				if (commandsList[i].Command == e.Node.Text)
				{
					textBox1.Text = commandsList[i].Text;
					break;
				}
			}
		}
	}
}
