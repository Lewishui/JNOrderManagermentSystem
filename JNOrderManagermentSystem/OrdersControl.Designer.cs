﻿namespace JNOrderManagermentSystem
{
    partial class OrdersControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentPanel = new System.Windows.Forms.Panel();
            this.crystalButton6 = new JNOrderManagermentSystem.CrystalButton();
            this.crystalButton5 = new JNOrderManagermentSystem.CrystalButton();
            this.crystalButton4 = new JNOrderManagermentSystem.CrystalButton();
            this.crystalButton3 = new JNOrderManagermentSystem.CrystalButton();
            this.crystalButton2 = new JNOrderManagermentSystem.CrystalButton();
            this.crystalButton1 = new JNOrderManagermentSystem.CrystalButton();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contentPanel.Controls.Add(this.crystalButton6);
            this.contentPanel.Controls.Add(this.crystalButton5);
            this.contentPanel.Controls.Add(this.crystalButton4);
            this.contentPanel.Controls.Add(this.crystalButton3);
            this.contentPanel.Controls.Add(this.crystalButton2);
            this.contentPanel.Controls.Add(this.crystalButton1);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(796, 403);
            this.contentPanel.TabIndex = 0;
            // 
            // crystalButton6
            // 
            this.crystalButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalButton6.BackColor = System.Drawing.Color.Red;
            this.crystalButton6.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.crystalButton6.Location = new System.Drawing.Point(655, 333);
            this.crystalButton6.Name = "crystalButton6";
            this.crystalButton6.Size = new System.Drawing.Size(129, 58);
            this.crystalButton6.TabIndex = 11;
            this.crystalButton6.Text = "退出系统";
            this.crystalButton6.UseVisualStyleBackColor = false;
            this.crystalButton6.Click += new System.EventHandler(this.shippedOrderButton_Click);
            // 
            // crystalButton5
            // 
            this.crystalButton5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crystalButton5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.crystalButton5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.crystalButton5.Location = new System.Drawing.Point(202, 284);
            this.crystalButton5.Name = "crystalButton5";
            this.crystalButton5.Size = new System.Drawing.Size(309, 58);
            this.crystalButton5.TabIndex = 10;
            this.crystalButton5.Text = "工作日志";
            this.crystalButton5.UseVisualStyleBackColor = false;
            this.crystalButton5.Click += new System.EventHandler(this.button4_Click);
            // 
            // crystalButton4
            // 
            this.crystalButton4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crystalButton4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.crystalButton4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.crystalButton4.Location = new System.Drawing.Point(202, 216);
            this.crystalButton4.Name = "crystalButton4";
            this.crystalButton4.Size = new System.Drawing.Size(309, 58);
            this.crystalButton4.TabIndex = 9;
            this.crystalButton4.Text = "信息中心";
            this.crystalButton4.UseVisualStyleBackColor = false;
            this.crystalButton4.Click += new System.EventHandler(this.pendingButton_Click);
            // 
            // crystalButton3
            // 
            this.crystalButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crystalButton3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.crystalButton3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.crystalButton3.Location = new System.Drawing.Point(202, 148);
            this.crystalButton3.Name = "crystalButton3";
            this.crystalButton3.Size = new System.Drawing.Size(309, 58);
            this.crystalButton3.TabIndex = 8;
            this.crystalButton3.Text = "订单";
            this.crystalButton3.UseVisualStyleBackColor = false;
            this.crystalButton3.Click += new System.EventHandler(this.newButton_Click);
            // 
            // crystalButton2
            // 
            this.crystalButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crystalButton2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.crystalButton2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.crystalButton2.Location = new System.Drawing.Point(202, 80);
            this.crystalButton2.Name = "crystalButton2";
            this.crystalButton2.Size = new System.Drawing.Size(309, 58);
            this.crystalButton2.TabIndex = 7;
            this.crystalButton2.Text = "产品";
            this.crystalButton2.UseVisualStyleBackColor = false;
            this.crystalButton2.Click += new System.EventHandler(this.orderConfirmButton_Click);
            // 
            // crystalButton1
            // 
            this.crystalButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crystalButton1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.crystalButton1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.crystalButton1.Location = new System.Drawing.Point(202, 12);
            this.crystalButton1.Name = "crystalButton1";
            this.crystalButton1.Size = new System.Drawing.Size(309, 58);
            this.crystalButton1.TabIndex = 6;
            this.crystalButton1.Text = "客户";
            this.crystalButton1.UseVisualStyleBackColor = false;
            this.crystalButton1.Click += new System.EventHandler(this.receiveOrderButton_Click);
            // 
            // OrdersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(796, 403);
            this.Controls.Add(this.contentPanel);
            this.Font = new System.Drawing.Font("MS PGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrdersControl";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.OrdersControl_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.OrdersControl_ControlRemoved);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OrdersControl_Paint);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        private CrystalButton crystalButton1;
        private CrystalButton crystalButton5;
        private CrystalButton crystalButton4;
        private CrystalButton crystalButton3;
        private CrystalButton crystalButton2;
        private CrystalButton crystalButton6;
    }
}
