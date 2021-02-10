namespace LINQ
{
    partial class FlightsApp
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
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblAirline = new System.Windows.Forms.Label();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.cmbAirline = new System.Windows.Forms.ComboBox();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.lbFlights = new System.Windows.Forms.ListBox();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.btnPass = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(33, 42);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(93, 13);
            this.lblCondition.TabIndex = 0;
            this.lblCondition.Text = "Select a Condition";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(443, 90);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(102, 13);
            this.lblDestination.TabIndex = 1;
            this.lblDestination.Text = "Select a Destination";
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Location = new System.Drawing.Point(33, 90);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(83, 13);
            this.lblAirline.TabIndex = 2;
            this.lblAirline.Text = "Select an Airline";
            // 
            // cmbCondition
            // 
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Items.AddRange(new object[] {
            "Flights to Cape Town , ordered in alphabetical order of airlines",
            "Flight departing from Gate A11, ordered by departure time",
            "Flights to Johannesburg which cost less than R600 , ordered by price (ascending)",
            "Choose own airline and destination"});
            this.cmbCondition.Location = new System.Drawing.Point(145, 34);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(545, 21);
            this.cmbCondition.TabIndex = 3;
            this.cmbCondition.SelectedIndexChanged += new System.EventHandler(this.cmbCondition_SelectedIndexChanged);
            // 
            // cmbAirline
            // 
            this.cmbAirline.FormattingEnabled = true;
            this.cmbAirline.Location = new System.Drawing.Point(145, 82);
            this.cmbAirline.Name = "cmbAirline";
            this.cmbAirline.Size = new System.Drawing.Size(121, 21);
            this.cmbAirline.TabIndex = 4;
            // 
            // cmbDestination
            // 
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(569, 82);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(121, 21);
            this.cmbDestination.TabIndex = 5;
            // 
            // lbFlights
            // 
            this.lbFlights.FormattingEnabled = true;
            this.lbFlights.Location = new System.Drawing.Point(36, 136);
            this.lbFlights.Name = "lbFlights";
            this.lbFlights.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbFlights.Size = new System.Drawing.Size(333, 420);
            this.lbFlights.TabIndex = 6;
            // 
            // lbResults
            // 
            this.lbResults.FormattingEnabled = true;
            this.lbResults.Location = new System.Drawing.Point(456, 136);
            this.lbResults.Name = "lbResults";
            this.lbResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbResults.Size = new System.Drawing.Size(324, 420);
            this.lbResults.TabIndex = 7;
            
            // 
            // btnPass
            // 
            this.btnPass.Location = new System.Drawing.Point(375, 219);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(75, 23);
            this.btnPass.TabIndex = 8;
            this.btnPass.Text = ">>";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(375, 248);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FlightsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 582);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.lbFlights);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.cmbAirline);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.lblAirline);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblCondition);
            this.Name = "FlightsApp";
            this.Text = "Flights App";
            this.Load += new System.EventHandler(this.FlightsApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblAirline;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.ComboBox cmbAirline;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.ListBox lbFlights;
        private System.Windows.Forms.ListBox lbResults;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnReset;
    }
}

