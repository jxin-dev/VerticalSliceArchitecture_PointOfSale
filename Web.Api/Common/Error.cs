namespace Web.Api.Common
{
    public record Error
    {
        public static readonly Error None = new Error(string.Empty, string.Empty);
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
        public string Code { get; private set; }
        public string Description { get; private set; }

    }
}
