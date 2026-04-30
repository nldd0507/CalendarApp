namespace CalendarApp.GUI
{
    partial class AddAppointmentForm
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
            txtLocation = new TextBox();
            label2 = new Label();
            txtTitle = new TextBox();
            label1 = new Label();
            dtpStartTime = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            dtpEndTime = new DateTimePicker();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(132, 86);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(148, 23);
            txtLocation.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 89);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 7;
            label2.Text = "Địa điểm";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(132, 47);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(148, 23);
            txtTitle.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 50);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 5;
            label1.Text = "Tên cuộc hẹn";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(132, 124);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(148, 23);
            dtpStartTime.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 128);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 10;
            label3.Text = "Bắt đầu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 165);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 12;
            label4.Text = "Kết thúc";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(132, 160);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(148, 23);
            dtpEndTime.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(205, 189);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 278);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(dtpEndTime);
            Controls.Add(label3);
            Controls.Add(dtpStartTime);
            Controls.Add(txtLocation);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "AddAppointmentForm";
            Text = "AddAppointmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLocation;
        private Label label2;
        private TextBox txtTitle;
        private Label label1;
        private DateTimePicker dtpStartTime;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpEndTime;
        private Button btnSave;
    }
}