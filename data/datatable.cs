using SQLite;
namespace data
{
    [Table("task_table")]
    class datatable
    {
        [Column("task_Name")]
        public string Name { get; set; }


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

    }
}