namespace EntityFrameworkCodeFirstBindingExample
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Car
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Trademark { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        public short? HP { get; set; }

        public double? Liter { get; set; }

        public byte? Cyl { get; set; }

        public byte? TransmissSpeedCount { get; set; }

        [StringLength(3)]
        public string TransmissAutomatic { get; set; }

        public byte? MPG_City { get; set; }

        public byte? MPG_Highway { get; set; }

        [StringLength(7)]
        public string Category { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Hyperlink { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public string RtfContent { get; set; }
    }
}
