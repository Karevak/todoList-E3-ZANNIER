namespace todoFrançois.Models
{

    public class TodoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duree {  get; set; }
        public DateTime DateDebut { get; set; }= DateTime.Now;
        public DateTime DateFin { get; set; }


    }
}
