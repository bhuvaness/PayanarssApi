namespace CustomerBlazorWasm.Models.Dto
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool IsNew { get; set; }
        public bool IsDirty { get; set; }
    }
}
