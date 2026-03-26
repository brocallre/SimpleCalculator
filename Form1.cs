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
        // 수식 표시줄에 누적되는 수식 문자열 (현재 괄호 레벨 내)
        private string expression = "";
        // 연산자가 이미 입력된 상태인지 (연속 연산 판별용)
        private bool hasOperator = false;
        // 괄호 처리를 위한 상태 저장 스택
        private Stack<double> parenNumStack = new Stack<double>();
        private Stack<string> parenOpStack = new Stack<string>();
        private Stack<bool> parenHasOpStack = new Stack<bool>();
        private Stack<string> parenExprStack = new Stack<string>();
        // 현재 열린 괄호 개수
        private int openParenCount = 0;
        // 닫는 괄호 직후인지 여부 (수식에 값이 이미 포함됨)
        private bool isParenResult = false;

        public Form1()
        {
            InitializeComponent();
            // 키보드 입력을 폼에서 직접 받도록 설정
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        // 스택에 저장된 상위 수식을 포함한 전체 수식 문자열 반환
        private string GetFullExpression()
        {
            string full = "";
            // 스택은 위에서 아래 순서이므로 뒤집어서 합침
            string[] exprs = parenExprStack.ToArray();
            for (int i = exprs.Length - 1; i >= 0; i--)
                full += exprs[i];
            full += expression;
            return full;
        }

        // 키보드 입력 이벤트 핸들러
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 여는 괄호 ( : Shift + 9 (숫자키보다 먼저 검사)
            if (e.Shift && e.KeyCode == Keys.D9)
            {
                BtnOpenParen_Click(sender, e);
                e.Handled = true;
                return;
            }
            // 닫는 괄호 ) : Shift + 0
            if (e.Shift && e.KeyCode == Keys.D0)
            {
                BtnCloseParen_Click(sender, e);
                e.Handled = true;
                return;
            }
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
            // 괄호 결과 직후 숫자 입력 시 곱하기 자동 삽입: (3)5 → (3) x 5
            if (isParenResult)
            {
                SetOperator("*");
            }

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
            txtExpression.Text = GetFullExpression() + txtDisplay.Text;
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
            // 괄호 결과 직후 소수점 입력 시 곱하기 자동 삽입
            if (isParenResult)
            {
                SetOperator("*");
            }

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
            txtExpression.Text = GetFullExpression() + txtDisplay.Text;
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
            // 연산자를 연속으로 누른 경우 마지막 연산자만 교체 (괄호 결과 직후가 아닐 때)
            if (hasOperator && isNewInput && !isParenResult)
            {
                currentOperator = op;
                // 수식 끝부분의 "연산자 " 를 새 연산자로 교체
                string trimmed = expression.TrimEnd();
                int lastSpace = trimmed.LastIndexOf(' ');
                if (lastSpace >= 0)
                    expression = trimmed.Substring(0, lastSpace) + " " + GetOperatorSymbol(op) + " ";
                txtExpression.Text = GetFullExpression();
                return;
            }

            // 괄호 결과 직후 연산자 입력 (수식에 값이 이미 포함되어 있음)
            if (isParenResult)
            {
                expression += " " + GetOperatorSymbol(op) + " ";
                currentOperator = op;
                hasOperator = true;
                isParenResult = false;
                isNewInput = true;
                isCalculated = false;
                txtExpression.Text = GetFullExpression();
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
                    ResetAll();
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
            isNewInput = true;

            txtExpression.Text = GetFullExpression();
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
            // 열린 괄호가 남아있으면 자동으로 닫기
            while (openParenCount > 0)
            {
                CloseParenInternal();
            }

            // 괄호 결과만 있고 연산자가 없는 경우 (예: (5+3)= )
            if (isParenResult && string.IsNullOrEmpty(currentOperator))
            {
                txtExpression.Text = GetFullExpression() + " = " + FormatNumber(num1);
                txtDisplay.Text = FormatNumber(num1);
                currentOperator = "";
                hasOperator = false;
                expression = "";
                isParenResult = false;
                isNewInput = true;
                isCalculated = true;
                return;
            }

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
                ResetAll();
                return;
            }

            // 수식 표시줄에 전체 수식과 결과 표시
            txtExpression.Text = GetFullExpression() + FormatNumber(num2) + " = " + FormatNumber(result);
            // 결과값 표시
            txtDisplay.Text = FormatNumber(result);

            // 상태 초기화 (연속 계산을 위해 결과를 num1에 저장)
            num1 = result;
            currentOperator = "";
            hasOperator = false;
            expression = "";
            isParenResult = false;
            isNewInput = true;
            isCalculated = true;
        }

        // 여는 괄호 버튼 클릭 이벤트 핸들러
        private void BtnOpenParen_Click(object sender, EventArgs e)
        {
            // 계산 완료 후 괄호를 누르면 새로 시작
            if (isCalculated)
            {
                expression = "";
                isCalculated = false;
                num1 = 0;
                currentOperator = "";
                hasOperator = false;
                isParenResult = false;
            }

            // 숫자 입력 직후 또는 괄호 닫은 직후면 곱하기 자동 삽입: 5( → 5 x (, (3)(2) → (3) x (2)
            if (!isNewInput || isParenResult)
            {
                SetOperator("*");
            }

            // 현재 상태를 스택에 저장
            parenNumStack.Push(num1);
            parenOpStack.Push(currentOperator);
            parenHasOpStack.Push(hasOperator);
            parenExprStack.Push(expression);

            // 괄호 내부를 위한 상태 초기화
            num1 = 0;
            currentOperator = "";
            hasOperator = false;
            isParenResult = false;
            openParenCount++;

            // 새 괄호 내부의 수식은 "("로 시작
            expression = "(";
            txtExpression.Text = GetFullExpression();
            txtDisplay.Text = "0";
            isNewInput = true;
        }

        // 닫는 괄호 버튼 클릭 이벤트 핸들러
        private void BtnCloseParen_Click(object sender, EventArgs e)
        {
            CloseParenInternal();
        }

        // 괄호 닫기 내부 처리 (= 버튼에서도 호출)
        private void CloseParenInternal()
        {
            // 열린 괄호가 없으면 무시
            if (openParenCount <= 0)
                return;

            // 괄호 안의 최종 결과 계산
            double parenResult = 0;

            if (hasOperator)
            {
                // 괄호 안에 미완성 연산이 있으면 계산 수행
                double num2 = 0;
                double.TryParse(txtDisplay.Text, out num2);
                parenResult = Calculate(num1, num2, currentOperator);

                if (double.IsInfinity(parenResult) || double.IsNaN(parenResult))
                {
                    txtDisplay.Text = "0으로 나눌 수 없습니다";
                    txtExpression.Text = "";
                    ResetAll();
                    return;
                }

                // 수식에 마지막 피연산자 추가 (괄호 결과가 아닌 경우만)
                if (!isParenResult)
                    expression += FormatNumber(num2);
            }
            else
            {
                // 연산자 없이 괄호만 닫는 경우 현재 값을 결과로 사용
                double.TryParse(txtDisplay.Text, out parenResult);
                // 수식에 값 추가 (괄호 결과가 아닌 경우만)
                if (!isParenResult)
                    expression += FormatNumber(parenResult);
            }

            // 닫는 괄호 추가
            expression += ")";
            openParenCount--;

            // 스택에서 이전 상태 복원
            double prevNum = parenNumStack.Pop();
            string prevOp = parenOpStack.Pop();
            bool prevHasOp = parenHasOpStack.Pop();
            string prevExpr = parenExprStack.Pop();

            // 이전에 연산자가 있었으면 이전 값과 괄호 결과를 계산
            if (prevHasOp && !string.IsNullOrEmpty(prevOp))
            {
                num1 = Calculate(prevNum, parenResult, prevOp);

                if (double.IsInfinity(num1) || double.IsNaN(num1))
                {
                    txtDisplay.Text = "0으로 나눌 수 없습니다";
                    txtExpression.Text = "";
                    ResetAll();
                    return;
                }
            }
            else
            {
                num1 = parenResult;
            }

            // 수식 표시줄 갱신 (상위 수식 + 현재 괄호 수식)
            expression = prevExpr + expression;
            txtExpression.Text = GetFullExpression();
            txtDisplay.Text = FormatNumber(num1);

            // 괄호 결과 이후 상태 설정
            currentOperator = "";
            hasOperator = false;
            isParenResult = true;
            isNewInput = true;
        }

        // 전체 상태 초기화 메서드
        private void ResetAll()
        {
            num1 = 0;
            currentOperator = "";
            isNewInput = true;
            isCalculated = false;
            hasOperator = false;
            isParenResult = false;
            expression = "";
            openParenCount = 0;
            parenNumStack.Clear();
            parenOpStack.Clear();
            parenHasOpStack.Clear();
            parenExprStack.Clear();
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
                txtExpression.Text = GetFullExpression() + txtDisplay.Text;
            }
        }

        // C 버튼 클릭 - 모든 내용 삭제하고 초기 상태로 되돌림
        private void BtnC_Click(object sender, EventArgs e)
        {
            ResetAll();
            txtDisplay.Text = "0";
            txtExpression.Text = "";
        }

        // CE 버튼 클릭 - 마지막 입력한 피연산자 값을 통째로 삭제
        private void BtnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            isNewInput = true;
            // 수식 표시줄에서 현재 입력 중인 숫자 부분 제거
            txtExpression.Text = GetFullExpression();
        }

        // Del 버튼 클릭 - 마지막 입력된 숫자 한 글자를 삭제
        private void BtnDel_Click(object sender, EventArgs e)
        {
            // 계산 완료 후 또는 괄호 결과 직후에는 Del이 동작하지 않음
            if (isCalculated || isParenResult)
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
            txtExpression.Text = GetFullExpression() + txtDisplay.Text;
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
