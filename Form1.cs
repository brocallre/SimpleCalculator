using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 첫 번째 피연산자 저장 변수
        private int num1 = 0;
        // 현재 선택된 연산자 저장 변수
        private string currentOperator = "";
        // 새로운 숫자 입력 시작 여부
        private bool isNewInput = true;

        public Form1()
        {
            InitializeComponent();
        }

        // 숫자 버튼 클릭 이벤트 핸들러
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string number = btn.Text;

            // 새 입력이면 기존 값을 지우고 시작
            if (isNewInput)
            {
                txtDisplay.Text = number;
                isNewInput = false;
            }
            else
            {
                // 기존 값이 0이면 새 숫자로 대체
                if (txtDisplay.Text == "0")
                    txtDisplay.Text = number;
                else
                    txtDisplay.Text += number;
            }
        }

        // 더하기 버튼 클릭 이벤트 핸들러
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // 현재 표시된 값을 첫 번째 피연산자로 저장
            num1 = int.Parse(txtDisplay.Text);
            currentOperator = "+";
            // 수식 표시줄에 입력 내용 표시
            txtExpression.Text = num1.ToString() + " + ";
            isNewInput = true;
        }

        // 등호 버튼 클릭 이벤트 핸들러
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            // 연산자가 선택되지 않았으면 아무것도 하지 않음
            if (string.IsNullOrEmpty(currentOperator))
                return;

            // 두 번째 피연산자 가져오기
            int num2 = int.Parse(txtDisplay.Text);
            int result = 0;

            // 더하기 연산 수행
            if (currentOperator == "+")
            {
                result = num1 + num2;
            }

            // 수식 표시줄에 전체 수식과 결과 표시
            txtExpression.Text = num1 + " + " + num2 + " = " + result;
            // 결과값 표시
            txtDisplay.Text = result.ToString();

            // 상태 초기화
            currentOperator = "";
            isNewInput = true;
        }
    }
}
