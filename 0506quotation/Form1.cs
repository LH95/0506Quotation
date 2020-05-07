using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0506quotation
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;

        public Form1()
        {
            InitializeComponent();
            //dinnerParty = new DinnerParty() { NumberOfPeople = 5 };
            dinnerParty = new DinnerParty((int)numericUpDown1.Value, healthyBox.Checked, fancyBox.Checked);
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            dinnerParty.CalculateCostOfDecorations(fancyBox.Checked);
            DisplayDinnerPartyCost();
        }

        //有變動就會更新
        private void DisplayDinnerPartyCost()
        {
            //重新計算總價格
            decimal Cost = dinnerParty.Colculatecoast(healthyBox.Checked);
            //"c" 傳送給ToString() 費用會格式化成當地貨幣值 NT$
            costLabel.Text = Cost.ToString("c");
            //f3 三位小數
            //costLabel.Text = Cost.ToString("f3");
            //%
            //costLabel.Text = Cost.ToString("0");
            //n 每三位就有逗號隔開
            //costLabel.Text = Cost.ToString("n");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //hook up值
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value;
            DisplayDinnerPartyCost();
        }

        private void fancyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.CalculateCostOfDecorations(fancyBox.Checked);
            DisplayDinnerPartyCost();
        }

        private void healthyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            DisplayDinnerPartyCost();
        }
    }
}
