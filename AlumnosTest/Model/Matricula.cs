using System;
using System.Collections.Generic;

#nullable disable

namespace AlumnosTest.Model
{
    public partial class Matricula
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdAlumno { get; set; }
        public string Comentarios { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
    }
}
