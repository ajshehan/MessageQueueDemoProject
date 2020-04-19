namespace MessageQueueClient
{
    partial class MessageQueueClient
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
            this.lbl_message_to_send = new System.Windows.Forms.Label();
            this.btn_send_message = new System.Windows.Forms.Button();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.Lbl_received_messages = new System.Windows.Forms.Label();
            this.tb_received_messages = new System.Windows.Forms.TextBox();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_message_to_send
            // 
            this.lbl_message_to_send.AutoSize = true;
            this.lbl_message_to_send.Location = new System.Drawing.Point(12, 9);
            this.lbl_message_to_send.Name = "lbl_message_to_send";
            this.lbl_message_to_send.Size = new System.Drawing.Size(50, 13);
            this.lbl_message_to_send.TabIndex = 0;
            this.lbl_message_to_send.Text = "Message";
            // 
            // btn_send_message
            // 
            this.btn_send_message.Location = new System.Drawing.Point(546, 9);
            this.btn_send_message.Name = "btn_send_message";
            this.btn_send_message.Size = new System.Drawing.Size(84, 23);
            this.btn_send_message.TabIndex = 1;
            this.btn_send_message.Text = "Send";
            this.btn_send_message.UseVisualStyleBackColor = true;
            this.btn_send_message.Click += new System.EventHandler(this.btn_send_message_Click);
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(82, 9);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(452, 69);
            this.tb_message.TabIndex = 2;
            // 
            // Lbl_received_messages
            // 
            this.Lbl_received_messages.AutoSize = true;
            this.Lbl_received_messages.Location = new System.Drawing.Point(12, 100);
            this.Lbl_received_messages.Name = "Lbl_received_messages";
            this.Lbl_received_messages.Size = new System.Drawing.Size(53, 13);
            this.Lbl_received_messages.TabIndex = 6;
            this.Lbl_received_messages.Text = "Received";
            // 
            // tb_received_messages
            // 
            this.tb_received_messages.Location = new System.Drawing.Point(82, 100);
            this.tb_received_messages.Multiline = true;
            this.tb_received_messages.Name = "tb_received_messages";
            this.tb_received_messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_received_messages.Size = new System.Drawing.Size(452, 142);
            this.tb_received_messages.TabIndex = 7;
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(546, 38);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(84, 23);
            this.btn_read.TabIndex = 8;
            this.btn_read.Text = "Read Queue";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(546, 219);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(84, 23);
            this.btn_Clear.TabIndex = 9;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // MessageQueueClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 257);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.tb_received_messages);
            this.Controls.Add(this.Lbl_received_messages);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.btn_send_message);
            this.Controls.Add(this.lbl_message_to_send);
            this.Name = "MessageQueueClient";
            this.Text = "Message Queue Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_message_to_send;
        private System.Windows.Forms.Button btn_send_message;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.Label Lbl_received_messages;
        private System.Windows.Forms.TextBox tb_received_messages;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_Clear;
    }
}

