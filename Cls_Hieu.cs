using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTinhBoTui
{
    class Cls_Hieu
    {
        // Thuật toán chuyển đổi biểu thức sang Balan ngược theo hậu tố 

        // tạo hàm ưu tiên 
        private int Priority(char c)
        {
            if (c == '+' || c == '-')
                return 1;
            if (c == '*' || c == '/')
                return 2;
            return 0;
        }


        // hàm chuyển biểu thức sang hậu tố 
        private string Convert(string exp)
        {
            string result = "";
            Stack<char> stk = new Stack<char>();

            // nếu  số đầu  âm thì lấy ra bỏ vào ngoặc -8  => (-8)
            if (exp[0] == '-')
            {
                int y = 1;
                while (IsNumber(exp[y]))
                {
                    y++;
                    if (y == exp.Length)
                        break;
                }
                result = result + "(" + exp.Substring(0, y) + ")";
                exp = exp.Substring(y);

            }
            // duyệt qua biểu thức exp 
            for (int i = 0; i < exp.Length; i++)
            {
                //Nếu là toán tử và phía sau là dấu trừ duyệt bỏ vào rs vd -8 => (-8)
                if ((exp[i] == '+' || exp[i] == '-' || exp[i] == '/' || exp[i] == '*') && exp[i + 1] == '-')
                {
                    // xét dấu phía trước với trong stack nếu stack >= thì lôi ra bỏ dấu nhỏ hơn vào stack
                    if (exp[i] == '+' || exp[i] == '-' || exp[i] == '/' || exp[i] == '*')
                    {
                        if (stk.Count > 0)
                        {
                            if (Priority(stk.Peek()) >= Priority(exp[i]))
                            {
                                result += stk.Pop();
                            }
                        }
                        stk.Push(exp[i]);
                    }
                    //tách số từ vị trí đang xét. Thêm dấu () để ngăn cách các số
                    i = i + 2;
                    int pos = i - 1;
                    while (IsNumber(exp[i]))
                    {
                        i++;
                        if (i == exp.Length)
                            break;
                    }
                    //Thêm dấu ()để ngăn cách các số hạng
                    result = result + "(" + exp.Substring(pos, i - pos) + ")";
                    i = i + 2;
                    continue;
                }
                // kiểm tra độ ưu tiên để tính toán
                if (exp[i] == '+' || exp[i] == '-' || exp[i] == '/' || exp[i] == '*')
                {
                    if (stk.Count > 0)
                    {
                        if (Priority(stk.Peek()) >= Priority(exp[i]))
                        {
                            result += stk.Pop();
                        }
                    }
                    stk.Push(exp[i]);
                }

                //Nếu là số hạng
                if (exp[i] >= '0' && exp[i] <= '9' || exp[i] == '.')
                {
                    //tách số từ vị trí đang xét. Thêm dấu () để ngăn cách các số
                    int pos = i;
                    while (IsNumber(exp[i]))
                    {
                        i++;
                        if (i == exp.Length)
                            break;
                    }
                    //Thêm dấu () để ngăn cách các số hạng
                    result = result + "(" + exp.Substring(pos, i - pos) + ")";
                    i--;

                }
            }
            // duyệt hết dấu trong vòng lặp
            foreach (char i in stk)
                result += i;

            return result;
        }

        // kiểm tra toán hạng
        private bool IsNumber(char c)
        {
            return (c >= '0' && c <= '9') || (c == '.');
        }

        // hàm tính toán 
        public double Calculate(string exp)
        {

            string bt = Convert(exp); // chuyển biểu thức 
            Stack<double> stk = new Stack<double>();
            //Console.WriteLine(bt);
            double tmp1, tmp2;
            // thực hiện tính toán vd : 3+2*5 đổi ra hậu tố 325*+ thực hiện 2*5 =10 bỏ kết quả vào stack và thực hiện 3+10
            for (int i = 0; i < bt.Length; i++)
            {

                switch (bt[i])
                {

                    case '*':
                        tmp1 = stk.Pop();
                        tmp2 = stk.Pop();
                        stk.Push(tmp2 * tmp1);
                        break;
                    case '/':
                        tmp1 = stk.Pop();
                        tmp2 = stk.Pop();
                        stk.Push(tmp2 / tmp1);
                        break;
                    case '-':
                        tmp1 = stk.Pop();
                        tmp2 = stk.Pop();
                        stk.Push(tmp2 - tmp1);
                        break;
                    case '+':
                        tmp1 = stk.Pop();
                        tmp2 = stk.Pop();
                        stk.Push(tmp2 + tmp1);
                        break;

                    default:
                        if (bt[i] == '(')
                        {
                            i = i + 1;
                            int pos = i;
                            while (IsNumber(bt[i]) | bt[i] == '-')
                            {
                                i++;
                                if (bt[i] == ')')
                                {
                                    break;
                                }
                            }

                            stk.Push(double.Parse(bt.Substring(pos, i - pos)));
                            i--;
                        }
                        break;
                }
            }
            return stk.Pop();

        }
    }
}
