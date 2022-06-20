namespace Calculator
{
    public interface IInstruction
    {
        double Number { get; set; }
        IOperator Operator { get; set; }
    }
}