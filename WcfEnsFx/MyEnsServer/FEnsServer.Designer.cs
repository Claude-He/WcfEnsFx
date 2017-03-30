namespace MyEnsServer
{
    partial class FEnsServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClosePublisherService = new System.Windows.Forms.Button();
            this.btnOpenPublisherService = new System.Windows.Forms.Button();
            this.btnCloseSubscriberService = new System.Windows.Forms.Button();
            this.btnOpenSubscriberService = new System.Windows.Forms.Button();
            this.lbl_pubState = new System.Windows.Forms.Label();
            this.lbl_subState = new System.Windows.Forms.Label();
            this.txt_subscribers = new System.Windows.Forms.TextBox();
            this.btnRaiseEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "Subscriber List:";
            // 
            // btnClosePublisherService
            // 
            this.btnClosePublisherService.Enabled = false;
            this.btnClosePublisherService.Location = new System.Drawing.Point(191, 222);
            this.btnClosePublisherService.Name = "btnClosePublisherService";
            this.btnClosePublisherService.Size = new System.Drawing.Size(155, 23);
            this.btnClosePublisherService.TabIndex = 19;
            this.btnClosePublisherService.Text = "ClosePublisherService";
            this.btnClosePublisherService.UseVisualStyleBackColor = true;
            this.btnClosePublisherService.Click += new System.EventHandler(this.BtnClicked);
            // 
            // btnOpenPublisherService
            // 
            this.btnOpenPublisherService.Location = new System.Drawing.Point(4, 222);
            this.btnOpenPublisherService.Name = "btnOpenPublisherService";
            this.btnOpenPublisherService.Size = new System.Drawing.Size(155, 23);
            this.btnOpenPublisherService.TabIndex = 18;
            this.btnOpenPublisherService.Text = "OpenPublisherService";
            this.btnOpenPublisherService.UseVisualStyleBackColor = true;
            this.btnOpenPublisherService.Click += new System.EventHandler(this.BtnClicked);
            // 
            // btnCloseSubscriberService
            // 
            this.btnCloseSubscriberService.Enabled = false;
            this.btnCloseSubscriberService.Location = new System.Drawing.Point(191, 177);
            this.btnCloseSubscriberService.Name = "btnCloseSubscriberService";
            this.btnCloseSubscriberService.Size = new System.Drawing.Size(155, 23);
            this.btnCloseSubscriberService.TabIndex = 17;
            this.btnCloseSubscriberService.Text = "CloseSubscriberService";
            this.btnCloseSubscriberService.UseVisualStyleBackColor = true;
            this.btnCloseSubscriberService.Click += new System.EventHandler(this.BtnClicked);
            // 
            // btnOpenSubscriberService
            // 
            this.btnOpenSubscriberService.Location = new System.Drawing.Point(4, 177);
            this.btnOpenSubscriberService.Name = "btnOpenSubscriberService";
            this.btnOpenSubscriberService.Size = new System.Drawing.Size(155, 23);
            this.btnOpenSubscriberService.TabIndex = 16;
            this.btnOpenSubscriberService.Text = "OpenSubscriberService";
            this.btnOpenSubscriberService.UseVisualStyleBackColor = true;
            this.btnOpenSubscriberService.Click += new System.EventHandler(this.BtnClicked);
            // 
            // lbl_pubState
            // 
            this.lbl_pubState.AutoSize = true;
            this.lbl_pubState.Location = new System.Drawing.Point(11, 248);
            this.lbl_pubState.Name = "lbl_pubState";
            this.lbl_pubState.Size = new System.Drawing.Size(131, 12);
            this.lbl_pubState.TabIndex = 15;
            this.lbl_pubState.Text = "PublisherServiceState";
            // 
            // lbl_subState
            // 
            this.lbl_subState.AutoSize = true;
            this.lbl_subState.Location = new System.Drawing.Point(11, 203);
            this.lbl_subState.Name = "lbl_subState";
            this.lbl_subState.Size = new System.Drawing.Size(137, 12);
            this.lbl_subState.TabIndex = 14;
            this.lbl_subState.Text = "SubscriberServiceState";
            // 
            // txt_subscribers
            // 
            this.txt_subscribers.BackColor = System.Drawing.Color.White;
            this.txt_subscribers.ForeColor = System.Drawing.Color.Black;
            this.txt_subscribers.Location = new System.Drawing.Point(4, 28);
            this.txt_subscribers.Multiline = true;
            this.txt_subscribers.Name = "txt_subscribers";
            this.txt_subscribers.ReadOnly = true;
            this.txt_subscribers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_subscribers.Size = new System.Drawing.Size(342, 143);
            this.txt_subscribers.TabIndex = 13;
            // 
            // btnRaiseEvent
            // 
            this.btnRaiseEvent.Location = new System.Drawing.Point(197, 4);
            this.btnRaiseEvent.Name = "btnRaiseEvent";
            this.btnRaiseEvent.Size = new System.Drawing.Size(149, 21);
            this.btnRaiseEvent.TabIndex = 12;
            this.btnRaiseEvent.Text = "Raise Local Event";
            this.btnRaiseEvent.UseVisualStyleBackColor = true;
            this.btnRaiseEvent.Click += new System.EventHandler(this.BtnClicked);
            // 
            // FEnsServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClosePublisherService);
            this.Controls.Add(this.btnOpenPublisherService);
            this.Controls.Add(this.btnCloseSubscriberService);
            this.Controls.Add(this.btnOpenSubscriberService);
            this.Controls.Add(this.lbl_pubState);
            this.Controls.Add(this.lbl_subState);
            this.Controls.Add(this.txt_subscribers);
            this.Controls.Add(this.btnRaiseEvent);
            this.Name = "FEnsServer";
            this.Text = "ENS Service Demo";
            this.Load += new System.EventHandler(this.FEnsServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClosePublisherService;
        private System.Windows.Forms.Button btnOpenPublisherService;
        private System.Windows.Forms.Button btnCloseSubscriberService;
        private System.Windows.Forms.Button btnOpenSubscriberService;
        private System.Windows.Forms.Label lbl_pubState;
        private System.Windows.Forms.Label lbl_subState;
        private System.Windows.Forms.TextBox txt_subscribers;
        private System.Windows.Forms.Button btnRaiseEvent;
    }
}

