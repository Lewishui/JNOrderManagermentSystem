namespace JNOrderManagermentSystem
{
    partial class frmaddProcuct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txsales = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txaddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txproductno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txproductname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txsales
            // 
            this.txsales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txsales.Location = new System.Drawing.Point(80, 65);
            this.txsales.Multiline = true;
            this.txsales.Name = "txsales";
            this.txsales.Size = new System.Drawing.Size(306, 28);
            this.txsales.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(393, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 91;
            this.label13.Text = "商品产地";
            // 
            // txaddress
            // 
            this.txaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txaddress.Location = new System.Drawing.Point(473, 65);
            this.txaddress.Multiline = true;
            this.txaddress.Name = "txaddress";
            this.txaddress.Size = new System.Drawing.Size(306, 28);
            this.txaddress.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 34);
            this.label14.TabIndex = 89;
            this.label14.Text = "商品单价";
            // 
            // txproductno
            // 
            this.txproductno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txproductno.Location = new System.Drawing.Point(80, 12);
            this.txproductno.Multiline = true;
            this.txproductno.Name = "txproductno";
            this.txproductno.Size = new System.Drawing.Size(306, 28);
            this.txproductno.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(393, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 28);
            this.label11.TabIndex = 87;
            this.label11.Text = "商品名称";
            // 
            // txproductname
            // 
            this.txproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txproductname.Location = new System.Drawing.Point(473, 12);
            this.txproductname.Multiline = true;
            this.txproductname.Name = "txproductname";
            this.txproductname.Size = new System.Drawing.Size(306, 28);
            this.txproductname.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 85;
            this.label12.Text = "商品型号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 100;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmaddcustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 168);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txsales);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txaddress);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txproductno);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txproductname);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmaddcustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增客户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txsales;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txaddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txproductno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txproductname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}