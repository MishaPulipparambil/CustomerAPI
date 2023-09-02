namespace CustomerAPI.DTO
{
    public class AddressInfoDto
    {
        public Guid Id { get; set; }

        public string StreetAddress1 { get; set; } = null!;

        public string? StreetAddress2 { get; set; }

        public string? AptmntOrUnitNo { get; set; }

        public string City { get; set; } = null!;

        public int StateId { get; set; }

        public string? ZipCode { get; set; }
      

    }
}
