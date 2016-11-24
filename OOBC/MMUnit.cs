namespace OOBC
{
    public class MMUnit : Unit
    {
        public MMUnit() : base("MM") { }

        public override Unit Next { get; } = null;

        public override uint NextCount { get; } = 1;
    }
}