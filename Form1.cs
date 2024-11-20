using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void UpdateSize()
        {
            UpdateTotalPrice();
            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
            if (rbMeduim.Checked)
            {
                lblSize.Text = "Meduim";
                return;
            }
            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";
            if (chkExtraChees.Checked)
            {
                sToppings += "Extra Chees";
            }
            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }
            if (chkGreenPeppes.Checked)
            {
                sToppings += ", GreenPeppes";
            }
            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }
            if (chkOnion.Checked)
            {
                sToppings += ", Onion";
            }
            if(chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }
            if(sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1);
            }
            if(sToppings == "")
            {
                sToppings = "No Toppings";
            }
            lblToppings.Text = sToppings;
        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }
            if (rbThick.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }
        }
        void UpdateWhereToEat()
        {
            UpdateTotalPrice();
            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }
            if (rbEatOut.Checked)
            {
                lblWhereToEat.Text = "Take Away";
                return;
            }
        }
        float GetSelectedSizePrice()
        {
            if(rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMeduim.Checked)
                return Convert.ToSingle(rbMeduim.Tag);
            else
                return Convert.ToSingle(rbLarge.Tag);
        }
        float GetSelectedCrustPrice()
        {
            if(rbThin.Checked)
                return Convert.ToSingle(rbThin.Tag);
            else
                return Convert.ToSingle(rbThick.Tag);

        }
        float GetSelectedToppingsPrice()
        {
            float TotalToppings = 0;
            if(chkExtraChees.Checked)
            {
                TotalToppings += Convert.ToSingle(chkExtraChees.Tag);
            }
            if(chkMushrooms.Checked)
            {
                TotalToppings += Convert.ToSingle(chkMushrooms.Tag);
            }
            if (chkGreenPeppes.Checked)
            {
                TotalToppings += Convert.ToSingle(chkGreenPeppes.Tag);
            }
            if (chkOlives.Checked)
            {
                TotalToppings += Convert.ToSingle(chkOlives.Tag);
            }
            if (chkOnion.Checked)
            {
                TotalToppings += Convert.ToSingle(chkOnion.Tag);
            }
            if (chkTomatoes.Checked)
            {
                TotalToppings += Convert.ToSingle(chkTomatoes.Tag);
            }
            return TotalToppings;
        }
        float CalculateTotalPrice()
        {
            return GetSelectedCrustPrice() + GetSelectedToppingsPrice() + GetSelectedSizePrice();
        }
        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
            
        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();

        }
        void ResetForm()
        {

            //reset Groups
            grSize.Enabled = true;
            grToppings.Enabled = true;
            grCrustType.Enabled = true;
            grWhereToEat.Enabled = true;

            //reset Size
            rbSmall.Checked = true;

            //reset Toppings.
            chkExtraChees.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPeppes.Checked = false;

            //reset CrustType
            rbThin.Checked = true;

            //reset Where to Eat
            rbEatIn.Checked = true;

            //Reset Order Button
            btnOrderPizza.Enabled = true;
        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbEatOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void chkExtraChees_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkGreenPeppes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void btnOrder_Pizza(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                MessageBox.Show("Order Placed Successfully", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                grSize.Enabled = false;
                grCrustType.Enabled = false;
                grWhereToEat.Enabled = false;
                grToppings.Enabled = false;
                btnOrderPizza.Enabled = false;

            }
            else
                MessageBox.Show("Udpate your order", "Update", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
        private void btnReset_Form(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void rbThin_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
