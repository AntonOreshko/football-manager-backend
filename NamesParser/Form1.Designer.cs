namespace NamesParser
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
            this.LoadHtmlButton = new System.Windows.Forms.Button();
            this.url = new System.Windows.Forms.TextBox();
            this.FirstNameRadioButton = new System.Windows.Forms.RadioButton();
            this.LastNameRadioButton = new System.Windows.Forms.RadioButton();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.JoinFilesButton = new System.Windows.Forms.Button();
            this.JoinFilesAndClearNamesForSelectedCountryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadHtmlButton
            // 
            this.LoadHtmlButton.Location = new System.Drawing.Point(12, 84);
            this.LoadHtmlButton.Name = "LoadHtmlButton";
            this.LoadHtmlButton.Size = new System.Drawing.Size(258, 21);
            this.LoadHtmlButton.TabIndex = 0;
            this.LoadHtmlButton.Text = "Save Names";
            this.LoadHtmlButton.UseVisualStyleBackColor = true;
            this.LoadHtmlButton.Click += new System.EventHandler(this.LoadHtmlButton_Click);
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(12, 8);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(643, 20);
            this.url.TabIndex = 1;
            // 
            // FirstNameRadioButton
            // 
            this.FirstNameRadioButton.AutoSize = true;
            this.FirstNameRadioButton.Location = new System.Drawing.Point(12, 61);
            this.FirstNameRadioButton.Name = "FirstNameRadioButton";
            this.FirstNameRadioButton.Size = new System.Drawing.Size(75, 17);
            this.FirstNameRadioButton.TabIndex = 2;
            this.FirstNameRadioButton.TabStop = true;
            this.FirstNameRadioButton.Text = "First Name";
            this.FirstNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // LastNameRadioButton
            // 
            this.LastNameRadioButton.AutoSize = true;
            this.LastNameRadioButton.Location = new System.Drawing.Point(93, 61);
            this.LastNameRadioButton.Name = "LastNameRadioButton";
            this.LastNameRadioButton.Size = new System.Drawing.Size(76, 17);
            this.LastNameRadioButton.TabIndex = 3;
            this.LastNameRadioButton.TabStop = true;
            this.LastNameRadioButton.Text = "Last Name";
            this.LastNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(13, 34);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(257, 21);
            this.CountryComboBox.TabIndex = 4;
            // 
            // JoinFilesButton
            // 
            this.JoinFilesButton.Location = new System.Drawing.Point(13, 140);
            this.JoinFilesButton.Name = "JoinFilesButton";
            this.JoinFilesButton.Size = new System.Drawing.Size(257, 23);
            this.JoinFilesButton.TabIndex = 5;
            this.JoinFilesButton.Text = "Join files and clear names";
            this.JoinFilesButton.UseVisualStyleBackColor = true;
            this.JoinFilesButton.Click += new System.EventHandler(this.JoinFilesButton_Click);
            // 
            // JoinFilesAndClearNamesForSelectedCountryButton
            // 
            this.JoinFilesAndClearNamesForSelectedCountryButton.Location = new System.Drawing.Point(13, 111);
            this.JoinFilesAndClearNamesForSelectedCountryButton.Name = "JoinFilesAndClearNamesForSelectedCountryButton";
            this.JoinFilesAndClearNamesForSelectedCountryButton.Size = new System.Drawing.Size(257, 23);
            this.JoinFilesAndClearNamesForSelectedCountryButton.TabIndex = 6;
            this.JoinFilesAndClearNamesForSelectedCountryButton.Text = "Join files and clear names for selected country";
            this.JoinFilesAndClearNamesForSelectedCountryButton.UseVisualStyleBackColor = true;
            this.JoinFilesAndClearNamesForSelectedCountryButton.Click += new System.EventHandler(this.JoinFilesAndClearNamesForSelectedCountryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 184);
            this.Controls.Add(this.JoinFilesAndClearNamesForSelectedCountryButton);
            this.Controls.Add(this.JoinFilesButton);
            this.Controls.Add(this.CountryComboBox);
            this.Controls.Add(this.LastNameRadioButton);
            this.Controls.Add(this.FirstNameRadioButton);
            this.Controls.Add(this.url);
            this.Controls.Add(this.LoadHtmlButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadHtmlButton;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.RadioButton FirstNameRadioButton;
        private System.Windows.Forms.RadioButton LastNameRadioButton;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.Button JoinFilesButton;
        private System.Windows.Forms.Button JoinFilesAndClearNamesForSelectedCountryButton;
    }
}

