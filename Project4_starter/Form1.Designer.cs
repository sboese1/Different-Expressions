namespace Project4_starter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.initialExpressionText = new System.Windows.Forms.TextBox();
            this.initialType = new System.Windows.Forms.ComboBox();
            this.resultingType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resultingExpression = new System.Windows.Forms.TextBox();
            this.uxConvertExpression = new System.Windows.Forms.Button();
            this.uxBuildTree = new System.Windows.Forms.Button();
            this.uxEvaluate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial expression:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(71, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(34, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Resulting type:";
            // 
            // initialExpressionText
            // 
            this.initialExpressionText.Location = new System.Drawing.Point(187, 34);
            this.initialExpressionText.Name = "initialExpressionText";
            this.initialExpressionText.Size = new System.Drawing.Size(337, 20);
            this.initialExpressionText.TabIndex = 3;
            // 
            // initialType
            // 
            this.initialType.FormattingEnabled = true;
            this.initialType.Location = new System.Drawing.Point(187, 79);
            this.initialType.Name = "initialType";
            this.initialType.Size = new System.Drawing.Size(121, 21);
            this.initialType.TabIndex = 4;
            // 
            // resultingType
            // 
            this.resultingType.FormattingEnabled = true;
            this.resultingType.Location = new System.Drawing.Point(187, 123);
            this.resultingType.Name = "resultingType";
            this.resultingType.Size = new System.Drawing.Size(121, 21);
            this.resultingType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(13, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resulting expression:";
            // 
            // resultingExpression
            // 
            this.resultingExpression.Location = new System.Drawing.Point(224, 210);
            this.resultingExpression.Name = "resultingExpression";
            this.resultingExpression.Size = new System.Drawing.Size(286, 20);
            this.resultingExpression.TabIndex = 7;
            // 
            // uxConvertExpression
            // 
            this.uxConvertExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.uxConvertExpression.Location = new System.Drawing.Point(17, 294);
            this.uxConvertExpression.Name = "uxConvertExpression";
            this.uxConvertExpression.Size = new System.Drawing.Size(161, 36);
            this.uxConvertExpression.TabIndex = 8;
            this.uxConvertExpression.Text = "Convert Expression";
            this.uxConvertExpression.UseVisualStyleBackColor = true;
            this.uxConvertExpression.Click += new System.EventHandler(this.uxConvertExpression_Click);
            // 
            // uxBuildTree
            // 
            this.uxBuildTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.uxBuildTree.Location = new System.Drawing.Point(224, 294);
            this.uxBuildTree.Name = "uxBuildTree";
            this.uxBuildTree.Size = new System.Drawing.Size(145, 36);
            this.uxBuildTree.TabIndex = 9;
            this.uxBuildTree.Text = "Build Tree";
            this.uxBuildTree.UseVisualStyleBackColor = true;
            this.uxBuildTree.Click += new System.EventHandler(this.uxBuildTree_Click);
            // 
            // uxEvaluate
            // 
            this.uxEvaluate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.uxEvaluate.Location = new System.Drawing.Point(417, 294);
            this.uxEvaluate.Name = "uxEvaluate";
            this.uxEvaluate.Size = new System.Drawing.Size(141, 36);
            this.uxEvaluate.TabIndex = 10;
            this.uxEvaluate.Text = "Evaluate";
            this.uxEvaluate.UseVisualStyleBackColor = true;
            this.uxEvaluate.Click += new System.EventHandler(this.uxEvaluate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 339);
            this.Controls.Add(this.uxEvaluate);
            this.Controls.Add(this.uxBuildTree);
            this.Controls.Add(this.uxConvertExpression);
            this.Controls.Add(this.resultingExpression);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resultingType);
            this.Controls.Add(this.initialType);
            this.Controls.Add(this.initialExpressionText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Expression Tree Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox initialExpressionText;
        private System.Windows.Forms.ComboBox initialType;
        private System.Windows.Forms.ComboBox resultingType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resultingExpression;
        private System.Windows.Forms.Button uxConvertExpression;
        private System.Windows.Forms.Button uxBuildTree;
        private System.Windows.Forms.Button uxEvaluate;
    }
}

