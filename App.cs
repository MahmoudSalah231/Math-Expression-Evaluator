namespace Math_Expression_Evaluator
    {
    internal class App
        {
        public static void Run(string[] args)
            {
            while(true)
                {
                Console.Write("please enter a math expression: ");
                var input = Console.ReadLine();
                var expr = ExpressionParser.parse(input);
                Console.WriteLine($"left side is {expr.LeftSideOperand}  the operation is {expr.operation} the right side is {expr.RightSideOperand}");
                Console.WriteLine($"{input,2} = {EvaluateExpresion(expr),2}");
                }

            }

        private static object EvaluateExpresion(MathExpression expr)
            {
            switch(expr.operation)
                {
                case MathOperation.Addition:
                    return expr.LeftSideOperand + expr.RightSideOperand;
                case MathOperation.Subsraction:
                    return expr.LeftSideOperand - expr.RightSideOperand;
                case MathOperation.Multiplication:
                    return expr.LeftSideOperand * expr.RightSideOperand;
                case MathOperation.Division:
                    return expr.LeftSideOperand / expr.RightSideOperand;
                case MathOperation.Mudelus:
                    return expr.LeftSideOperand % expr.RightSideOperand;
                case MathOperation.Power:
                    return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);
                case MathOperation.Sin:
                    return Math.Sin(expr.RightSideOperand);
                case MathOperation.Cos:
                    return Math.Cos(expr.RightSideOperand);
                case MathOperation.Tan:
                    return Math.Tan(expr.RightSideOperand);
                default:
                    return 0;
                }
            }
        }

    }
