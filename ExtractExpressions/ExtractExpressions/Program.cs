

string? expression = Console.ReadLine();

if (expression == null)
    return;

expression = expression.Replace(" ", string.Empty);

Stack<int> indexes = new Stack<int>();

for (int i = 0; i < expression.Length; i++)
{
    if (expression[i] == '(')
    {
        indexes.Push(i);
    }
    else if (expression[i] == ')')
    {
        Console.WriteLine(expression.Substring(indexes.Peek(), i - indexes.Pop()+1));
    }
}
Console.WriteLine(expression);
