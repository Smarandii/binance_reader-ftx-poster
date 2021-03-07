
namespace binance_reader_ftx_poster
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
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.binance_label = new System.Windows.Forms.Label();
            this.ftx_label = new System.Windows.Forms.Label();
            this.api_s_label = new System.Windows.Forms.Label();
            this.api_k_label = new System.Windows.Forms.Label();
            this.binance_bid_label = new System.Windows.Forms.Label();
            this.coeff = new System.Windows.Forms.Label();
            this.status_label = new System.Windows.Forms.Label();
            this.apiKeyBinance = new System.Windows.Forms.TextBox();
            this.apiKeyFTX = new System.Windows.Forms.TextBox();
            this.apiSecretBinance = new System.Windows.Forms.TextBox();
            this.apiSecretFTX = new System.Windows.Forms.TextBox();
            this.binanceBID = new System.Windows.Forms.TextBox();
            this.coeff_form = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.start_button.ForeColor = System.Drawing.Color.Snow;
            this.start_button.Location = new System.Drawing.Point(15, 257);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(132, 77);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "START";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.stop_button.ForeColor = System.Drawing.Color.Snow;
            this.stop_button.Location = new System.Drawing.Point(166, 257);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(123, 77);
            this.stop_button.TabIndex = 1;
            this.stop_button.Text = "STOP";
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // binance_label
            // 
            this.binance_label.AutoSize = true;
            this.binance_label.Location = new System.Drawing.Point(80, 9);
            this.binance_label.Name = "binance_label";
            this.binance_label.Size = new System.Drawing.Size(46, 13);
            this.binance_label.TabIndex = 2;
            this.binance_label.Text = "Binance";
            // 
            // ftx_label
            // 
            this.ftx_label.AutoSize = true;
            this.ftx_label.Location = new System.Drawing.Point(186, 9);
            this.ftx_label.Name = "ftx_label";
            this.ftx_label.Size = new System.Drawing.Size(27, 13);
            this.ftx_label.TabIndex = 3;
            this.ftx_label.Text = "FTX";
            // 
            // api_s_label
            // 
            this.api_s_label.AutoSize = true;
            this.api_s_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.api_s_label.Location = new System.Drawing.Point(12, 76);
            this.api_s_label.Name = "api_s_label";
            this.api_s_label.Size = new System.Drawing.Size(66, 13);
            this.api_s_label.TabIndex = 4;
            this.api_s_label.Text = "API-secret";
            // 
            // api_k_label
            // 
            this.api_k_label.AutoSize = true;
            this.api_k_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.api_k_label.Location = new System.Drawing.Point(12, 28);
            this.api_k_label.Name = "api_k_label";
            this.api_k_label.Size = new System.Drawing.Size(51, 13);
            this.api_k_label.TabIndex = 5;
            this.api_k_label.Text = "API-key";
            // 
            // binance_bid_label
            // 
            this.binance_bid_label.AutoSize = true;
            this.binance_bid_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.binance_bid_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.binance_bid_label.Location = new System.Drawing.Point(12, 113);
            this.binance_bid_label.Name = "binance_bid_label";
            this.binance_bid_label.Size = new System.Drawing.Size(78, 13);
            this.binance_bid_label.TabIndex = 6;
            this.binance_bid_label.Text = "Binance BID";
            // 
            // coeff
            // 
            this.coeff.AutoSize = true;
            this.coeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.coeff.Location = new System.Drawing.Point(273, 113);
            this.coeff.Name = "coeff";
            this.coeff.Size = new System.Drawing.Size(16, 13);
            this.coeff.TabIndex = 7;
            this.coeff.Text = "%";
            // 
            // status_label
            // 
            this.status_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F);
            this.status_label.ForeColor = System.Drawing.Color.White;
            this.status_label.Location = new System.Drawing.Point(14, 170);
            this.status_label.MaximumSize = new System.Drawing.Size(300, 300);
            this.status_label.MinimumSize = new System.Drawing.Size(275, 75);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(275, 75);
            this.status_label.TabIndex = 8;
            this.status_label.Text = "INACTIVE";
            this.status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apiKeyBinance
            // 
            this.apiKeyBinance.Location = new System.Drawing.Point(83, 25);
            this.apiKeyBinance.Name = "apiKeyBinance";
            this.apiKeyBinance.Size = new System.Drawing.Size(100, 20);
            this.apiKeyBinance.TabIndex = 9;
            this.apiKeyBinance.Text = "tkrmoDlyW2PjSWw4RpJzx9qoFokBiK85A7ywDRxffQcSBU4X9avo7kUvUpGLjhFN";
            this.apiKeyBinance.TextChanged += new System.EventHandler(this.apiKeyBinance_TextChanged);
            // 
            // apiKeyFTX
            // 
            this.apiKeyFTX.Location = new System.Drawing.Point(189, 25);
            this.apiKeyFTX.Name = "apiKeyFTX";
            this.apiKeyFTX.Size = new System.Drawing.Size(100, 20);
            this.apiKeyFTX.TabIndex = 10;
            this.apiKeyFTX.Text = "qHMz2mpybnSzz_-gz1cEccLmveswPlcLtFvudSMi";
            this.apiKeyFTX.TextChanged += new System.EventHandler(this.apiKeyFTX_TextChanged);
            // 
            // apiSecretBinance
            // 
            this.apiSecretBinance.Location = new System.Drawing.Point(83, 73);
            this.apiSecretBinance.Name = "apiSecretBinance";
            this.apiSecretBinance.Size = new System.Drawing.Size(100, 20);
            this.apiSecretBinance.TabIndex = 11;
            this.apiSecretBinance.Text = "1HqPNqeaAJJzydB4h9O0SmQgPUmjD3nvqIYSO1hYk1pNYavqwn1SWkiHTgSUjmu3";
            this.apiSecretBinance.TextChanged += new System.EventHandler(this.apiSecretBinance_TextChanged);
            // 
            // apiSecretFTX
            // 
            this.apiSecretFTX.Location = new System.Drawing.Point(189, 73);
            this.apiSecretFTX.Name = "apiSecretFTX";
            this.apiSecretFTX.Size = new System.Drawing.Size(100, 20);
            this.apiSecretFTX.TabIndex = 12;
            this.apiSecretFTX.Text = "gtptMKVI1N8DePgQ_MZNgk4egHyfz6VkO81Q-Pl4";
            this.apiSecretFTX.TextChanged += new System.EventHandler(this.apiSecretFTX_TextChanged);
            // 
            // binanceBID
            // 
            this.binanceBID.Location = new System.Drawing.Point(15, 136);
            this.binanceBID.Name = "binanceBID";
            this.binanceBID.ReadOnly = true;
            this.binanceBID.Size = new System.Drawing.Size(100, 20);
            this.binanceBID.TabIndex = 13;
            this.binanceBID.Text = "0";
            this.binanceBID.TextChanged += new System.EventHandler(this.binanceBID_TextChanged);
            // 
            // coeff_form
            // 
            this.coeff_form.Location = new System.Drawing.Point(189, 136);
            this.coeff_form.Name = "coeff_form";
            this.coeff_form.Size = new System.Drawing.Size(100, 20);
            this.coeff_form.TabIndex = 14;
            this.coeff_form.Text = "0.99";
            this.coeff_form.TextChanged += new System.EventHandler(this.coeff_form_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 353);
            this.Controls.Add(this.coeff_form);
            this.Controls.Add(this.binanceBID);
            this.Controls.Add(this.apiSecretFTX);
            this.Controls.Add(this.apiSecretBinance);
            this.Controls.Add(this.apiKeyFTX);
            this.Controls.Add(this.apiKeyBinance);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.coeff);
            this.Controls.Add(this.binance_bid_label);
            this.Controls.Add(this.api_k_label);
            this.Controls.Add(this.api_s_label);
            this.Controls.Add(this.ftx_label);
            this.Controls.Add(this.binance_label);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Name = "Form1";
            this.Text = "Binance-reader-ftx-poster";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Label binance_label;
        private System.Windows.Forms.Label ftx_label;
        private System.Windows.Forms.Label api_s_label;
        private System.Windows.Forms.Label api_k_label;
        private System.Windows.Forms.Label binance_bid_label;
        private System.Windows.Forms.Label coeff;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.TextBox apiKeyBinance;
        private System.Windows.Forms.TextBox apiKeyFTX;
        private System.Windows.Forms.TextBox apiSecretBinance;
        private System.Windows.Forms.TextBox apiSecretFTX;
        private System.Windows.Forms.TextBox binanceBID;
        private System.Windows.Forms.TextBox coeff_form;
    }
}

