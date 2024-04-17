

using System.ComponentModel.DataAnnotations;

namespace todoFrançois.Models.TodoViewModels
{
    public class DureeGroupe
    {
        [DataType(DataType.Date)]
        public int ? Duree { get; set; }
        public int TodoCount { get; set; }
    }
}
