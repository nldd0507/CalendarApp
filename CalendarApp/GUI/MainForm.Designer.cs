namespace CalendarApp.GUI
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            monthCalendar1 = new MonthCalendar();
            dgvAppointments = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            xóaLịchHẹnToolStripMenuItem = new ToolStripMenuItem();
            btnAddAppointment = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(18, 18);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // dgvAppointments
            // 
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.ContextMenuStrip = contextMenuStrip1;
            dgvAppointments.Location = new Point(257, 18);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.Size = new Size(404, 197);
            dgvAppointments.TabIndex = 1;
            dgvAppointments.CellMouseDown += dgvAppointments_CellMouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { xóaLịchHẹnToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(140, 26);
            // 
            // xóaLịchHẹnToolStripMenuItem
            // 
            xóaLịchHẹnToolStripMenuItem.Name = "xóaLịchHẹnToolStripMenuItem";
            xóaLịchHẹnToolStripMenuItem.Size = new Size(139, 22);
            xóaLịchHẹnToolStripMenuItem.Text = "Xóa lịch hẹn";
            xóaLịchHẹnToolStripMenuItem.Click += xóaLịchHẹnToolStripMenuItem_Click;
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Location = new Point(122, 192);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(123, 23);
            btnAddAppointment.TabIndex = 2;
            btnAddAppointment.Text = "Thêm lịch hẹn";
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 259);
            Controls.Add(btnAddAppointment);
            Controls.Add(dgvAppointments);
            Controls.Add(monthCalendar1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private DataGridView dgvAppointments;
        private Button btnAddAppointment;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem xóaLịchHẹnToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}