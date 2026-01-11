
namespace Math_Expression_Evaluator
    {
    internal static class ExpressionParser
        {
        private const string MathSympols = "+*/%^";
        public static MathExpression parse(string input)
            {
            MathExpression expression = new MathExpression();
            string token = "";
            bool leftSideInitialized = false;
            for(var i = 0 ; i < input.Length ; i++)// 5 + 6
                {
                var currentChar = input[i];
                if(char.IsDigit(currentChar))
                    {
                    token += currentChar;
                    if(i == input.Length - 1 && leftSideInitialized)
                        {
                        expression.RightSideOperand = double.Parse(token);
                        break;
                        }
                    }
                else if(MathSympols.Contains(currentChar))
                    {
                    if(!leftSideInitialized)
                        {
                        expression.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        }

                    expression.operation = ParseMathOperation(currentChar.ToString());
                    token = "";

                    }
                else if(currentChar == '-' && i > 0)
                    {
                    if(expression.operation == MathOperation.none)
                        {
                        expression.operation = MathOperation.Subsraction;
                        expression.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                        }
                    else
                        {
                        token += currentChar;
                        }
                    }
                else if(char.IsLetter(currentChar))
                    {
                    leftSideInitialized = true;
                    token += currentChar;
                    }
                else if(currentChar == ' ')
                    {
                    if(!leftSideInitialized)
                        {
                        expression.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";

                        }
                    else if(expression.operation == MathOperation.none)
                        {
                        expression.operation = ParseMathOperation(token);
                        token = "";
                        }
                    }
                else
                    token += currentChar;
                }



            return expression;
            }

        private static MathOperation ParseMathOperation(string token)
            {
            switch(token.ToLower())
                {
                case "+":
                    return MathOperation.Addition;
                case "-":
                    return MathOperation.Subsraction;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Mudelus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.none;
                }

            }
        }
    }
