namespace MyTcpSubscriber
{
    partial class FSubscriber
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
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.col_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.lbl_connectionState = new System.Windows.Forms.Label();
            this.txtServerTime = new System.Windows.Forms.TextBox();
            this.btnAskService = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_time,
            this.col_information});
            this.dgvEvents.Location = new System.Drawing.Point(12, 34);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersWidth = 5;
            this.dgvEvents.RowTemplate.Height = 23;
            this.dgvEvents.Size = new System.Drawing.Size(348, 169);
            this.dgvEvents.TabIndex = 59;
            // 
            // col_time
            // 
            this.col_time.FillWeight = 50F;
            this.col_time.HeaderText = "Time";
            this.col_time.Name = "col_time";
            this.col_time.ReadOnly = true;
            this.col_time.Width = 110;
            // 
            // col_information
            // 
            this.col_information.FillWeight = 50F;
            this.col_information.HeaderText = "Information";
            this.col_information.Name = "col_information";
            this.col_information.ReadOnly = true;
            this.col_information.Width = 200;
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Enabled = false;
            this.btnUnsubscribe.Location = new System.Drawing.Point(270, 211);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(89, 23);
            this.btnUnsubscribe.TabIndex = 58;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.BtnClicked);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(176, 211);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(88, 23);
            this.btnSubscribe.TabIndex = 57;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.BtnClicked);
            // 
            // lbl_connectionState
            // 
            this.lbl_connectionState.AutoSize = true;
            this.lbl_connectionState.ForeColor = System.Drawing.Color.Red;
            this.lbl_connectionState.Location = new System.Drawing.Point(14, 11);
            this.lbl_connectionState.Name = "lbl_connectionState";
            this.lbl_connectionState.Size = new System.Drawing.Size(35, 12);
            this.lbl_connectionState.TabIndex = 56;
            this.lbl_connectionState.Text = "State";
            // 
            // txtServerTime
            // 
            this.txtServerTime.BackColor = System.Drawing.Color.White;
            this.txtServerTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServerTime.Location = new System.Drawing.Point(106, 240);
            this.txtServerTime.Multiline = true;
            this.txtServerTime.Name = "txtServerTime";
            this.txtServerTime.ReadOnly = true;
            this.txtServerTime.Size = new System.Drawing.Size(253, 23);
            this.txtServerTime.TabIndex = 53;
            // 
            // btnAskService
            // 
            this.btnAskService.Location = new System.Drawing.Point(12, 239);
            this.btnAskService.Name = "btnAskService";
            this.btnAskService.Size = new System.Drawing.Size(88, 23);
            this.btnAskService.TabIndex = 52;
            this.btnAskService.Text = "AskService";
            this.btnAskService.UseVisualStyleBackColor = true;
            this.btnAskService.Click += new System.EventHandler(this.BtnClicked);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(272, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 23);
            this.btnClear.TabIndex = 51;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClicked);
            // 
            // FSubscriber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 271);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.lbl_connectionState);
            this.Controls.Add(this.txtServerTime);
            this.Controls.Add(this.btnAskService);
            this.Controls.Add(this.btnClear);
            this.Name = "FSubscriber";
            this.Text = "Subscriber";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Label lbl_connectionState;
        private System.Windows.Forms.TextBox txtServerTime;
        private System.Windows.Forms.Button btnAskService;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_information;
    }
}

