using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Paaku_Management
{
    
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gridview();
            gridview1();
            gridviewemppayment();
            gridviewempattn();
            gridviewstock();
            gridviewvendor();     
            gridviewempdetails();
            gridviewcustdetails();
            loadvendorpayment();
            loadvendorpurchase();
           loadsalesid();
            loademppayment();
            loadempname();
            loadstockitem();
            loadstockitemsales();
            loadcustsales();
            cmb_item.Text = null;
            Cmb_Vendor.Text = null;
            cmb_Vendor_Payment.Text = null;
            cmb_Emp_Purchase_Id.Text  = null;
            cmb_Emp_Name_Pay.Text = null;
            cmb_sales_item.Text = null;
            cmb_customer_sales.Text = null;
           // lbl_total_payment.Text = "0.00";
           cmb_sales_id.Text = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void gridview()
        {
            try
            {
                String query = "Select a.purchase_id,a.purchase_date,b.vendor_name,a.quantity,a.rate,a.total,a.remarks from tbl_purchase a,tbl_vendors b where a.vendor_id=b.vendor_id ";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgrd_Purchase.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        private void btn_Save_PurchsDtls_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
                int quantity = Int32.Parse(Txt_Quantity.Text.ToString());
                int rate = Int32.Parse(txt_Rate.Text.ToString());
                string query = "INSERT INTO tbl_purchase(vendor_id,quantity,Rate,remarks,trs_year_id,purchase_date,total)Values('" + Cmb_Vendor.SelectedValue + "', '" + Txt_Quantity.Text + "', '" + txt_Rate.Text + "', '" + txt_Remarks.Text + "','1','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + quantity * rate + "')";
                db.insertOrUpdate(query);
                Cmb_Vendor.Text = "";
                Txt_Quantity.Text = "";
                txt_Rate.Text = "";
                txt_Remarks.Text = "";
                Cmb_Vendor.Text = null;
                gridview();
                loademppayment();
                MessageBox.Show("Purchased Successfully", "Purchase Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Save_Payment_Click(object sender, EventArgs e)
        {
           
        }
        public void gridview1()
        {
            try
            {
                String query = "Select a.payment_id,a.payment_date,b.vendor_name,a.payment_amount,a.remarks from tbl_purchase_payment a,tbl_vendors b where a.vendor_id=b.vendor_id";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView_Payment.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void gridviewemppayment()
        {
            try
            {
                String query = "Select emp_id,emp_name from tbl_employees where emp_type='P'";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_Emp_Payment.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public void gridviewstock()
        {
            try
            {
                String query = "Select b.item_name,a.stock_weight,a.date from tbl_stock a,tbl_item b where b.item_id=a.item_id";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_stock.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void gridviewempattn()
        {
            try
            {
                String query = "Select emp_id,emp_name from tbl_employees where emp_type='D'";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_Emp_attn.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void gridviewvendor()
        {
            try
            {
                String query = "Select vendor_name,mobile_no,address,remarks from tbl_vendors";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_vendor_details.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void gridviewempdetails()
        {
            try
            {
                String query = "Select emp_name,emp_aadhar_number,emp_type,valid from tbl_employees";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_emp_details .DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void gridviewcustdetails()
        {
            try
            {
                String query = "Select customer_name,mobile_number,address,valid from tbl_customer_details";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_cust_details .DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public void updateemppayment()
        {
            try
            {
                String query = "Select a.emp_id,a.no_of_bags,a.total,a.remarks,b.emp_name from tbl_peeling_details a,tbl_employees b where a.emp_id=b.emp_id and a.purchase_id='" + cmb_Emp_Purchase_Id .Text+"'";
                DBConnection db = new DBConnection();
                db.OpenConnection();
                MySqlDataAdapter da = db.selectadapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_Emp_Payment.DataSource = dt;

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public void loadvendorpurchase()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select vendor_id,vendor_name from tbl_vendors where valid='Y'";
            DataTable proofnum = db.select(query);
            Cmb_Vendor.DataSource = proofnum;
            Cmb_Vendor.ValueMember = "vendor_id";
            Cmb_Vendor.DisplayMember = "vendor_name";
        }
        public void loadsalesid()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select sales_id from tbl_sales";
            DataTable proofnum = db.select(query);
        cmb_sales_id .DataSource = proofnum;
           // cmb_sales_id.ValueMember = "sales_id";s
            cmb_sales_id.DisplayMember = "sales_id";
        }
        public void loadvendorpayment()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select vendor_id,vendor_name from tbl_vendors where valid='Y'";
            DataTable proofnum = db.select(query);
            cmb_Vendor_Payment .DataSource = proofnum;
            cmb_Vendor_Payment.ValueMember = "vendor_id";
            cmb_Vendor_Payment.DisplayMember = "vendor_name";
        }
        public void loademppayment()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select purchase_id,vendor_id from tbl_purchase";
            DataTable proofnum = db.select(query);
            cmb_Emp_Purchase_Id .DataSource = proofnum;
            cmb_Emp_Purchase_Id.ValueMember = "vendor_id";
            cmb_Emp_Purchase_Id .DisplayMember = "purchase_id";
        }
        public void loadempname()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "Select emp_id,emp_name from tbl_employees where emp_type='D'";
            DataTable proofnum = db.select(query);
            cmb_Emp_Name_Pay.DataSource = proofnum;
            cmb_Emp_Name_Pay.ValueMember = "emp_id";
            cmb_Emp_Name_Pay.DisplayMember = "emp_name";
        }
      public void loadstockitem()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select item_id,item_name from tbl_item";
            DataTable proofnum = db.select(query);
            cmb_item.DataSource = proofnum;
            cmb_item.ValueMember = "item_id";
            cmb_item.DisplayMember = "item_name";
        }
        public void loadstockitemsales()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select item_id,item_name from tbl_item";
            DataTable proofnum = db.select(query);
            cmb_sales_item .DataSource = proofnum;
            cmb_sales_item.ValueMember = "item_id";
            cmb_sales_item.DisplayMember = "item_name";
        }
        public void loadcustsales()
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "select customer_id,customer_name from tbl_customer_details";
            DataTable proofnum = db.select(query);
            cmb_customer_sales.DataSource = proofnum;
            cmb_customer_sales.ValueMember = "customer_id";
            cmb_customer_sales.DisplayMember = "customer_name";
        }
/*public void loadvendordetails()
        {
            try
            {
                //grid_Emp_Payment.Columns["Employee_id"].Visible = false;
                for (int rows = 0; rows < grid_vendor_details .Rows.Count; rows++)
                {
                    string vendor_name = grid_vendor_details.Rows[rows].Cells["Vendor_name"].Value.ToString();
                    int mobno = Int32.Parse(grid_vendor_details.Rows[rows].Cells["Mobile_no"].Value.ToString());
                    //int rate_per_bag = Int32.Parse(txt_Emp_Rate_Per_Bag.Text.ToString());
                    String emp_attn = grid_vendor_details.Rows[rows].Cells["Address_vendor"].Value.ToString();
                    String emp_remarks = grid_vendor_details.Rows[rows].Cells["remarks_vendor"].Value.ToString();
                    string query = "insert into tbl_peeling_details(purchase_id,emp_id,remarks,no_of_bags,total,rate,date) " +
                       " values('" + cmb_Emp_Purchase_Id.Text + "','" + emp_id1 + "','" + emp_remarks + "','" + no_of_bags + "','" + no_of_bags * rate_per_bag + "','" + rate_per_bag + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "')";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    // CheckBox chk = grid_Emp_Payment.Rows[rows].Cells[0].Controls[0] as CheckBox;
                    // if (chk != null && chk.Checked)
                    // { 
                    // if(grid_Emp_Payment.Rows[rows].Cells["Employee_remarks"].)
                    // string query1 = "insert into tbl_employee_attn_sal(emp_id,attendance,remarks,emp_salary,paid_status,date) " +
                    //   " values('" + emp_id1 + "','" + emp_attn + "','" + emp_remarks + "','" + no_of_bags * rate_per_bag + "','Y','" + dateTimePicker3.Value.ToString("DD-MM-YYYY") + "')";
                    // db.insertOrUpdate(query1);
                    // }
                    db.insertOrUpdate(query);
                }
                MessageBox.Show("Saved Successfully", "Employee Peeling Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }*/
        private void insertemppayment()
        {
            try {
                //grid_Emp_Payment.Columns["Employee_id"].Visible = false;
                for (int rows = 0; rows < grid_Emp_Payment.Rows.Count ; rows++)
                {
                    int emp_id1 = Int32.Parse(grid_Emp_Payment.Rows[rows].Cells["Employee_id"].Value.ToString());
                    int no_of_bags = Int32.Parse(grid_Emp_Payment.Rows[rows].Cells["No_of_Bags"].Value.ToString());
                    int rate_per_bag = Int32.Parse(txt_Emp_Rate_Per_Bag.Text.ToString());
                    //String emp_attn = grid_Emp_Payment.Rows[rows].Cells["Attendence"].Value.ToString();
                    String emp_remarks = grid_Emp_Payment.Rows[rows].Cells["Employee_remarks"].Value.ToString();
                    string query = "insert into tbl_peeling_details(purchase_id,emp_id,remarks,no_of_bags,total,rate,date) " +
                       " values('" + cmb_Emp_Purchase_Id.Text + "','" + emp_id1 + "','" + emp_remarks + "','" + no_of_bags + "','" + no_of_bags * rate_per_bag + "','" + rate_per_bag + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "')";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    // CheckBox chk = grid_Emp_Payment.Rows[rows].Cells[0].Controls[0] as CheckBox;
                    // if (chk != null && chk.Checked)
                    // { 
                    // if(grid_Emp_Payment.Rows[rows].Cells["Employee_remarks"].)
                    // string query1 = "insert into tbl_employee_attn_sal(emp_id,attendance,remarks,emp_salary,paid_status,date) " +
                    //   " values('" + emp_id1 + "','" + emp_attn + "','" + emp_remarks + "','" + no_of_bags * rate_per_bag + "','Y','" + dateTimePicker3.Value.ToString("DD-MM-YYYY") + "')";
                    // db.insertOrUpdate(query1);
                    // }
                    db.insertOrUpdate(query);
                }
                MessageBox.Show("Saved Successfully", "Employee Peeling Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        private void insertempattn()
        {
            try {
                //grid_Emp_Payment.Columns["Employee_id"].Visible = false;
                for (int rows = 0; rows < grid_Emp_attn.Rows.Count; rows++)
                {
                    int emp_id1 = Int32.Parse(grid_Emp_attn.Rows[rows].Cells["Employee_id_attn"].Value.ToString());
                    int sal = Int32.Parse(grid_Emp_attn.Rows[rows].Cells["emp_salary"].Value.ToString());
                    // int rat = Int32.Parse(txt_Emp_Rate_Per_Bag.Text.ToString());
                    String emp_attn = grid_Emp_attn.Rows[rows].Cells["Attendence"].Value.ToString();
                    String emp_remarks = grid_Emp_attn.Rows[rows].Cells["Remarks_attn"].Value.ToString();
                    string query = "insert into tbl_employee_attn_sal(emp_id,remarks,emp_salary,date,attendance) " +
                       " values('" + emp_id1 + "','" + emp_remarks + "','" + sal + "','" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "','" + emp_attn + "')";
                    DBConnection db = new DBConnection();
                    db.OpenConnection();
                    // CheckBox chk = grid_Emp_Payment.Rows[rows].Cells[0].Controls[0] as CheckBox;
                    // if (chk != null && chk.Checked)
                    // { 
                    // if(grid_Emp_Payment.Rows[rows].Cells["Employee_remarks"].)
                    // string query1 = "insert into tbl_employee_attn_sal(emp_id,attendance,remarks,emp_salary,paid_status,date) " +
                    //   " values('" + emp_id1 + "','" + emp_attn + "','" + emp_remarks + "','" + no_of_bags * rate_per_bag + "','Y','" + dateTimePicker3.Value.ToString("DD-MM-YYYY") + "')";
                    // db.insertOrUpdate(query1);
                    // }
                    db.insertOrUpdate(query);
                }
                MessageBox.Show("Saved Successfully", "Employee Attendence Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }

        private void Cmb_Vendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime FromDate;
            FromDate = Convert.ToDateTime(dateTimePicker1.Value.Date.ToString("yyyy-MMM-dd"));
        }

        private void btn_Save_Payment_Click_1(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
                string query = "INSERT INTO tbl_purchase_payment(vendor_id,payment_amount,payment_type,remarks,trs_year_id,payment_date)Values('" + cmb_Vendor_Payment.SelectedValue + "', '" + txt_Payment_Amount.Text + "', '" + cmb_Vendor_Payment.Text + "', '" + txt_Remarks_Payment.Text + "','1','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                db.insertOrUpdate(query);
                txt_Payment_Amount.Text = "";
                cmb_Payment_Type.Text = "";
                txt_Remarks_Payment.Text = "";
                cmb_Vendor_Payment.Text = null;
                gridview1();
                MessageBox.Show("Paid Successfully", "Payment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void emppayment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.ColumnIndex == grid_Emp_Payment.Columns["No_of_Bags"].Index)
                {
                    //int discnt = Int32.Parse(dataGridBillMachineDetils.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    //int no_of_bags = Int32.Parse(grid_Emp_Payment.Rows[rows].Cells["No_of_Bags"].Value.ToString());
                    // int rate_per_bag = Int32.Parse(txt_Emp_Rate_Per_Bag.Text.ToString());
                    // int total = no_of_bags * rate_per_bag;
                    int total = (Int32.Parse(grid_Emp_Payment.Rows[e.RowIndex].Cells["No_of_Bags"].Value.ToString()) * Int32.Parse(txt_Emp_Rate_Per_Bag.Text.ToString()));
                    grid_Emp_Payment.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = total;
                    //setTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Emp_Pay_Save_Click(object sender, EventArgs e)
        {
            insertemppayment();
            cmb_Emp_Purchase_Id.Text = null;
            txt_Emp_Bag_Weight.Text = null;
            txt_Emp_Rate_Per_Bag.Text = null;
            gridviewemppayment();
            //this.grid_Emp_Payment.DataSource = null;
            //gridviewemppayment();
            //this.grid_Emp_Payment.Rows.Clear();
            //grid_Emp_Payment.Refresh();
        }

        private void grid_Emp_Payment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }
        private void leave(object sender, EventArgs e)
        {
            int total = (Int32.Parse(txt_weight_sales.Text) * Int32.Parse(txt_rate_sales.Text));
            lbl_total_sales.Text = total.ToString ();
        }
        private void leavebalance(object sender, EventArgs e)
        {
            int total = (Int32.Parse(lbl_total_payment.Text) - Int32.Parse(txt_payment_amount_pay.Text));
            // int total = (Int32.Parse(textBox1.Text )- Int32.Parse(txt_payment_amount_pay.Text));
            lbl_bal_pay .Text = total.ToString();
        }
      private void leavetotalbalance(object sender, EventArgs e)
        {
          string query = "select total from tbl_sales where sales_id='"+cmb_sales_id .SelectedText +"'";
            DBConnection db = new DBConnection();
            db.OpenConnection();
           // string query = "select vendor_id,vendor_name from tbl_vendors where valid='Y'";
            DataTable proofnum = db.select(query);
          //  int total = Int32.Parse(proofnum.ToString());
            lbl_total_payment.Text = proofnum.ToString ();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgrd_Purchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Save_Emp_attn_Click(object sender, EventArgs e)
        {
            insertempattn();
        }

        private void dataGridView_Payment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_emp_payment_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
               // int quantity = Int32.Parse(Txt_Quantity.Text.ToString());
               // int rate = Int32.Parse(txt_Rate.Text.ToString());
                string query = "INSERT INTO tbl_employee_payments(emp_id,payment_date,payment_amount,payment_type)Values('" + cmb_Emp_Name_Pay.SelectedValue + "', '" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "','"+txt_amount_payment.Text+"', '" + cmb_Payment_Reason.SelectedText + "')";
                db.insertOrUpdate(query);
                cmb_Payment_Reason.Text = "";
                txt_amount_payment.Text = "";
                cmb_Emp_Name_Pay.Text = null;
                MessageBox.Show("Employee Payment Successfull", "Employee Payment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_save_stock_Enter(object sender, EventArgs e)
        {

        }

        private void btn_save_item_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
               // int quantity = Int32.Parse(Txt_Quantity.Text.ToString());
               // int rate = Int32.Parse(txt_Rate.Text.ToString());
              //  string query = "INSERT INTO tbl_it(item_name,item_desc,date)Values('" + textBox1.Text + "','" + txt_desc_item.Text + "', '"+ dateTimePicker4.Value.ToString("yyyy-MM-dd") + "')";
                string query = "INSERT INTO tbl_stock(item_id,stock_weight,date)Values('"+cmb_item.SelectedValue+"', '" + txt_weight_stock.Text + "', '" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "')";
                db.insertOrUpdate(query);
                txt_weight_stock.Text = "";
                cmb_item.Text = null;
                MessageBox.Show("Item added Successfully", "Item Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridviewstock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lbl_total_sales_Click(object sender, EventArgs e)
        {

        }

        private void grid_stock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click_1(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_cust_mobnum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_vendor_save_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
                string query = "INSERT INTO tbl_vendors(vendor_name,mobile_no,address,remarks)Values('" + txt_vendor_name.Text + "','" + txt_vendor_mobnum.Text + "','" + rchtxtbx_vendor_address.Text + "','" + rchtxtbx_vendor_remarks.Text + "')";
                db.insertOrUpdate(query);
                txt_vendor_name.Text = "";
                txt_vendor_mobnum.Text = "";
                rchtxtbx_vendor_address.Text = "";
                rchtxtbx_vendor_remarks.Text = "";
                gridviewvendor();
                loadvendorpurchase();
                MessageBox.Show("Vendor Added Successfully", "Payment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_employee_save_Click(object sender, EventArgs e)
        {
          
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
                string query = "INSERT INTO tbl_employees(emp_name,emp_aadhar_number,emp_type,trs_year_id)Values('" + txt_employee_name.Text + "','" + txt_employee_aatharnum.Text + "','" + cmb_emp_type.Text + "','1')";
                db.insertOrUpdate(query);
                txt_employee_name.Text = "";
                txt_employee_aatharnum.Text = "";
                cmb_emp_type.Text = null;
                gridviewempdetails();
                MessageBox.Show("Employee Added Successfully", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cust_save_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();
                db.OpenConnection();
                string query = "INSERT INTO tbl_customer_details(customer_name,mobile_number,address)Values('" + txt_cust_name.Text + "','" + txt_cust_mobnum.Text + "','" + rich_cust_address.Text + "')";
                db.insertOrUpdate(query);
                txt_cust_name.Text = "";
                txt_cust_mobnum.Text = "";
                rich_cust_address.Text = "";
                gridviewcustdetails();
                MessageBox.Show("Customer Added Successfully", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "INSERT INTO tbl_sales_payment(sales_id,payment_amount,payment_type,payment_date)Values('" + cmb_sales_id.Text + "','" + txt_payment_amount_pay.Text + "','" + cmb_Payment_Type.Text + "','" + dateTimePicker6.Value.ToString("yyyy-MM-dd") + "')";
            db.insertOrUpdate(query);
           lbl_bal_pay.Text = "0.00";
           txt_payment_amount_pay .Text = "";
            cmb_payment_type_sales .Text = "";
            cmb_sales_item.Text = null;
            // gridviewvendor();
            MessageBox.Show("Sales Payment Successfull", "Payment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            db.OpenConnection();
            string query = "INSERT INTO tbl_sales(item_id,customer_id,sales_weight,rate_per_kg,total,date)Values('" +cmb_sales_item .SelectedValue + "','" + cmb_customer_sales .SelectedValue + "','" +txt_weight_sales .Text + "','" + txt_rate_sales.Text + "','"+lbl_total_sales .Text +"','" + dateTimePicker5.Value.ToString("yyyy-MM-dd") + "')";
            db.insertOrUpdate(query);
           lbl_total_sales  .Text = "0.00";
            txt_rate_sales.Text = "";
            txt_weight_sales.Text = "";
            cmb_sales_item.Text = null;
            cmb_customer_sales.Text = null;
           // gridviewvendor();
            MessageBox.Show("Sales Successfull", "Sales Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }
    }
    
    
}
