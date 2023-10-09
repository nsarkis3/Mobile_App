using SQLite;
namespace DBIntro
{
    [Table("person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name2 { get; set; }

        public DateTime DOB { get; set; }

        [Unique]
        public string SSN { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) {2} {3}", Name2, Id, DOB, SSN);
        }
    }
}