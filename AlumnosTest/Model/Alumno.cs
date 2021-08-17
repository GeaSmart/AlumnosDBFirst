using System;
using System.Collections.Generic;

#nullable disable

namespace AlumnosTest.Model
{
    public partial class Alumno
    {
        public Alumno()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
