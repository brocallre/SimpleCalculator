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
        // 첫 번째 피연산자 저장 변수 (소수점 연산을 위해 double 사용)
        private double num1 = 0;
        // 현재 선택된 연산자 저장 변수
        private string currentOperator = "";
        // 새로운 숫자 입력 시작 여부
        private bool isNewInput = true;
        // 계산이 완료된 직후인지 여부
        private bool isCalculated = false;
        // 수식 표시줄에 누적되는 수식 문자열
        private string expression = "";
        // 연산자가 이미 입력된 상태인지 (연속 연산 판별용)
        private bool hasOperator = false;

        public Form1()
        {
            InitializeComponent();
            // 키보드 입력을 폼에서 직접 받도록 설정
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        // 키보드 입력 이벤트 핸들러
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 숫자키 0~9 (메인 키보드)
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift)
            {
                string num = ((int)(e.KeyCode - Keys.D0)).ToString();
                InputNumber(num);
                e.Handled = true;
            }
            // 숫자키 0~9 (넘패드)
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                string num = ((int)(e.KeyCode - Keys.NumPad0)).ToString();
                InputNumber(num);
                e.Handled = true;
            }
            // 연산자 키
            else if (e.KeyCode == Keys.Add || (e.Shift && e.KeyCode == Keys.Oemplus))
            {
                SetOperator("+");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                SetOperator("-");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Multiply || (e.Shift && e.KeyCode == Keys.D8))
            {
                SetOperator("*");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.Oem2)
            {
                SetOperator("/");
                e.Handled = true;
            }
            // Enter 또는 = 키로 계산 실행
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus)
            {
                BtnEquals_Click(sender, e);
                e.Handled = true;
            }
            // Backspace로 Del 기능 수행
            else if (e.KeyCode == Keys.Back)
            {
                BtnDel_Click(sender, e);
                e.Handled = true;
            }
            // Escape로 C(전체 초기화) 기능 수행
            else if (e.KeyCode == Keys.Escape)
            {
                BtnC_Click(sender, e);
                e.Handled = true;
            }
            // Delete로 CE 기능 수행
            else if (e.KeyCode == Keys.Delete)
            {
                BtnCE_Click(sender, e);
                e.Handled = true;
            }
            // 소수점 입력
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                InputDot();
                e.Handled = true;
            }
        }

        // 숫자 입력 처리 공통 메서드
        private void InputNumber(string number)
        {
            // 계산 완료 후 새 숫자를 누르면 전체 초기화
            if (isCalculated)
            {
                expression = "";
                isCalculated = false;
            }

            // 새 입력이면 기존 값을 지우고 시작
            if (isNewInput)
            {
                txtDisplay.Text = number;
                isNewInput = false;
            }
            else
            {
                // 기존 값이 0이면 새 숫자로 대체 (소수점 입력 중이면 유지)
                if (txtDisplay.Text == "0")
                    txtDisplay.Text = number;
                else
                    txtDisplay.Text += number;
            }

            // 수식 표시줄에 현재까지의 수식 + 입력 중인 숫자 실시간 반영
            txtExpression.Text = expression + txtDisplay.Text;
        }

        // 숫자 버튼 클릭 이벤트 핸들러
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputNumber(btn.Text);
        }

        // 소수점 입력 처리 메서드
        private void InputDot()
        {
            // 계산 완료 후 소수점을 누르면 새로 시작
            if (isCalculated)
            {
                expression = "";
                isCalculated = false;
            }

            // 새 입력 시작이면 "0."으로 표시
            if (isNewInput)
            {
                txtDisplay.Text = "0.";
                isNewInput = false;
            }
            else
            {
                // 이미 소수점이 있으면 추가하지 않음
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text += ".";
                }
            }

            // 수식 표시줄 실시간 반영
            txtExpression.Text = expression + txtDisplay.Text;
        }

        // 소수점 버튼 클릭 이벤트 핸들러
        private void BtnDot_Click(object sender, EventArgs e)
        {
            InputDot();
        }

        // 연산자 기호를 표시용 문자로 변환하는 메서드
        private string GetOperatorSymbol(string op)
        {
            switch (op)
            {
                case "+": return "+";
                case "-": return "-";
                case "*": return "x";
                case "/": return "\u00f7";
                default: return op;
            }
        }

        // 연산자 설정 공통 메서드
        private void SetOperator(string op)
        {
            // 연산자를 연속으로 누른 경우 (예: + 누른 후 - 로 변경)
            if (hasOperator && isNewInput)
            {
                // 마지막 연산자만 교체 (수식에서 이전 연산자 기호를 새 기호로 변경)
                currentOperator = op;
                // 수식 끝부분의 "연산자 " 를 새 연산자로 교체
                string trimmed = expression.TrimEnd();
                // 마지막 연산자 기호 제거 후 새 기호 추가
                int lastSpace = trimmed.LastIndexOf(' ');
                if (lastSpace >= 0)
                    expression = trimmed.Substring(0, lastSpace) + " " + GetOperatorSymbol(op) + " ";
                txtExpression.Text = expression;
                return;
            }

            // 이전 연산자가 있으면 중간 계산 수행 (연속 연산: 8x8x8 등)
            if (hasOperator && !isNewInput)
            {
                double num2 = 0;
                double.TryParse(txtDisplay.Text, out num2);

                // 수식에 현재 입력된 숫자와 새 연산자를 누적
                expression += FormatNumber(num2) + " " + GetOperatorSymbol(op) + " ";

                double intermediate = Calculate(num1, num2, currentOperator);

                // 0으로 나누기 오류 처리
                if (double.IsInfinity(intermediate) || double.IsNaN(intermediate))
                {
                    txtDisplay.Text = "0으로 나눌 수 없습니다";
                    txtExpression.Text = "";
                    expression = "";
                    currentOperator = "";
                    hasOperator = false;
                    isNewInput = true;
                    return;
                }

                num1 = intermediate;
                // 중간 계산 결과를 하단에 표시
                txtDisplay.Text = FormatNumber(num1);
            }
            else
            {
                // 첫 번째 연산자를 누를 때 현재 값을 저장
                double.TryParse(txtDisplay.Text, out num1);
                // 수식에 첫 번째 숫자와 연산자 추가
                expression += FormatNumber(num1) + " " + GetOperatorSymbol(op) + " ";
            }

            currentOperator = op;
            isCalculated = false;
            hasOperator = true;

            txtExpression.Text = expression;
            isNewInput = true;
        }

        // 두 숫자와 연산자로 계산을 수행하는 메서드
        private double Calculate(double a, double b, string op)
        {
            switch (op)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) return double.PositiveInfinity;
                    return a / b;
                default: return b;
            }
        }

        // 연산자 버튼 클릭 이벤트 핸들러 (사칙연산 공통)
        private void BtnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // 버튼에 따라 연산자 결정
            if (btn == btnAdd)
                SetOperator("+");
            else if (btn == btnSubtract)
                SetOperator("-");
            else if (btn == btnMultiply)
                SetOperator("*");
            else if (btn == btnDivide)
                SetOperator("/");
        }

        // 숫자를 보기 좋게 포맷하는 메서드
        private string FormatNumber(double value)
        {
            // 정수인 경우 소수점 없이 표시
            if (value == Math.Floor(value) && !double.IsInfinity(value))
                return ((long)value).ToString();
            else
                return value.ToString();
        }

        // 등호 버튼 클릭 이벤트 핸들러
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            // 연산자가 선택되지 않았으면 아무것도 하지 않음
            if (string.IsNullOrEmpty(currentOperator))
                return;

            // 두 번째 피연산자 가져오기
            double num2 = 0;
            double.TryParse(txtDisplay.Text, out num2);

            double result = Calculate(num1, num2, currentOperator);

            // 0으로 나누기 오류 처리
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                txtDisplay.Text = "0으로 나눌 수 없습니다";
                txtExpression.Text = "";
                expression = "";
                currentOperator = "";
                hasOperator = false;
                isNewInput = true;
                return;
            }

            // 수식 표시줄에 전체 수식과 결과 표시
            txtExpression.Text = expression + FormatNumber(num2) + " = " + FormatNumber(result);
            // 결과값 표시
            txtDisplay.Text = FormatNumber(result);

            // 상태 초기화 (연속 계산을 위해 결과를 num1에 저장)
            num1 = result;
            currentOperator = "";
            hasOperator = false;
            expression = "";
            isNewInput = true;
            isCalculated = true;
        }

        // +/- 부호 전환 버튼 클릭 이벤트 핸들러
        private void BtnSign_Click(object sender, EventArgs e)
        {
            // 현재 값이 0이면 부호 전환하지 않음
            if (txtDisplay.Text == "0" || txtDisplay.Text == "")
                return;

            double value = 0;
            if (double.TryParse(txtDisplay.Text, out value))
            {
                // 부호를 반대로 전환
                value = -value;
                txtDisplay.Text = FormatNumber(value);
                // 수식 표시줄에 부호 전환 반영
                txtExpression.Text = expression + txtDisplay.Text;
            }
        }

        // C 버튼 클릭 - 모든 내용 삭제하고 초기 상태로 되돌림
        private void BtnC_Click(object sender, EventArgs e)
        {
            num1 = 0;
            currentOperator = "";
            isNewInput = true;
            isCalculated = false;
            hasOperator = false;
            expression = "";
            txtDisplay.Text = "0";
            txtExpression.Text = "";
        }

        // CE 버튼 클릭 - 마지막 입력한 피연산자 값을 통째로 삭제
        private void BtnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            isNewInput = true;
            // 수식 표시줄에서 현재 입력 중인 숫자 부분 제거
            txtExpression.Text = expression;
        }

        // Del 버튼 클릭 - 마지막 입력된 숫자 한 글자를 삭제
        private void BtnDel_Click(object sender, EventArgs e)
        {
            // 계산 완료 후에는 Del이 동작하지 않도록 방지
            if (isCalculated)
                return;

            // 현재 표시된 텍스트가 한 글자이거나 비어있으면 0으로 설정
            if (txtDisplay.Text.Length <= 1)
            {
                txtDisplay.Text = "0";
                isNewInput = true;
            }
            else
            {
                // 음수에서 마지막 숫자를 지워서 "-"만 남는 경우 처리
                string newText = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                if (newText == "-" || newText == "")
                {
                    txtDisplay.Text = "0";
                    isNewInput = true;
                }
                else
                {
                    txtDisplay.Text = newText;
                }
            }

            // 수식 표시줄에 삭제 후 상태 반영
            txtExpression.Text = expression + txtDisplay.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtExpression_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
