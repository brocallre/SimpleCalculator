namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle - 타이틀 라벨
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Simple Calculator";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txtExpression - 수식 표시 텍스트박스
            //
            this.txtExpression.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtExpression.Location = new System.Drawing.Point(12, 60);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.ReadOnly = true;
            this.txtExpression.Size = new System.Drawing.Size(360, 29);
            this.txtExpression.TabIndex = 1;
            //
            // txtDisplay - 현재 입력값/결과 표시 텍스트박스
            //
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtDisplay.Location = new System.Drawing.Point(12, 95);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(360, 32);
            this.txtDisplay.TabIndex = 2;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // btnCE
            //
            this.btnCE.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCE.Location = new System.Drawing.Point(12, 140);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(85, 45);
            this.btnCE.TabIndex = 3;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = true;
            //
            // btnC
            //
            this.btnC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnC.Location = new System.Drawing.Point(103, 140);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(85, 45);
            this.btnC.TabIndex = 4;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            //
            // btnDel
            //
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDel.Location = new System.Drawing.Point(194, 140);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(85, 45);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "del";
            this.btnDel.UseVisualStyleBackColor = true;
            //
            // btnDivide - 나누기 버튼
            //
            this.btnDivide.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnDivide.ForeColor = System.Drawing.Color.Red;
            this.btnDivide.Location = new System.Drawing.Point(285, 140);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(87, 45);
            this.btnDivide.TabIndex = 6;
            this.btnDivide.Text = "\u00f7";
            this.btnDivide.UseVisualStyleBackColor = true;
            //
            // btn7
            //
            this.btn7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn7.Location = new System.Drawing.Point(12, 191);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(85, 45);
            this.btn7.TabIndex = 7;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btn8
            //
            this.btn8.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn8.Location = new System.Drawing.Point(103, 191);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(85, 45);
            this.btn8.TabIndex = 8;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btn9
            //
            this.btn9.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn9.Location = new System.Drawing.Point(194, 191);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(85, 45);
            this.btn9.TabIndex = 9;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btnMultiply - 곱하기 버튼
            //
            this.btnMultiply.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnMultiply.ForeColor = System.Drawing.Color.Red;
            this.btnMultiply.Location = new System.Drawing.Point(285, 191);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(87, 45);
            this.btnMultiply.TabIndex = 10;
            this.btnMultiply.Text = "x";
            this.btnMultiply.UseVisualStyleBackColor = true;
            //
            // btn4
            //
            this.btn4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn4.Location = new System.Drawing.Point(12, 242);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(85, 45);
            this.btn4.TabIndex = 11;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btn5
            //
            this.btn5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn5.Location = new System.Drawing.Point(103, 242);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(85, 45);
            this.btn5.TabIndex = 12;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btn6
            //
            this.btn6.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn6.Location = new System.Drawing.Point(194, 242);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(85, 45);
            this.btn6.TabIndex = 13;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btnSubtract - 빼기 버튼
            //
            this.btnSubtract.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnSubtract.ForeColor = System.Drawing.Color.Red;
            this.btnSubtract.Location = new System.Drawing.Point(285, 242);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(87, 45);
            this.btnSubtract.TabIndex = 14;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            //
            // btn1
            //
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn1.Location = new System.Drawing.Point(12, 293);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(85, 45);
            this.btn1.TabIndex = 15;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btn2
            //
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn2.Location = new System.Drawing.Point(103, 293);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(85, 45);
            this.btn2.TabIndex = 16;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btn3
            //
            this.btn3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn3.Location = new System.Drawing.Point(194, 293);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(85, 45);
            this.btn3.TabIndex = 17;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btnAdd - 더하기 버튼
            //
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnAdd.ForeColor = System.Drawing.Color.Red;
            this.btnAdd.Location = new System.Drawing.Point(285, 293);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 45);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            //
            // btnSign - 부호 전환 버튼
            //
            this.btnSign.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnSign.Location = new System.Drawing.Point(12, 344);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(85, 45);
            this.btnSign.TabIndex = 19;
            this.btnSign.Text = "+/-";
            this.btnSign.UseVisualStyleBackColor = true;
            //
            // btn0
            //
            this.btn0.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn0.Location = new System.Drawing.Point(103, 344);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(85, 45);
            this.btn0.TabIndex = 20;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.BtnNumber_Click);
            //
            // btnDot - 소수점 버튼
            //
            this.btnDot.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnDot.Location = new System.Drawing.Point(194, 344);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(85, 45);
            this.btnDot.TabIndex = 21;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = true;
            //
            // btnEquals - 결과 버튼
            //
            this.btnEquals.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnEquals.Location = new System.Drawing.Point(285, 344);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(87, 45);
            this.btnEquals.TabIndex = 22;
            this.btnEquals.Text = "=";
            this.btnEquals.UseVisualStyleBackColor = true;
            this.btnEquals.Click += new System.EventHandler(this.BtnEquals_Click);
            //
            // Form1 - 메인 폼
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 401);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btnEquals);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnEquals;
    }
}
