using FruitsOrm10.Controller;
using FruitsOrm10.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruitsOrm10.View
{
	public partial class Form1 : Form
	{
		FruitLogic fruitsController = new FruitLogic();
		FruitTypeLogic fruittypesController = new FruitTypeLogic();
		public Form1()
		{
			InitializeComponent();
		}
		private void LoadRecord(Fruit fruit)
		{
			textBox1.Text = fruit.Id.ToString();
			textBox2.Text = fruit.Name;
			textBox3.Text = fruit.Price.ToString();
			comboBox1.Text = fruittypesController.GetFruitTypeById(fruit.FruitTypeId);//.GetFruitTypeById(int.Parse(textBox1.Text));
			listBox1.Items.Add(fruit.Description.ToString());

		}
		private void ClearScreen()
		{
			textBox1.BackColor = Color.White;
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
			comboBox1.Text = "";
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			List<Fruit> allTypeId = fruitsController.GetAll();
			comboBox1.DataSource = allTypeId;
			comboBox1.DisplayMember = "NameType";
			comboBox1.ValueMember = "Id";
			btnSelectAll_Click(sender, e);
		}

		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			List<Fruit> allFruts = fruitsController.GetAll();
			listBox1.Items.Clear();
			foreach (var item in allFruts)
			{
				listBox1.Items.Add($"{item.Id}. {item.Name} - {item.TypeId} -{item.Price}");
			}

		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
			{
				MessageBox.Show("Въведете данни!");
				textBox2.Focus();
				return;
			}
			Fruit newfruit = new Fruit();
			newfruit.Id = int.Parse(textBox1.Text);
			newfruit.Name = textBox2.Text;
			newfruit.Price = double.Parse(textBox3.Text);
			newfruit.FruitTypeId = (int)comboBox1.SelectedValue;
			newfruit.Description = listBox1.Text;
			fruitsController.Create(newfruit);
			MessageBox.Show("Записът е успешно добавен!");
			ClearScreen();
			btnSelectAll_Click(sender, e);
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			int findId = 0;
			if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
			{
				MessageBox.Show("Въведете Id за търсене!");
				textBox1.BackColor = Color.Red;
				textBox1.Focus();
				return;
			}
			else
			{
				findId = int.Parse(textBox1.Text);
			}
			Fruit findedfruid = fruitsController.Get(findId);
			if (findedfruid == null)
			{
				MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
				textBox1.BackColor = Color.Red;
				textBox1.Focus();
				return;
			}
			LoadRecord(findedfruid);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			int findId = 0;
			if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
			{
				MessageBox.Show("Въведете Id за търсене!");
				textBox1.BackColor = Color.Red;
				textBox1.Focus();
				return;
			}
			else
			{
				findId = int.Parse(textBox1.Text);
			}

			if (string.IsNullOrEmpty(textBox2.Text))
			{
				Fruit findedfruit = fruitsController.Get(findId);
				if (findedfruit == null)
				{
					MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
					textBox1.BackColor = Color.Red;
					textBox1.Focus();
					return;
				}
				LoadRecord(findedfruit);
			}
			else
			{
				Fruit updatedfruit = new Fruit();
				updatedfruit.Id = int.Parse(textBox1.Text);
				updatedfruit.Name = textBox2.Text;
				updatedfruit.Price = double.Parse(textBox3.Text);
				updatedfruit.FruitTypeId = (int)comboBox1.SelectedValue;
				updatedfruit.Description = listBox1.Text;
				fruitsController.Create(updatedfruit);
				MessageBox.Show("Записът е успешно променен!");

				fruitsController.Update(findId, updatedfruit);
			}
			btnSelectAll_Click(sender, e);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			int findId = 0;
			if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
			{
				MessageBox.Show("Въведете Id за търсене!");
				textBox1.BackColor = Color.Red;
				textBox1.Focus();
				return;
			}
			else
			{
				findId = int.Parse(textBox1.Text);
			}
			Fruit findedfruit = fruitsController.Get(findId);
			if (findedfruit == null)
			{
				MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
				textBox1.BackColor = Color.Red;
				textBox1.Focus();
				return;
			}
			LoadRecord(findedfruit);

			DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " + findId + " ?", "PROMPT", MessageBoxButtons.YesNo,
			MessageBoxIcon.Question);
			if (answer == DialogResult.Yes)
			{
				fruitsController.Delete(findId);
			}
			btnSelectAll_Click(sender, e);
		}
	}
}
