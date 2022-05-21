using System;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using App2.ViewModel.MainPageElenents.MainLayoutElements;

namespace Codeblock.Model
{
    public class Node
    {
        public MainField MainField;
        public virtual void Compilation(CodeBlock CurrentCodeBlock) { }

        #region LEVAN POLKKA
        ////////////////////////////_Levan Polkka_////////////////////////////
        public string Calculate(string input, string type, CodeBlock CurrentCodeBlock)
        {
            if (type == "index")
            {
                if (input[0] == '[' && input[input.Length - 1] == ']')
                {
                    string a = string.Empty;
                    for (int i = 1; i < input.Length - 1; i++)
                    {
                        a += input[i];
                    }
                    return Calculate(a, "int", CurrentCodeBlock);
                }
                else
                {
                    MainField.ConsoleWriteLine("Exception: " + input + " is not correct Variable");
                    CurrentCodeBlock.Error();
                    return "0";
                }
            }
            else if (type == "double")
            {
                string output = GetExpression(input, CurrentCodeBlock);

                if (CurrentCodeBlock.CompilationError) return "None";

                string result = CountingDouble(output, CurrentCodeBlock);

                return result;
            }
            else if (type == "int")
            {
                string output = GetExpression(input, CurrentCodeBlock);

                if (CurrentCodeBlock.CompilationError) return "None";

                string result = CountingInt(output, CurrentCodeBlock);

                return result;
            }
            else if (type == "bool")
            {
                DataTable table = new DataTable();
                table.Columns.Add("", typeof(Boolean));

                try
                {
                    table.Columns[0].Expression = PrepareString(input, CurrentCodeBlock);
                }
                catch (SyntaxErrorException)
                {
                    MainField.ConsoleWriteLine("Exception: incorrect bool expression");
                    CurrentCodeBlock.Error();
                    return "None";
                }

                Console.WriteLine(PrepareString(input, CurrentCodeBlock));

                DataRow r = table.NewRow();
                table.Rows.Add(r);
                Boolean result = (Boolean)r[0];
                return result.ToString().ToLower();
            }
            else if (type == "string")
            {
                return CalculateString(input, CurrentCodeBlock);
            }
            else if (type == "char")
            {
                return CalculateChar(input, CurrentCodeBlock);
            }
            else
            {
                MainField.ConsoleWriteLine("Exception: Type is not correct");
                CurrentCodeBlock.Error();
                return "None";
            }
        }
        string PrepareString(string s, CodeBlock CurrentCodeBlock)
        {
            string RegularPatternNumber = @"^[0-9.]+$";
            string RegularPatternVariable = @"^[A-Za-z_][A-Za-z0-9_\[\]]*$";

            string S = "";

            s = s.Replace("||", "Or");
            s = s.Replace("&&", "And");
            s = s.Replace("!", "Not");
            s = s.Replace("==", "=");

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z'))
                {
                    string a = string.Empty;
                    string b = string.Empty;

                    while (!IsDelimeter(s[i]) && !IsOperator(s[i]))
                    {
                        if (s[i] == '[')
                        {
                            int count = -1;
                            while (i < s.Length && (s[i] != ']' || count > 0))
                            {
                                if (s[i] == '[')
                                {
                                    count++;
                                }
                                if (s[i] == ']')
                                {
                                    count--;
                                }
                                b += s[i++];
                            }
                            if (i == s.Length) break;
                            b += s[i++];
                            break;
                        }
                        else
                        {
                            a += s[i];
                            i++;
                            if (i == s.Length) break;
                        }
                    }

                    if (!IsServiceVariable(a))
                    { 
                        for (int j = CurrentCodeBlock.AreaVariable.Count - 1; j >= 0; j--)
                        {
                            foreach (Variable CurrentVariable in CurrentCodeBlock.AreaVariable[j])
                            {
                                if (CurrentVariable.Name == a && (CurrentVariable.Type == "bool" || CurrentVariable.Type == "int" || CurrentVariable.Type == "double")) //TODO:
                                {
                                    S += CurrentVariable.GetValueFromName(CurrentCodeBlock, a, b);
                                    j = -1;
                                    break;
                                }
                            }
                            if (j == 0)
                            {
                                MainField.ConsoleWriteLine("Exception: " + a + " is not found");
                                CurrentCodeBlock.Error();
                                return "false";
                            }
                        }
                        S += " ";
                    }
                }
                else if (IsDigit(s[i]))
                {
                    string Number = string.Empty;

                    while (!IsDelimeter(s[i]) && !IsOperator(s[i]))
                    {
                        S += s[i];
                        Number += s[i];
                        i++;

                        if (i == s.Length) break;
                    }

                    if (!Regex.IsMatch(Number, RegularPatternNumber))
                    {
                        MainField.ConsoleWriteLine("Exception: " + Number + " is incorrect expression");
                        CurrentCodeBlock.Error();
                        return "None";
                    }

                    S += " ";
                    i--;
                }
                else
                {
                    S += s[i];
                    S += " ";
                }
            }
            Console.WriteLine(S);
            S = S.Replace(",", ".");
            return S;
        }
        static bool IsServiceVariable(string CurrentWord)
        {
            if (CurrentWord == "Or" || CurrentWord == "And" || CurrentWord == "Not" || CurrentWord.ToLower() == "true" || CurrentWord.ToLower() == "false")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetExpression(string input, CodeBlock CurrentCodeBlock)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            string RegularPatternNumber = @"^[0-9.]+$";
            string RegularPatternVariable = @"^[A-Za-z_][A-Za-z0-9_\[\]]*$";

            bool UnaryFlag = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                    continue;

                if (IsDigit(input[i]))
                {
                    string Number = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        Number += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    if (!Regex.IsMatch(Number, RegularPatternNumber))
                    {
                        MainField.ConsoleWriteLine("Exception: " + Number + " is incorrect expression");
                        CurrentCodeBlock.Error();
                        return "None";
                    }

                    UnaryFlag = false;

                    output += " ";
                    i--;
                }

                if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
                {
                    string Variable = string.Empty;

                    while (i < input.Length && !IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        Variable += input[i];
                        i++;
/*
                        if (i == input.Length) break;

                        if (input[i] == '[')
                        {
                            while (input[i] != ']')
                            {
                                output += input[i];
                                i++;

                                if (i == input.Length)
                                {
                                    MainField.ConsoleWriteLine("Exception: There isn't ] with [");
                                    CurrentCodeBlock.Error();
                                    return "None";
                                }
                            }
                            break;
                        }
*/
                    }

                    if (!Regex.IsMatch(Variable, RegularPatternVariable))
                    {
                        MainField.ConsoleWriteLine("Exception: " + Variable + " is incorrect expression");
                        CurrentCodeBlock.Error();
                        return "None";
                    }

                    UnaryFlag = false;

                    output += " ";
                    i--;
                }

                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        operStack.Push(input[i]);
                        UnaryFlag = true;
                    }
                    else if (input[i] == ')')
                    {
                        if (operStack.Count == 0)
                        {
                            MainField.ConsoleWriteLine("Exception: There isn't ( with )");
                            CurrentCodeBlock.Error();
                            return "None";
                        }

                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            if (operStack.Count == 0)
                            {
                                MainField.ConsoleWriteLine("Exception: There isn't ( with )");
                                CurrentCodeBlock.Error();
                                return "None";
                            }

                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                        UnaryFlag = false;
                    }
                    else
                    {
                        char curop = input[i];
                        if (UnaryFlag)
                        {
                            curop = (char)-curop;
                        }
                        if (operStack.Count > 0)
                            if (GetPriority(curop) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";

                        UnaryFlag = true;

                        operStack.Push(char.Parse(curop.ToString()));
                    }
                }
            }

            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }
        public string CountingDouble(string input, CodeBlock CurrentCodeBlock)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();


            for (int i = 0; i < input.Length; i++)
            {
                if (IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (IsDigit(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(ParseToDouble(a));
                    i--;
                }
                else if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
                {
                    string a = string.Empty;
                    string b = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        if (input[i] == '[')
                        {
                            int count = -1;
                            while (i < input.Length && (input[i] != ']' || count > 0))
                            {
                                if (input[i] == '[')
                                {
                                    count++;
                                }
                                if (input[i] == ']')
                                {
                                    count--;
                                }
                                b += input[i++];
                            }
                            if (i == input.Length) break;
                            b += input[i++];
                            break;
                        }
                        else
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                    }

                    if (GetValueFromName(CurrentCodeBlock, a, b) == "None") { return "None"; }

                    temp.Push(ParseToDouble(GetValueFromName(CurrentCodeBlock, a, b)));

                    i--;
                }
                else if (IsOperator(input[i]) || input[i] == 65491 || input[i] == 65493)
                {
                    if ((input[i] == 65491 || input[i] == 65493) && temp.Count >= 1) //unary plus and minus
                    {
                        double a = temp.Pop();

                        switch ((char)-input[i])
                        {
                            case '+': result = a; break;
                            case '-': result = -a; break;
                        }

                        temp.Push(result);
                    }
                    else if (temp.Count >= 2)
                    {
                        double a = temp.Pop();
                        double b = temp.Pop();

                        switch (input[i])
                        {
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '%': result = b % a; break;
                            case '/': if (a != 0) { result = b / a; break; } else { MainField.ConsoleWriteLine("Exception: attempted to divide by zero"); CurrentCodeBlock.Error(); } break;
                            case '^': result = ParseToDouble(Math.Pow(ParseToDouble(b.ToString()), ParseToDouble(a.ToString())).ToString()); break;
                        }
                        temp.Push(result);
                    }
                    else
                    {
                        MainField.ConsoleWriteLine("Exception: incorrect numeric expression");
                        CurrentCodeBlock.Error();
                        return "None";
                    }
                }
            }
            if (temp.Count != 1)
            {
                MainField.ConsoleWriteLine("Exception: incorrect numeric expression");
                CurrentCodeBlock.Error();
                return "None";
            }
            return temp.Peek().ToString();
        }
        public string CountingInt(string input, CodeBlock CurrentCodeBlock)
        {
            int result = 0;
            Stack<int> temp = new Stack<int>();


            for (int i = 0; i < input.Length; i++)
            {
                if (IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (IsDigit(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(int.Parse(Math.Floor(ParseToDouble(a)).ToString()));
                    i--;
                }
                else if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
                {
                    string a = string.Empty;
                    string b = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        if (input[i] == '[')
                        {
                            int count = -1;
                            while (i < input.Length && (input[i] != ']' || count > 0))
                            {
                                if (input[i] == '[')
                                {
                                    count++;
                                }
                                if (input[i] == ']')
                                {
                                    count--;
                                }
                                b += input[i++];
                            }
                            if (i == input.Length) break;
                            b += input[i++];
                            break;
                        }
                        else
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                    }

                    if (GetValueFromName(CurrentCodeBlock, a, b) == "None") { return "None"; }

                    temp.Push(int.Parse(Math.Floor(ParseToDouble(GetValueFromName(CurrentCodeBlock, a, b))).ToString()));

                    i--;
                }
                else if (IsOperator(input[i]) || input[i] == 65491 || input[i] == 65493)
                {
                    if ((input[i] == 65491 || input[i] == 65493) && temp.Count >= 1) //unary plus and minus
                    {
                        int a = temp.Pop();

                        switch ((char)-input[i])
                        {
                            case '+': result = a; break;
                            case '-': result = -a; break;
                        }

                        temp.Push(result);
                    }
                    else if (temp.Count >= 2)
                    {
                        int a = temp.Pop();
                        int b = temp.Pop();

                        switch (input[i])
                        {
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '%': result = b % a; break;
                            case '/': if (a != 0) { result = b / a; break; } else { MainField.ConsoleWriteLine("Exception: attempted to divide by zero"); CurrentCodeBlock.Error(); } break;
                            case '^': result = int.Parse(Math.Pow(ParseToDouble(b.ToString()), ParseToDouble(a.ToString())).ToString()); break;
                        }
                        temp.Push(result);
                    }
                    else
                    {
                        MainField.ConsoleWriteLine("Exception: incorrect numeric expression");
                        CurrentCodeBlock.Error();
                        return "None";
                    }
                }
            }
            if (temp.Count != 1)
            {
                MainField.ConsoleWriteLine("Exception: incorrect numeric expression");
                CurrentCodeBlock.Error();
                return "None";
            }
            return temp.Peek().ToString();
        }
        public double ParseToDouble(string value)
        {
            double result = Double.NaN;
            value = value.Trim();
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("ru-RU"), out result))
            {
                if (!double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out result))
                {
                    return Double.NaN;
                }
            }
            return result;
        }
        public bool IsDelimeter(char c)
        {
            if (" =".IndexOf(c) != -1)
                return true;
            return false;
        }
        public bool IsOperator(char с)
        {
            if ("+-/*^()%♣".IndexOf(с) != -1)
                return true;
            return false;
        }
        public bool IsDigit(char c)
        {
            if ("0123456789.".IndexOf(c) != -1)
                return true;
            return false;
        }
        public static byte GetPriority(char s)
        {
            if (s == -'+' || s == -'-')
            {
                return 7;
            }
            else
            {
                switch (s)
                {
                    case '(': return 0;
                    case ')': return 1;
                    case '+': return 2;
                    case '-': return 3;
                    case '*': return 4;
                    case '%': return 4;
                    case '/': return 4;
                    case '^': return 5;
                    default: return 6;
                }
            }
        }
        public string GetValueFromName(CodeBlock CurrentCodeBlock, string name, string index = "")
        {
            for (int i = CurrentCodeBlock.AreaVariable.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < CurrentCodeBlock.AreaVariable[i].Count; j++)
                {
                    if (CurrentCodeBlock.AreaVariable[i][j].Name == name)
                    {
                        return CurrentCodeBlock.AreaVariable[i][j].GetValue(CurrentCodeBlock, index);
                    }
                }
                if (i == 0)
                {
                    MainField.ConsoleWriteLine("Exception: " + name + " is undefined");
                    CurrentCodeBlock.Error();
                    return "None";
                }
            }
            CurrentCodeBlock.Error();
            return "None";
        }
        public string CalculateString(string input, CodeBlock CurrentCodeBlock)
        {
            string output = string.Empty;
            bool plus = true;
            bool error = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (error)
                {
                    break;
                }
                else if (input[i] == '+')
                {
                    if (plus)
                    {
                        MainField.ConsoleWriteLine("Exception: used + incorrectly");
                        error = true;
                    }
                    plus = true;
                }
                else if (Char.IsDigit(input[i]))
                {
                    MainField.ConsoleWriteLine("Exception: String + Number is not correct, use \" \" symbols");
                    error = true;
                }
                else if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z')) //TODO: Variable find
                {
                    string a = string.Empty;
                    string b = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        if (input[i] == '[')
                        {
                            int count = -1;
                            while (i < input.Length && (input[i] != ']' || count > 0))
                            {
                                if (input[i] == '[')
                                {
                                    count++;
                                }
                                if (input[i] == ']')
                                {
                                    count--;
                                }
                                b += input[i++];
                            }
                            if (i == input.Length) break;
                            b += input[i++];
                            break;
                        }
                        else
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                    }

                    for (int j = CurrentCodeBlock.AreaVariable.Count - 1; j >= 0; j--)
                    {
                        foreach (Variable CurrentVariable in CurrentCodeBlock.AreaVariable[j])
                        {
                            if (CurrentVariable.Name == a)
                            {
                                if (plus)
                                {
                                    if (CurrentVariable.GetValue(CurrentCodeBlock, b) == "None")
                                    {
                                        error = true;
                                    }
                                    else
                                    {
                                        output += CurrentVariable.GetValue(CurrentCodeBlock, b);
                                    }
                                }
                                else
                                {
                                    MainField.ConsoleWriteLine("Exception: don't used +");
                                    error = true;
                                }
                                j = -1;
                                break;
                            }
                        }
                        if (j == 0)
                        {
                            MainField.ConsoleWriteLine("Exception: " + a + " is undefined");
                            error = true;
                        }
                    }

                    plus = false;
                    i--;
                }
                else if (input[i] == '\"')
                {
                    i++;
                    while (input[i] != '\"')
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length - 1) break;
                    }
                    if (input[i] != '\"')
                    {
                        MainField.ConsoleWriteLine("Exception: Input has incorrect \" symbol");
                        error = true;
                    }
                    else if (!plus)
                    {
                        MainField.ConsoleWriteLine("Exception: don't used +");
                        error = true;
                    }
                    plus = false;
                }
            }
            if (!error)
            {
                return output;
            }
            else
            {
                CurrentCodeBlock.Error();
                return "None";
            }
        }
        public string CalculateChar(string input, CodeBlock CurrentCodeBlock)
        {
            if (input.Length == 3 && input[0] == '\'' && input[2] == '\'')
            {
                return input[1].ToString();
            }
            else
            {
                if (input.Length > 0 && Char.IsLetter(input[0]))
                {
                    string a = string.Empty;
                    string b = string.Empty;
                    int i = 0;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        if ("[".IndexOf(input[i]) != -1)
                        {
                            while ("]".IndexOf(input[i]) == -1)
                            {
                                b += input[i];
                                i++;
                                if (i == input.Length) break;
                            }

                            b += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        else
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                    }

                    for (int j = CurrentCodeBlock.AreaVariable.Count - 1; j >= 0; j--)
                    {
                        foreach (Variable CurrentVariable in CurrentCodeBlock.AreaVariable[j])
                        {
                            if (CurrentVariable.Name == a && (CurrentVariable.Type == "string" || CurrentVariable.Type == "char"))
                            {
                                if (CurrentVariable.GetValue(CurrentCodeBlock, b).Length == 1)
                                {
                                    return CurrentVariable.GetValue(CurrentCodeBlock, b);
                                }
                                else
                                {
                                    MainField.ConsoleWriteLine("Exception: Char " + a + " can't assign string");
                                    CurrentCodeBlock.Error();
                                    return "None";
                                }
                            }
                        }
                    }
                    MainField.ConsoleWriteLine("Exception: " + a + " is undefined");
                    CurrentCodeBlock.Error();
                    return "None";
                }
                else if (Calculate(input, "int", CurrentCodeBlock) != "None" && int.Parse(Calculate(input, "int", CurrentCodeBlock)) > 0 && int.Parse(Calculate(input, "int", CurrentCodeBlock)) < 65536)
                {
                    return ((char)int.Parse(Calculate(input, "int", CurrentCodeBlock))).ToString();
                }
                else
                {
                    MainField.ConsoleWriteLine("Char's Input is not correct");
                    CurrentCodeBlock.Error();
                    return "None";
                }
            }
        }
    }
    ////////////////////////////_Levan Polkka_////////////////////////////
    #endregion
}