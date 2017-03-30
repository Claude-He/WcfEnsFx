namespace MyPublisher
{
    partial class FPublisher
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
            this.btnRaiseEvent = new System.Windows.Forms.Button();
            this.txtEventMessage = new System.Windows.Forms.TextBox();
            this.btnEventWithNumber = new System.Windows.Forms.Button();
            this.txtEventNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRaiseEvent
            // 
            this.btnRaiseEvent.Location = new System.Drawing.Point(173, 12);
            this.btnRaiseEvent.Name = "btnRaiseEvent";
            this.btnRaiseEvent.Size = new System.Drawing.Size(91, 23);
            this.btnRaiseEvent.TabIndex = 4;
            this.btnRaiseEvent.Text = "Raise Event";
            this.btnRaiseEvent.UseVisualStyleBackColor = true;
            this.btnRaiseEvent.Click += new System.EventHandler(this.btnRaiseEvent_Click);
            // 
            // txtEventMessage
            // 
            this.txtEventMessage.Location = new System.Drawing.Point(12, 12);
            this.txtEventMessage.Name = "txtEventMessage";
            this.txtEventMessage.Size = new System.Drawing.Size(155, 21);
            this.txtEventMessage.TabIndex = 5;
            this.txtEventMessage.Text = "Hello!";
            // 
            // btnEventWithNumber
            // 
            this.btnEventWithNumber.Location = new System.Drawing.Point(173, 41);
            this.btnEventWithNumber.Name = "btnEventWithNumber";
            this.btnEventWithNumber.Size = new System.Drawing.Size(91, 23);
            this.btnEventWithNumber.TabIndex = 6;
            this.btnEventWithNumber.Text = "Raise Event";
            this.btnEventWithNumber.UseVisualStyleBackColor = true;
            this.btnEventWithNumber.Click += new System.EventHandler(this.btnEventWithNumber_Click);
            // 
            // txtEventNumber
            // 
            this.txtEventNumber.Location = new System.Drawing.Point(106, 43);
            this.txtEventNumber.Name = "txtEventNumber";
            this.txtEventNumber.Size = new System.Drawing.Size(61, 21);
            this.txtEventNumber.TabIndex = 7;
            this.txtEventNumber.Text = "1";
            this.txtEventNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 73);
            this.Controls.Add(this.txtEventNumber);
            this.Controls.Add(this.btnEventWithNumber);
            this.Controls.Add(this.txtEventMessage);
            this.Controls.Add(this.btnRaiseEvent);
            this.Name = "FPublisher";
            this.Text = "Publisher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRaiseEvent;
        private System.Windows.Forms.TextBox txtEventMessage;
        private System.Windows.Forms.Button btnEventWithNumber;
        private System.Windows.Forms.TextBox txtEventNumber;
    }
}

