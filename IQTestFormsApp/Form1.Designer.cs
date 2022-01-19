namespace IQTestFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NextButton = new System.Windows.Forms.Button();
            this.CountQuestionLabel = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.UserAnswerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(138, 175);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(545, 240);
            this.NextButton.TabIndex = 0;
            this.NextButton.Text = "далее";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // CountQuestionLabel
            // 
            this.CountQuestionLabel.AutoSize = true;
            this.CountQuestionLabel.Location = new System.Drawing.Point(138, 21);
            this.CountQuestionLabel.Name = "CountQuestionLabel";
            this.CountQuestionLabel.Size = new System.Drawing.Size(94, 20);
            this.CountQuestionLabel.TabIndex = 1;
            this.CountQuestionLabel.Text = "Вопрос № 1";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(138, 71);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(108, 20);
            this.QuestionLabel.TabIndex = 2;
            this.QuestionLabel.Text = "Текст вопроса";
            // 
            // UserAnswerTextBox
            // 
            this.UserAnswerTextBox.Location = new System.Drawing.Point(138, 120);
            this.UserAnswerTextBox.Name = "UserAnswerTextBox";
            this.UserAnswerTextBox.Size = new System.Drawing.Size(545, 27);
            this.UserAnswerTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UserAnswerTextBox);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.CountQuestionLabel);
            this.Controls.Add(this.NextButton);
            this.Name = "MainForm";
            this.Text = "IQ Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button NextButton;
        private Label CountQuestionLabel;
        private Label QuestionLabel;
        private TextBox UserAnswerTextBox;
    }
}