namespace FlashCardApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QA
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public virtual Category Category { get; set; }
    }
}
