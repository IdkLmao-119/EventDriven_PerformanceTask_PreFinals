namespace Performance_Task___Team_JCAEK_
{
    partial class NewItemForm
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
            this.MenuButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InternalNolbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DescriptionTxtBox = new System.Windows.Forms.RichTextBox();
            this.NameTxtBox = new System.Windows.Forms.TextBox();
            this.TypeTxtBox = new System.Windows.Forms.TextBox();
            this.StockTxtBox = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MenuButton
            // 
            this.MenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButton.Location = new System.Drawing.Point(13, 13);
            this.MenuButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(103, 29);
            this.MenuButton.TabIndex = 1;
            this.MenuButton.Text = "Main Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Internal Code:";
            // 
            // InternalNolbl
            // 
            this.InternalNolbl.AutoSize = true;
            this.InternalNolbl.ForeColor = System.Drawing.Color.White;
            this.InternalNolbl.Location = new System.Drawing.Point(119, 55);
            this.InternalNolbl.Name = "InternalNolbl";
            this.InternalNolbl.Size = new System.Drawing.Size(0, 18);
            this.InternalNolbl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Product Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Product Stock:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Product Description:";
            // 
            // DescriptionTxtBox
            // 
            this.DescriptionTxtBox.Location = new System.Drawing.Point(13, 196);
            this.DescriptionTxtBox.Name = "DescriptionTxtBox";
            this.DescriptionTxtBox.Size = new System.Drawing.Size(423, 88);
            this.DescriptionTxtBox.TabIndex = 8;
            this.DescriptionTxtBox.Text = "";
            // 
            // NameTxtBox
            // 
            this.NameTxtBox.Location = new System.Drawing.Point(126, 83);
            this.NameTxtBox.Name = "NameTxtBox";
            this.NameTxtBox.Size = new System.Drawing.Size(310, 24);
            this.NameTxtBox.TabIndex = 9;
            // 
            // TypeTxtBox
            // 
            this.TypeTxtBox.Location = new System.Drawing.Point(126, 114);
            this.TypeTxtBox.Name = "TypeTxtBox";
            this.TypeTxtBox.Size = new System.Drawing.Size(310, 24);
            this.TypeTxtBox.TabIndex = 10;
            // 
            // StockTxtBox
            // 
            this.StockTxtBox.Location = new System.Drawing.Point(126, 144);
            this.StockTxtBox.Name = "StockTxtBox";
            this.StockTxtBox.Size = new System.Drawing.Size(310, 24);
            this.StockTxtBox.TabIndex = 11;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBtn.Location = new System.Drawing.Point(148, 302);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(140, 29);
            this.SubmitBtn.TabIndex = 12;
            this.SubmitBtn.Text = "Create";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            // 
            // NewItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(448, 344);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.StockTxtBox);
            this.Controls.Add(this.TypeTxtBox);
            this.Controls.Add(this.NameTxtBox);
            this.Controls.Add(this.DescriptionTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InternalNolbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewItemForm";
            this.Text = "New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label InternalNolbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox DescriptionTxtBox;
        private System.Windows.Forms.TextBox NameTxtBox;
        private System.Windows.Forms.TextBox TypeTxtBox;
        private System.Windows.Forms.TextBox StockTxtBox;
        private System.Windows.Forms.Button SubmitBtn;
    }
}