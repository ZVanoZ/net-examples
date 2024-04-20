namespace ComponentsDemo.DataGridViewDemo
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            status = new DataGridViewTextBoxColumn();
            criatedAt = new DataGridViewTextBoxColumn();
            modifiedAt = new DataGridViewTextBoxColumn();
            Path = new DataGridViewTextBoxColumn();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { status, criatedAt, modifiedAt, Path });
            dataGridView1.Location = new Point(28, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(521, 150);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(579, 51);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // status
            // 
            status.HeaderText = "Статус";
            status.Name = "status";
            status.Resizable = DataGridViewTriState.True;
            // 
            // criatedAt
            // 
            criatedAt.HeaderText = "Создан";
            criatedAt.Name = "criatedAt";
            // 
            // modifiedAt
            // 
            modifiedAt.HeaderText = "Модифицирован";
            modifiedAt.Name = "modifiedAt";
            // 
            // Path
            // 
            Path.HeaderText = "Путь";
            Path.Name = "Path";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(63, 19);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 378);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn criatedAt;
        private DataGridViewTextBoxColumn modifiedAt;
        private DataGridViewTextBoxColumn Path;
        private GroupBox groupBox1;
        private Button buttonAdd;
    }
}